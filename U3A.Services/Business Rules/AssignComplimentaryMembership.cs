using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Linq;
using U3A.Database;
using U3A.Model;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        public static async Task<int> AssignLifeComplimentaryMembership(U3ADbContext dbc, int FinancialTo) {
            int result = 0;
            var persons = await BusinessRule.SelectablePersonsIncludeUnfinancialAsync(dbc);
            foreach (var p in persons.Where(x => x.IsLifeMember)) {
                result += await CreateCashReceipt(dbc, p, "Complimentary Life Membership", FinancialTo);
            }
            await dbc.SaveChangesAsync();
            return result;
        }
        public static async Task<int> AssignCommitteeComplimentaryMembership(U3ADbContext dbc, int FinancialTo) {
            int result = 0;
            var persons = await BusinessRule.SelectablePersonsIncludeUnfinancialAsync(dbc);
            foreach (var p in persons.Where(x => x.IsCommitteeMember)) {
                result += await CreateCashReceipt(dbc, p, "Complimentary Committee Membership", FinancialTo);
            }
            await dbc.SaveChangesAsync();
            return result;
        }
        public static async Task<Tuple<int, int>> AssignCourseLeaderComplimentaryMembership(U3ADbContext dbc, int FinancialTo) {
            var added = 0;
            var removed = 0;
            var reason = "Complimentary Course Leader Membership";
            var settings = await dbc.SystemSettings.FirstOrDefaultAsync();
            if (settings != null) {
                var persons = await BusinessRule.SelectablePersonsIncludeUnfinancialAsync(dbc);
                foreach (var p in persons.Where(x => x.IsCourseLeader)) {
                    if (GetCourseCount(dbc, p, FinancialTo) <= settings.LeaderMaxComplimentaryCourses) {
                        added += await CreateCashReceipt(dbc, p, reason, FinancialTo);
                    }
                    else {
                        var q = dbc.Receipt.Where(x => x.FinancialTo == FinancialTo
                                                                && x.PersonID == p.ID
                                                                && x.Description == reason);
                        if (q.Any()) {
                            dbc.RemoveRange(q);
                            removed = q.Count();
                        }
                    }
                }
                await dbc.SaveChangesAsync();
            }
            return Tuple.Create(added, removed);
        }

        private static int GetCourseCount(U3ADbContext dbc, Person person, int FinancialTo) {
            int result = 0;
            foreach (var e in dbc.Enrolment.Where(x => x.PersonID == person.ID)
                                     .Include(x => x.Course).ThenInclude(x => x.Classes)
                                     .Include(x => x.Term).AsEnumerable()
                                     .Where(x => x.Term.Year == FinancialTo && !x.IsWaitlisted)
                                     .DistinctBy(x => x.CourseID)) {
                var c = e.Course;
                if (!c.ExcludeFromLeaderComplimentaryCount) {
                    if (! c.Classes.Any(x => x.LeaderID == person.ID || x.Leader2ID == person.ID || x.Leader3ID == person.ID)){
                        result++;
                    }
                }
            };
            return result;
        }
        public static async Task<int> AssignVolunteerComplimentaryMembership(U3ADbContext dbc, int FinancialTo, string Activity) {
            var result = 0;
            var activities = await dbc.Volunteer.Where(x => x.Activity == Activity).ToListAsync();
            foreach (var a in activities) {
                var person = await dbc.Person.FindAsync(a.PersonID);
                if (person != null) {
                    result += await CreateCashReceipt(dbc, person, $"Complimentary Membership - {Activity}", FinancialTo);
                }
            }
            await dbc.SaveChangesAsync();
            return result;
        }
        public static async Task<int> AssignOtherComplimentaryMembership(U3ADbContext dbc,
                                            int FinancialTo, IEnumerable<Person> people, string Reason) {
            var result = 0;
            foreach (var p in people) {
                var person = await dbc.Person.FindAsync(p.ID);
                if (person != null) {
                    result += await CreateCashReceipt(dbc, person, $"Complimentary Membership - {Reason}", FinancialTo);
                }
            }
            await dbc.SaveChangesAsync();
            return result;
        }
        public static async Task<int> RemoveOtherComplimentaryMembership(U3ADbContext dbc,
                                            int FinancialTo, IEnumerable<Person> people) {
            var result = 0;
            foreach (var p in people) {
                var person = await dbc.Person.FindAsync(p.ID);
                if (person != null) {
                    await dbc.Receipt.Where(x => x.PersonID == person.ID
                                        && x.FinancialTo >= FinancialTo
                                        && x.Amount == 0).ExecuteDeleteAsync();
                    if (person.PreviousFinancialTo != null) { person.FinancialTo = person.PreviousFinancialTo.Value; }
                    if (person.PreviousDateJoined != null) { person.DateJoined = person.PreviousDateJoined.Value; }
                    result++;
                }
            }
            await dbc.SaveChangesAsync();
            return result;
        }

        private static async Task<int> CreateCashReceipt(U3ADbContext dbc, Person person, string Description, int FinancialTo) {
            int result = 0;
            var isOnFile = await dbc.Receipt.AnyAsync(x => x.PersonID == person.ID
                                && x.FinancialTo >= FinancialTo
                                && x.Amount == 0);
            if (!isOnFile) {
                result = 1;
                var receipt = new Receipt() {
                    Description = Description,
                    FinancialTo = FinancialTo,
                    Amount = 0,
                    Date = DateTime.Today,
                    PersonID = person.ID,
                    ProcessingYear = FinancialTo,
                };
                if (person.DateJoined != null) {
                    receipt.DateJoined = person.DateJoined.Value;
                    person.PreviousDateJoined = person.DateJoined.Value;
                }
                if (FinancialTo > person.FinancialTo) {
                    person.PreviousFinancialTo = person.FinancialTo;
                    person.FinancialTo = FinancialTo;
                }
                dbc.Update(person);
                dbc.Add(receipt);
            }
            return result;
        }
    }
}

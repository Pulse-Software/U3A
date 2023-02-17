using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using U3A.Database;
using U3A.Model;
using System.Linq;
using Twilio.TwiML.Fax;
using System;
using Eway.Rapid.Abstractions.Response;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule {
        public static async Task<List<Person>> EditablePersonAsync(U3ADbContext dbc) {
            var people = dbc.Person
                            .AsEnumerable()
                            .OrderBy(x => x.LastName)
                            .ThenBy(x => x.FirstName)
                            .ThenBy(x => x.Email).ToList();
            await ApplyGroupsAsync(dbc, people);
            return people;
        }
        public static Person SelectPerson(U3ADbContext dbc, Guid ID) {
            var person = dbc.Person.Find(ID) ?? throw new ArgumentNullException(nameof(Person));
            ApplyGroups(dbc, person);
            return person;
        }

        public static async Task<List<Person>> SelectablePersonsAsync(U3ADbContext dbc, Term term) {
            var people = dbc.Person.AsNoTracking()
                            .AsEnumerable()
                            .Where(x => x.DateCeased == null)
                            .OrderBy(x => x.LastName)
                            .ThenBy(x => x.FirstName)
                            .ThenBy(x => x.Email).ToList();
            await ApplyGroupsAsync(dbc, people);
            return people.Where(x => x.FinancialTo >= term.Year - 1).ToList();
        }
        public static List<Person> GetPostalPersons(U3ADbContext dbc, Term term, bool includeUnfinancial) {
            var finToYear = (includeUnfinancial) ? term.Year - 1 : term.Year;
            var people = dbc.Person.AsNoTracking()
                            .AsEnumerable()
                            .Where(x => x.DateCeased == null && x.Communication != "Email")
                            .OrderBy(x => x.LastName)
                            .ThenBy(x => x.FirstName);
            foreach (var p in people) ApplyGroups(dbc, p);
            return people.Where(x => x.FinancialTo >= finToYear).ToList();
        }
        public static List<Person> SelectablePersonsIncludeUnfinancial(U3ADbContext dbc) {
            var people = dbc.Person
                            .AsNoTracking()
                            .AsEnumerable()
                            .Where(x => x.DateCeased == null)
                            .OrderBy(x => x.LastName)
                            .ThenBy(x => x.FirstName)
                            .ThenBy(x => x.Email).ToList();
            foreach (var p in people) ApplyGroups(dbc, p);
            return people;
        }
        public static async Task<List<Person>> SelectablePersonsIncludeUnfinancialAsync(U3ADbContext dbc) {
            var people = dbc.Person
                            .AsNoTracking()
                            .AsEnumerable()
                            .Where(x => x.DateCeased == null)
                            .OrderBy(x => x.LastName)
                            .ThenBy(x => x.FirstName)
                            .ThenBy(x => x.Email).ToList();
            await ApplyGroupsAsync(dbc, people);
            return people;
        }
        public static List<Person> SelectableLeaders(U3ADbContext dbc, Guid TermID) {
            var term = dbc.Term.Find(TermID);
            if (term == null) { return new List<Person> { }; }
            var people = dbc.Person.AsNoTracking()
                            .Where(x => x.DateCeased == null
                                    && (x.LeaderOf.Any() || x.Leader2Of.Any() || x.Leader3Of.Any())).ToList();
            foreach (var person in people) {
                person.LeaderOf = dbc.Class
                            .Include(x => x.Course).ThenInclude(x => x.CourseParticipationType)
                            .Include(x => x.Venue)
                            .Include(x => x.OnDay)
                            .Include(x => x.Leader)
                            .Include(x => x.Leader2)
                            .Include(x => x.Leader3)
                            .Include(x => x.Occurrence)
                            .Where(x => (x.LeaderID == person.ID || x.Leader2ID == person.ID || x.Leader3ID == person.ID) &&
                                            x.Course.Year == term.Year)
                                            .AsEnumerable()
                                            .Where(x => IsClassInTerm(x, term.TermNumber)).ToList();
                foreach (var c in person.LeaderOf) {
                    c.Enrolments.AddRange(BusinessRule.SelectableEnrolmentsByClass(dbc, c, term, c.Course));
                }
            }
            return people.Where(x => x.LeaderOf.Any()).ToList();
        }

        public static async Task<bool> IsLeader(U3ADbContext dbc, Person person, Term term) {
            return await dbc.Class
                .Include(x => x.Course)
                .AnyAsync(x => (x.LeaderID == person.ID || 
                                x.Leader2ID == person.ID || 
                                x.Leader3ID == person.ID) &&
                                x.Course.Year == term.Year);
        }


        public static List<Person> SelectablePersonsWithEnrolments(U3ADbContext dbc, Guid TermID, bool WaitlistStatus) {
            var term = dbc.Term.Find(TermID);
            if (term == null) { return new List<Person> { }; }
            var Classes = dbc.Class.AsNoTracking()
                        .Include(x => x.Enrolments)
                        .Include(x => x.Course).ThenInclude(x => x.CourseParticipationType)
                        .Include(x => x.Venue)
                        .Include(x => x.OnDay)
                        .Include(x => x.Leader)
                        .Include(x => x.Occurrence)
                        .Where(x => x.Course.Year == term.Year).ToList();
            var people = dbc.Person.AsNoTracking()
                .Include(x => x.Enrolments)
                .Include(x => x.Enrolments).ThenInclude(x => x.Course).ThenInclude(x => x.CourseParticipationType)
                .Include(x => x.Enrolments).ThenInclude(x => x.Class).ThenInclude(x => x.Venue)
                .Include(x => x.Enrolments).ThenInclude(x => x.Class).ThenInclude(x => x.OnDay)
                .Include(x => x.Enrolments).ThenInclude(x => x.Class).ThenInclude(x => x.Leader)
                .Include(x => x.Enrolments).ThenInclude(x => x.Class).ThenInclude(x => x.Occurrence)
                .Where(x => x.DateCeased == null).ToList();
            foreach (var person in people) {
                person.EnrolledClasses.Clear();
                foreach (var e in person.Enrolments.Where(x => x.TermID == term.ID && x.IsWaitlisted == WaitlistStatus)) {
                    if (e.Class == null) {
                        foreach (var c in Classes.Where(x => e.CourseID == x.CourseID)) {
                            person.EnrolledClasses.Add(c);
                        }
                    }
                    else {
                        person.EnrolledClasses.Add(e.Class);
                    }
                }
            }
            return people.Where(x => x.EnrolledClasses.Any()).ToList();
        }

        async static Task ApplyGroupsAsync(U3ADbContext dbc, List<Person> people) {
            Term? term = await dbc.Term.Where(x => x.IsDefaultTerm).FirstOrDefaultAsync();
            if (term != null) {
                foreach (var l in await dbc.Class.Include(x => x.Course)
                    .Where(x => x.LeaderID != null && x.Course.Year == term.Year)
                    .Select(x => x.LeaderID).ToListAsync()) {
                    var p = people.Find(x => x.ID == l);
                    if (p != null) {
                        p.IsCourseLeader = true;
                        if (p.FinancialTo < term.Year) p.FinancialTo = term.Year;
                    }
                };
                foreach (var l in await dbc.Class.Include(x => x.Course)
                    .Where(x => x.Leader2ID != null && x.Course.Year == term.Year)
                    .Select(x => x.Leader2ID).ToListAsync()) {
                    var p = people.Find(x => x.ID == l);
                    if (p != null) {
                        p.IsCourseLeader = true;
                        if (p.FinancialTo < term.Year) p.FinancialTo = term.Year;
                    }
                };
                foreach (var l in await dbc.Class.Include(x => x.Course)
                    .Where(x => x.Leader3ID != null && x.Course.Year == term.Year)
                    .Select(x => x.Leader3ID).ToListAsync()) {
                    var p = people.Find(x => x.ID == l);
                    if (p != null) {
                        p.IsCourseLeader = true;
                        if (p.FinancialTo < term.Year) p.FinancialTo = term.Year;
                    }
                };
            }
            foreach (var v in await dbc.Volunteer.Select(x => x.PersonID).ToListAsync()) {
                var p = people.Find(x => x.ID == v);
                if (p != null) p.IsVolunteer = true;
            };
            foreach (var c in await dbc.Committee.Select(x => x.PersonID).ToListAsync()) {
                var p = people.Find(x => x.ID == c);
                if (p != null) {
                    p.IsCommitteeMember = true;
                    if (p.FinancialTo < term.Year) { p.FinancialTo += term.Year; }
                }
            };
            foreach (var p in people.Where(x => x.IsLifeMember)) {
                if (p.FinancialTo < term.Year) { p.FinancialTo += term.Year; }
            }
        }
        static void ApplyGroups(U3ADbContext dbc, Person person) {
            Term? term = dbc.Term.Where(x => x.IsDefaultTerm).FirstOrDefault();
            if (term != null) {
                if (dbc.Class.Include(x => x.Course)
                    .Where(x => x.Course.Year == term.Year
                        && (x.LeaderID == person.ID
                            || x.Leader2ID == person.ID
                            || x.Leader3ID == person.ID)).Any()) person.IsCourseLeader = true;
            }
            if (dbc.Volunteer.Where(x => x.PersonID == person.ID).Any()) { person.IsVolunteer = true; }
            if (dbc.Committee.Where(x => x.PersonID == person.ID).Any()) { person.IsCommitteeMember = true; }
            if (person.IsCourseLeader || person.IsLifeMember || person.IsCommitteeMember) {
                if (person.FinancialTo < term.Year) person.FinancialTo += term.Year;
            }
        }

        public static Person ConvertPersonImportToPerson(PersonImport ImportData) {
            Person person = new Person() {
                DataImportTimestamp = ImportData.Timestamp,
                FirstName = ImportData.FirstName,
                LastName = ImportData.LastName,
                Address = ImportData.Address,
                City = ImportData.City,
                State = ImportData.State,
                Postcode = ImportData.Postcode,
                Gender = ImportData.Gender,
                BirthDate = ImportData.BirthDate,
                Email = ImportData.Email,
                HomePhone = ImportData.HomePhone,
                Mobile = ImportData.Mobile,
                SMSOptOut = ImportData.SMSOptOut,
                ICEContact = ImportData.ICEContact,
                ICEPhone = ImportData.ICEPhone,
                VaxCertificateViewed = ImportData.VaxCertificateViewed,
                Occupation = ImportData.Occupation,
                Communication = ImportData.Communication,
            };
            if (ImportData.IsNewPerson) person.DateJoined = DateTime.Today;
            return person;
        }
        public static Person ConvertPersonImportToPerson(Person person, PersonImport ImportData) {
            person.DataImportTimestamp = ImportData.Timestamp;
            person.FirstName = ImportData.FirstName;
            person.LastName = ImportData.LastName;
            person.Address = ImportData.Address;
            person.City = ImportData.City;
            person.State = ImportData.State;
            person.Postcode = ImportData.Postcode;
            person.Gender = ImportData.Gender;
            person.BirthDate = ImportData.BirthDate;
            person.Email = ImportData.Email;
            person.HomePhone = ImportData.HomePhone;
            person.Mobile = ImportData.Mobile;
            person.SMSOptOut = ImportData.SMSOptOut;
            person.ICEContact = ImportData.ICEContact;
            person.ICEPhone = ImportData.ICEPhone;
            person.VaxCertificateViewed = ImportData.VaxCertificateViewed;
            person.Occupation = ImportData.Occupation;
            person.Communication = ImportData.Communication;
            if (ImportData.IsNewPerson) person.DateJoined = DateTime.Today;
            return person;
        }
        public static async Task<Person?> FindPersonByImportDataID(U3ADbContext dbc, string Timestamp) {
            return await dbc.Person.Where(x => x.DataImportTimestamp.Trim() == Timestamp.Trim()).FirstOrDefaultAsync();
        }
    }
}

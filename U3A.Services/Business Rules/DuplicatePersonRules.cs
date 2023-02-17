using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.RegularExpressions;
using U3A.Database;
using U3A.Model;
using System.ComponentModel;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        private static readonly Regex regex = new Regex("^[a-zA-Z0-9]");
        public static async Task<Person?> DuplicatePersonAsync(U3ADbContext dbc, Person person, string CurrentMemberID) {
            int currentID;
            List<Person>? potentialDuplicates = new List<Person>();
            if (!string.IsNullOrWhiteSpace(CurrentMemberID)) {
                if (int.TryParse(CurrentMemberID, out currentID)) {
                    // old member ID test
                    potentialDuplicates = await dbc.Person.
                                            Where(x => x.ConversionID == currentID).
                                            ToListAsync();
                }
            }
            if (!potentialDuplicates.Any()) {
                // Same Data Import Timestamp???
                potentialDuplicates = await dbc.Person.
                    Where(x => x.DataImportTimestamp == person.DataImportTimestamp).ToListAsync();

            }
            if (potentialDuplicates.Any()) {
                return potentialDuplicates.First();
            }
            else {
                return await DuplicatePersonAsync(dbc, person);
            }
        }
        private static async Task<Person?> DuplicatePersonAsync(U3ADbContext dbc, Person person) {
            int matches = 0;
            if (string.IsNullOrWhiteSpace(person.Gender)) return null;
            if (string.IsNullOrWhiteSpace(person.FirstName)) return null;
            if (string.IsNullOrWhiteSpace(person.LastName)) return null;
            List<Person> potentialDuplicates;
            potentialDuplicates = await dbc.Person
                                    .Where(x => x.ID != person.ID &&
                                           x.Gender.ToUpper().Trim() == person.Gender.ToUpper().Trim() &&
                                           x.LastName.ToUpper().Trim() == person.LastName.ToUpper().Trim() &&
                                           x.FirstName.ToUpper().Trim() == person.FirstName.ToUpper().Trim())
                                    .ToListAsync();
            foreach (var p in potentialDuplicates) {
                matches = CountMatches(person, p);
                if (matches > 0) { return p; }
            }
            potentialDuplicates = await dbc.Person
                                    .Where(x => x.ID != person.ID &&
                                           x.Gender.ToUpper().Trim() == person.Gender.ToUpper().Trim() &&
                                           x.LastName.ToUpper().Trim() == person.LastName.ToUpper().Trim())
                                    .ToListAsync();
            foreach (var p in potentialDuplicates) {
                matches = CountMatches(person, p);
                if (matches > 1) { return p; }
            }
            potentialDuplicates = await dbc.Person
                                    .Where(x => x.ID != person.ID &&
                                           x.Gender.ToUpper().Trim() == person.Gender.ToUpper().Trim() &&
                                           x.FirstName.ToUpper().Trim() == person.FirstName.ToUpper().Trim())
                                    .ToListAsync();
            foreach (var p in potentialDuplicates) {
                matches = CountMatches(person, p);
                if (matches > 1) { return p; }
            }
            return null;
        }

        private static int CountMatches(Person person, Person duplicate) {
            int count = 0;
            if ((!string.IsNullOrWhiteSpace(person.Mobile)) &&
                                strip(person.Mobile) == strip(duplicate.Mobile ?? "")) { count++; }
            if ((!string.IsNullOrWhiteSpace(person.HomePhone)) &&
                                strip(person.HomePhone) == strip(duplicate.HomePhone ?? "")) { count++; }
            if ((!string.IsNullOrWhiteSpace(person.Email)) &&
                                strip(person.Email) == strip(duplicate.Email ?? "")) { count++; }
            if (person.BirthDate.HasValue &&
                                person.BirthDate.Value == (duplicate.BirthDate ?? DateTime.MinValue)) { count++; }
            return count;
        }

        private static string strip(string s) {
            return String.Concat(s.Where(c => !Char.IsWhiteSpace(c) && Char.IsLetterOrDigit(c))).ToUpper();
        }
        public static async Task<string> GetDuplicateMarkup(U3ADbContext dbc, Person person) {
            StringBuilder result = new StringBuilder();
            var duplicate = await DuplicatePersonAsync(dbc, person);
            if (duplicate != null) {
                string birthDate = (duplicate.BirthDate.HasValue) ? duplicate.BirthDate.Value.ToString("d") : "unknown";
                string email = (!string.IsNullOrWhiteSpace(duplicate.Email)) ? duplicate.Email : "unknown";
                string mobile = (!string.IsNullOrWhiteSpace(duplicate.Mobile)) ? duplicate.Mobile : "unknown";
                string homePhone = (!string.IsNullOrWhiteSpace(duplicate.HomePhone)) ? duplicate.HomePhone : "unknown";
                result.AppendLine("<p>A potential duplicate record with the following details has been found in the database.");
                result.AppendLine("It is strongly recommended you <strong>Cancel</strong> this entry and investigate further...</p>");
                result.AppendLine("<table class='table'>");
                result.AppendLine("<thead><tr>");
                result.AppendLine("<th scope='col'>Field</th>");
                result.AppendLine("<th scope='col'>Value</th>");
                result.AppendLine("<th scope='col'>Same?</th>");
                result.AppendLine("</tr></thead>");
                result.AppendLine("<tbody>");
                result.AppendLine($"<tr><td>First Name:</td><td>{duplicate.FirstName}</td><td>{CheckSameFirstName(person, duplicate)}</td></tr>");
                result.AppendLine($"<tr><td>Last Name:</td><td>{duplicate.LastName}</td><td>{CheckSameLastName(person, duplicate)}</td></tr>");
                result.AppendLine($"<tr><td>Gender:</td><td>{duplicate.Gender}</td><td>{CheckSameGender(person, duplicate)}</td></tr>");
                result.AppendLine($"<tr><td>Birth Date:</td><td>{birthDate}</td><td>{CheckSameBirthdate(person, duplicate)}</td></tr>");
                result.AppendLine($"<tr><td>Home Phone:</td><td>{homePhone}</td><td>{CheckSameHomePhone(person, duplicate)}</td></tr>");
                result.AppendLine($"<tr><td>Mobile:</td><td>{mobile}</td><td>{CheckSameMobile(person, duplicate)}</td></tr>");
                result.AppendLine($"<tr><td>Email:</td><td>{email}</td><td>{CheckSameEmail(person, duplicate)}</td></tr>");
                result.AppendLine("</tbody></table>");
            }
            return result.ToString();
        }

        const string CHECK_MARK = "<i class='bi bi-arrow-left'></i>";
        static string CheckSameMobile(Person person, Person duplicate) {
            return (person.Mobile != null && strip(person.Mobile) == strip(duplicate.Mobile ?? "")) ? CHECK_MARK : string.Empty;
        }
        static string CheckSameHomePhone(Person person, Person duplicate) {
            return (person.HomePhone != null && strip(person.HomePhone) == strip(duplicate.HomePhone ?? "")) ? CHECK_MARK : string.Empty;
        }
        static string CheckSameEmail(Person person, Person duplicate) {
            return (person.Email != null && strip(person.Email) == strip(duplicate.Email ?? "")) ? CHECK_MARK : string.Empty;
        }
        static string CheckSameBirthdate(Person person, Person duplicate) {
            return (person.BirthDate.HasValue && strip(person.BirthDate.ToString() ?? "") == strip(duplicate.HomePhone?.ToString() ?? "")) ? CHECK_MARK : string.Empty;
        }
        static string CheckSameFirstName(Person person, Person duplicate) {
            return (person.FirstName != null && strip(person.FirstName) == strip(duplicate.FirstName ?? "")) ? CHECK_MARK : string.Empty;
        }
        static string CheckSameLastName(Person person, Person duplicate) {
            return (person.LastName != null && strip(person.LastName) == strip(duplicate.LastName ?? "")) ? CHECK_MARK : string.Empty;
        }
        static string CheckSameGender(Person person, Person duplicate) {
            return (person.Gender != null && strip(person.Gender) == strip(duplicate.Gender ?? "")) ? CHECK_MARK : string.Empty;
        }

        public static BindingList<Person> ReportableDuplicatePersons(U3ADbContext dbc) {
            BindingList<Person> result = new BindingList<Person>();
            List<Person> persons;
            List<DuplicatePerson> duplicates = new List<DuplicatePerson>();
            persons = dbc.Person.AsNoTracking().ToList();

            foreach (var p in persons) {
                var d = duplicates.Where(x => strip(x.LastName) == strip(p.LastName) &&
                                        strip(x.FirstName) == strip(p.FirstName)).FirstOrDefault();
                if (d == null) {
                    d = new DuplicatePerson() { FirstName = p.FirstName, LastName = p.LastName };
                    duplicates.Add(d);
                }
                d.Persons.Add(p);
            }
            foreach (var d in duplicates.Where(x => x.Persons.Count > 1)) {
                foreach (var p in d.Persons) {
                    result.Add(p);
                }
            }
            return result;
        }
    }
}


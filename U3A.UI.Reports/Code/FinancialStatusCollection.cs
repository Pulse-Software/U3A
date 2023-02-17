using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U3A.Database;
using U3A.Database.Migrations.U3ADbContextSeedMigrations;

namespace U3A.UI.Reports
{
    internal class FinancialStatusCollection : Dictionary<int,string>
    {
        public void BuildList(U3ADbContext dbc) {
            var term = dbc.Term.Where(x => x.IsDefaultTerm).FirstOrDefault();
            if (term != null) {
                foreach (var year in dbc.Person
                                    .Where(x => x.FinancialTo != null && x.FinancialTo >= term.Year)
                                    .OrderByDescending(x => x.FinancialTo)
                                    .Select(x => x.FinancialTo).Distinct()) { 
                  Add(year, $"Financial Members as at {year}");
                }
                Add(int.MaxValue-1,$"Unfinancial Members as at {term.Year}");
                Add(int.MaxValue,$"Ignore Financial Status");
            }
        }
    }
}

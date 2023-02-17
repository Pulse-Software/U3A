using System;
using System.Collections.Generic;
using System.Linq;
using U3A.Model;
using U3A.Database;
using U3A.Services;
using U3A.BusinessRules;
using Microsoft.EntityFrameworkCore;

namespace U3A.UI.Reports
{
    public class ReportRepository
    {

        readonly IScopedDbContextProvider<U3ADbContext> scopedDbContextProvider;
        readonly IDbContextFactory<U3ADbContext> U3Adbfactory;

        public ReportRepository() {
        }

        // Used by the report designer
        public ReportRepository(IScopedDbContextProvider<U3ADbContext> scopedDbContextProvider) {
            this.scopedDbContextProvider = scopedDbContextProvider ?? throw new ArgumentNullException(nameof(scopedDbContextProvider));
        }

        public ReceiptDetail GetReceiptDetailSample() {
            using (var dbContextScope = scopedDbContextProvider.GetDbContextScope()) {
                var dbContext = dbContextScope.DbContext;
                return BusinessRule.GetCashReceiptsSample(dbContext);
            }
        }
        public List<EnrolmentDetail> GetEnrolmentDetailSample() {
            using (var dbContextScope = scopedDbContextProvider.GetDbContextScope()) {
                var dbContext = dbContextScope.DbContext;
                return BusinessRule.GetEnrolmentSample(dbContext);
            }
        }

        private List<EnrolmentDetail> leaderEnrolments;
        public List<EnrolmentDetail> GetLeaderEnrolmentsSample {
            get {
                if (leaderEnrolments == null) { GetLeaderDetailSample(); }
                return leaderEnrolments;
            }
        }

        public List<LeaderDetail> GetLeaderDetailSample() {
            using (var dbContextScope = scopedDbContextProvider.GetDbContextScope()) {
                var dbContext = dbContextScope.DbContext;
                return BusinessRule.GetLeaderDetailSample(dbContext, out leaderEnrolments);
            }
        }
    }
}

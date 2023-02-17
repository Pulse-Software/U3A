using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DevExpress.DataAccess.Web;

namespace U3A.UI.Reports {
    public class ObjectDataSourceWizardTypeProvider : IObjectDataSourceWizardTypeProvider {
        public IEnumerable<Type> GetAvailableTypes(string context) {
            return new[] {
                typeof(ReportRepository)
            };
        }
    }

    public class ObjectDataSourceConstructorFilterService : IObjectDataSourceConstructorFilterService {
        readonly IObjectDataSourceWizardTypeProvider wizardTypeProvider;

        public ObjectDataSourceConstructorFilterService(IObjectDataSourceWizardTypeProvider wizardTypeProvider) {
            this.wizardTypeProvider = wizardTypeProvider ?? throw new ArgumentNullException(nameof(wizardTypeProvider));
        }

        public IEnumerable<ConstructorInfo> Filter(Type dataSourceType, IEnumerable<ConstructorInfo> constructors) {
            if(wizardTypeProvider.GetAvailableTypes(null).Contains(dataSourceType)) {
                return constructors.Where(x => !x.GetParameters().Any());
            }

            return constructors;
        }
    }
}

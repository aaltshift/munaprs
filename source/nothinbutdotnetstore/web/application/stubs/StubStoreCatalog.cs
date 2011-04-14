using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.stubs
{
    public class StubStoreCatalog : ICanFindInformationInTheStoreCatalog
    {
        public IEnumerable<ViewMainDepartmentModel> get_the_main_departments_in_the_store()
        {
            return Enumerable.Range(1, 100).Select(x => new ViewMainDepartmentModel{name = x.ToString("Main Department 0")});
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.stubs
{
    using System;

    public class StubStoreCatalog : ICanFindInformationInTheStoreCatalog
    {
        public IEnumerable<DepartmentModel> get_the_main_departments_in_the_store()
        {
            return Enumerable.Range(1, 100).Select(x => new DepartmentModel{name = x.ToString("Main Department 0")});
        }

        public IEnumerable<DepartmentModel> get_departments_in_a_department(DepartmentModel department)
        {
            throw new NotImplementedException();
        }
    }
}
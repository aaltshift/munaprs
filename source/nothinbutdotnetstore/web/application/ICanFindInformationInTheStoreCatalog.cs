using System.Collections.Generic;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public interface ICanFindInformationInTheStoreCatalog
    {
        IEnumerable<ViewMainDepartmentModel> get_the_main_departments_in_the_store();
    }
}
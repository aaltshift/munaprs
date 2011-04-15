using nothinbutdotnetstore.web.application.models;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class ViewTheDepartmentsInADepartment : IEncapsulateApplicationSpecificFunctionality
    {
        ICanFindInformationInTheStoreCatalog store_catalog;
        ICanDisplayReportModels response_engine;

        public ViewTheDepartmentsInADepartment(ICanFindInformationInTheStoreCatalog store_catalog, ICanDisplayReportModels response_engine)
        {
            this.store_catalog = store_catalog;
            this.response_engine = response_engine;
        }

        public void process(IContainRequestDetails request)
        {
            response_engine.display(store_catalog.get_the_sub_departments_in(request.map<DepartmentModel>()));
        }
    }
}
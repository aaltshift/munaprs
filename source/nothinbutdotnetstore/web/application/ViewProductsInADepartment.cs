using nothinbutdotnetstore.web.application.models;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class ViewProductsInADepartment : IEncapsulateApplicationSpecificFunctionality
    {
        IContainRequestDetails request_details;
        ICanFindInformationInTheStoreCatalog store_catalog;
        ICanDisplayReportModels response_engine;

        public ViewProductsInADepartment(IContainRequestDetails request_details,
                                         ICanFindInformationInTheStoreCatalog store_catalog,
                                         ICanDisplayReportModels response_engine)
        {
            this.request_details = request_details;
            this.response_engine = response_engine;
            this.store_catalog = store_catalog;
        }

        public void process(IContainRequestDetails request)
        {
            this.response_engine.display(store_catalog.get_the_products_in_department(request_details.map<DepartmentModel>()));
        }
    }
}
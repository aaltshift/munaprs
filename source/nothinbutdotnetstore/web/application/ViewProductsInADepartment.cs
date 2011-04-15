using nothinbutdotnetstore.stubs;
using nothinbutdotnetstore.web.application.models;
using nothinbutdotnetstore.web.application.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.asp;

namespace nothinbutdotnetstore.web.application
{
    public class ViewProductsInADepartment : IEncapsulateApplicationSpecificFunctionality
    {
        ICanFindInformationInTheStoreCatalog store_catalog;
        ICanDisplayReportModels response_engine;

        public ViewProductsInADepartment():this(Stub.a<StubStoreCatalog>(),
            new ResponseEngine())
        {
        }

        public ViewProductsInADepartment( ICanFindInformationInTheStoreCatalog store_catalog,
                                         ICanDisplayReportModels response_engine)
        {
            this.response_engine = response_engine;
            this.store_catalog = store_catalog;
        }

        public void process(IContainRequestDetails request)
        {
            this.response_engine.display(store_catalog.get_the_products_in_department(request.map<DepartmentModel>()));
        }
    }
}
using nothinbutdotnetstore.web.application.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application
{
    public class ViewMainDepartmentsInTheStore : IEncapsulateApplicationSpecificFunctionality
    {
        ICanDisplayReportModels response_engine;
        ICanFindInformationInTheStoreCatalog reporting_gateway;

        public ViewMainDepartmentsInTheStore():this(new StubResponseEngine(),
            new StubStoreCatalog())
        {
        }

        public ViewMainDepartmentsInTheStore(ICanDisplayReportModels response_engine,
                                             ICanFindInformationInTheStoreCatalog reporting_gateway)
        {
            this.response_engine = response_engine;
            this.reporting_gateway = reporting_gateway;
        }

        public void process(IContainRequestDetails request)
        {
            response_engine.display(reporting_gateway.get_the_main_departments_in_the_store());
        }
    }
}
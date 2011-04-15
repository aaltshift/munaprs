using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.asp;

namespace nothinbutdotnetstore.web.application
{
    public class ViewReadModel<ReportModel> : IEncapsulateApplicationSpecificFunctionality
    {
        Query<ReportModel> query;
        ICanDisplayReportModels response_engine;

        public ViewReadModel(Query<ReportModel> query) : this(query,
                                                              new ResponseEngine())
        {
        }

        public ViewReadModel(Query<ReportModel> query,
                             ICanDisplayReportModels response_engine)
        {
            this.query = query;
            this.response_engine = response_engine;
        }

        public void process(IContainRequestDetails request)
        {
            response_engine.display(query(request));
        }
    }
}
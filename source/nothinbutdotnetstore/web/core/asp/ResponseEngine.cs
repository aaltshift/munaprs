using System.Web;

namespace nothinbutdotnetstore.web.core.asp
{
    public class ResponseEngine : ICanDisplayReportModels
    {
        ICreateViewsBoundToReportModels view_factory;
        CurrentContextResolver current_context;

        public ResponseEngine():this(new ViewFactory(),
            () => HttpContext.Current)
        {
        }

        public ResponseEngine(ICreateViewsBoundToReportModels view_factory, CurrentContextResolver current_context)
        {
            this.view_factory = view_factory;
            this.current_context = current_context;
        }

        public void display<ReportModel>(ReportModel report_model)
        {
            view_factory.create_view_to_display(report_model).ProcessRequest(current_context());
        }
    }
}
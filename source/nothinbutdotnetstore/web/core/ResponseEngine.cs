namespace nothinbutdotnetstore.web.core
{
    public class ResponseEngine : ICanDisplayReportModels
    {
        ICreateViewsBoundToReportModels view_factory;

        public ResponseEngine(ICreateViewsBoundToReportModels view_factory)
        {
            this.view_factory = view_factory;
        }

        public void display<ReportModel>(ReportModel report_model)
        {
            view_factory.create_view_to_display(report_model);
        }
    }
}
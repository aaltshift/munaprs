namespace nothinbutdotnetstore.web.core
{
    public interface ICreateViewsBoundToReportModels
    {
        void create_view_to_display<ReportModel>(ReportModel model);
    }
}
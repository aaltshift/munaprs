using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface ICreateViewsBoundToReportModels
    {
        IHttpHandler create_view_to_display<ReportModel>(ReportModel model);
    }
}
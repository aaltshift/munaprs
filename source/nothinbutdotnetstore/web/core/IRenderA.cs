using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface IRenderA<ReportModel> : IHttpHandler
    {
        ReportModel report_model { get; set; }
    }
}
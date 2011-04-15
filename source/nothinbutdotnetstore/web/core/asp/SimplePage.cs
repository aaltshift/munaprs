using System.Web.UI;

namespace nothinbutdotnetstore.web.core.asp
{
    public class SimplePage<ReportModel> : Page, IRenderA<ReportModel>
    {
        public ReportModel report_model { get; set; }
    }
}
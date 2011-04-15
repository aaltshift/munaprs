using System.Collections.Generic;
using nothinbutdotnetstore.web.application.models;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubViewPathRegistry : ICanResolveVirtualPathFromReportModel
    {
        public string get_path<ReportModel>()
        {
            if (typeof(ReportModel) == typeof(IEnumerable<DepartmentModel>)) return create_view_to("DepartmentBrowser");
            return create_view_to("ProductBrowser");
        }

        string create_view_to(string page)
        {
            return string.Format("~/views/{0}.aspx", page);
        }
    }
}
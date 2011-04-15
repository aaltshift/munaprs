using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class ViewFactory:ICreateViewsBoundToReportModels

    {
        ICanResolveVirtualPathFromReportModel resolve_path;

        public ViewFactory(ICanResolveVirtualPathFromReportModel resolvePath)
        {
            resolve_path = resolvePath;
        }

        public IHttpHandler create_view_to_display<ReportModel>(ReportModel model)
        {
            resolve_path.get_path<ReportModel>();

            return null;
        }
    }
}

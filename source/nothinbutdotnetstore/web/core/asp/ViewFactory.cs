using System.Web;
using System.Web.Compilation;
using nothinbutdotnetstore.stubs;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core.asp
{
    public class ViewFactory : ICreateViewsBoundToReportModels
    {
        ICanResolveVirtualPathFromReportModel path_registry;
        PageFactory page_factory;

        public ViewFactory():this(Stub.a<StubViewPathRegistry>(),BuildManager.CreateInstanceFromVirtualPath)
        {
        }

        public ViewFactory(ICanResolveVirtualPathFromReportModel path_registry, PageFactory page_factory)
        {
            this.path_registry = path_registry;
            this.page_factory = page_factory;
        }

        public IHttpHandler create_view_to_display<ReportModel>(ReportModel model)
        {
            var view =
                (IRenderA<ReportModel>)
                    page_factory(path_registry.get_path<ReportModel>(), typeof(IRenderA<ReportModel>));
            view.report_model = model;
            return view;
        }
    }
}
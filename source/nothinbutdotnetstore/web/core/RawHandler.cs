using System.Web;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    using nothinbutdotnetstore.stubs;

    public class RawHandler : IHttpHandler
    {
        IProcessIncomingWebRequests front_controller;

        ICreateRequests request_factory;

        public RawHandler():this(new FrontController(),
            Create.a<StubRequestFactory>())
        {
        }

        public RawHandler(IProcessIncomingWebRequests front_controller, ICreateRequests request_factory)
        {
            this.front_controller = front_controller;
            this.request_factory = request_factory;
        }

        public void ProcessRequest(HttpContext context)
        {
            this.front_controller.process(this.request_factory.create_request_from(context));
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}
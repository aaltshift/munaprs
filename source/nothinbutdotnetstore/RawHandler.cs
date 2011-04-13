using System;
using System.Web;

namespace nothinbutdotnetstore
{
    public class RawHandler : IHttpHandler
    {
        private readonly IProcessIncomingWebRequests processIncomingWebRequests;

        private readonly ICreateRequests createRequests;

        public RawHandler(IProcessIncomingWebRequests processIncomingWebRequests, ICreateRequests createRequests)
        {
            this.processIncomingWebRequests = processIncomingWebRequests;
            this.createRequests = createRequests;
        }

        public void ProcessRequest(HttpContext context)
        {
            var request = this.createRequests.create_request_from(context);
            this.processIncomingWebRequests.process(request);
        }

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }
    }
}
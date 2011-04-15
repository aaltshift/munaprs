using System;
using System.Web;

namespace nothinbutdotnetstore.specs.utility
{
    public class SomeFakeHandler : IHttpHandler
    {
        public HttpContext context;

        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
        }

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }
    }
}
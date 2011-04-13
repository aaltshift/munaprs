using System;
using System.Web;

namespace nothinbutdotnetstore
{
    public class RawHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }
    }
}
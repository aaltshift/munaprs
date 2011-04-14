using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface ICreateRequests
    {
        IContainRequestDetails create_request_from(HttpContext an_http_context);
    }
}
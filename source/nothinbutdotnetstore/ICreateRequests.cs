using System.Web;

namespace nothinbutdotnetstore
{
    public interface ICreateRequests
    {
        IContainRequestDetails create_request_from(HttpContext an_http_context);
    }
}
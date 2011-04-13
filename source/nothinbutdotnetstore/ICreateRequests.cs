using System.Web;

namespace nothinbutdotnetstore
{
    public interface ICreateRequests
    {
        object create_request_from(HttpContext an_http_context);
    }
}
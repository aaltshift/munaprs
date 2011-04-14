using System;
using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : ICreateRequests
    {
        public IContainRequestDetails create_request_from(HttpContext an_http_context)
        {
            return new StubRequestDetails();
        }

        class StubRequestDetails : IContainRequestDetails
        {

            public InputModel map<InputModel>()
            {
                object item = new DepartmentModel();
                return (InputModel) item;
            }
        }
    }
}
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.asp;

namespace nothinbutdotnetstore.web.application
{
    public class LazyRequest : IContainRequestDetails
    {
        ICreateRequests factory;
        CurrentContextResolver current;

        public LazyRequest(ICreateRequests factory, CurrentContextResolver current)
        {
            this.factory = factory;
            this.current = current;
        }

        public InputModel map<InputModel>()
        {
            return factory.create_request_from(current()).map<InputModel>();
        }
    }
}
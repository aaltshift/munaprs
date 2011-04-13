using System;

namespace nothinbutdotnetstore
{
    public class FrontController : IProcessIncomingWebRequests
    {
        private ICanFindCommandsThatCanProcessRequests command_registry;

        public FrontController(ICanFindCommandsThatCanProcessRequests command_registry)
        {
            this.command_registry = command_registry;
        }

        public void process(IContainRequestDetails the_request)
        {
            command_registry.get_the_command_that_can_handle(the_request).run_using(the_request);
        }
    }
}
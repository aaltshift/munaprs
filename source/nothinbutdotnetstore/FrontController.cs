using System;

namespace nothinbutdotnetstore
{
    public class FrontController : IProcessIncomingWebRequests
    {
        private readonly ICanFindCommandsThatCanProcessRequests command_registry;

        public FrontController(ICanFindCommandsThatCanProcessRequests command_registry)
        {
            this.command_registry = command_registry;
        }

        public void process(IContainRequestDetails the_request)
        {
            var command = this.command_registry.get_the_command_that_can_handle(the_request);
            command.run_using(the_request);
        }
    }
}
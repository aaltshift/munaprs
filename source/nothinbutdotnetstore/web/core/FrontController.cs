namespace nothinbutdotnetstore.web.core
{
    public class FrontController : IProcessIncomingWebRequests
    {
        ICanFindCommandsThatCanProcessRequests command_registry;

        public FrontController() : this(new CommandRegistry())
        {
        }

        public FrontController(ICanFindCommandsThatCanProcessRequests command_registry)
        {
            this.command_registry = command_registry;
        }

        public void process(IContainRequestDetails the_request)
        {
            command_registry.get_the_command_that_can_handle(the_request).process(the_request);
        }
    }
}
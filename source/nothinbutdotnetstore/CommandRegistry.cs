using System;

namespace nothinbutdotnetstore
{
    public class CommandRegistry : ICanFindCommandsThatCanProcessRequests
    {
        public ICanProcessOneUniqueRequest get_the_command_that_can_handle(IContainRequestDetails request)
        {
            throw new NotImplementedException();
        }
    }
}
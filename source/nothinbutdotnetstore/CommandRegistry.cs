using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore
{
    public class CommandRegistry : ICanFindCommandsThatCanProcessRequests
    {
        private readonly IEnumerable<ICanProcessOneUniqueRequest> allCommands;

        public CommandRegistry(IEnumerable<ICanProcessOneUniqueRequest> allCommands)
        {
            this.allCommands = allCommands;
        }

        public ICanProcessOneUniqueRequest get_the_command_that_can_handle(IContainRequestDetails request)
        {
            foreach (var canProcessOneUniqueRequest in allCommands)
            {
                if (canProcessOneUniqueRequest.can_process(request))
                    return canProcessOneUniqueRequest;
            }

            return null;
        }
    }
}
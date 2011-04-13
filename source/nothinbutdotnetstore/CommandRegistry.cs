using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore {
    public class CommandRegistry : ICanFindCommandsThatCanProcessRequests {
        readonly IEnumerable<ICanProcessOneUniqueRequest> all_commands;

        public CommandRegistry(IEnumerable<ICanProcessOneUniqueRequest> allCommands) {
            this.all_commands = allCommands;
        }

        public ICanProcessOneUniqueRequest get_the_command_that_can_handle(IContainRequestDetails request) {
            return all_commands.First(x => x.can_process(request));
        }
    }
}
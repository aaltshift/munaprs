using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore {
    public class CommandRegistry : ICanFindCommandsThatCanProcessRequests {
        readonly IEnumerable<ICanProcessOneUniqueRequest> all_commands;
        private MissingCommandFactory missingCommandFactory;

        public CommandRegistry(IEnumerable<ICanProcessOneUniqueRequest> allCommands, MissingCommandFactory missingCommandFactory) {
            this.all_commands = allCommands;
            this.missingCommandFactory = missingCommandFactory;
        }

        public ICanProcessOneUniqueRequest get_the_command_that_can_handle(IContainRequestDetails request) {

            ICanProcessOneUniqueRequest command = all_commands.FirstOrDefault(x => x.can_process(request));
            return command ?? missingCommandFactory();
        }

    }
}
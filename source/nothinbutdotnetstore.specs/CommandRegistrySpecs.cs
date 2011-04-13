using System.Collections.Generic;
using developwithpassion.specifications.moq;
using Machine.Specifications;
using Arg = Moq.It;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    public class CommandRegistrySpecs
    {
        public abstract class concern : Observes<ICanFindCommandsThatCanProcessRequests,
                                            CommandRegistry>
        {
        }

        [Subject(typeof(CommandRegistry))]
        public class when_finding_a_command_that_can_process_a_request : concern
        {
            Establish c = () =>
            {
                request = fake.an<IContainRequestDetails>();
                all_commands = new List<ICanProcessOneUniqueRequest>();
                depends.on<IEnumerable<ICanProcessOneUniqueRequest>>(all_commands);
            };

            Because b = () =>
                result = sut.get_the_command_that_can_handle(request);

            public class and_it_has_the_command : when_finding_a_command_that_can_process_a_request
            {
                Establish c1 = () =>
                {
                    the_command_that_can_handle_the_request = fake.an<ICanProcessOneUniqueRequest>();
                    all_commands.Add(the_command_that_can_handle_the_request);

                    the_command_that_can_handle_the_request.setup(x => x.can_process(request)).Return(true);
                };

                It should_return_the_command_to_the_caller = () =>
                    result.ShouldEqual(the_command_that_can_handle_the_request);

                static ICanProcessOneUniqueRequest the_command_that_can_handle_the_request;
            }

            static ICanProcessOneUniqueRequest result;
            static IContainRequestDetails request;
            protected static IList<ICanProcessOneUniqueRequest> all_commands;

        }
    }
}
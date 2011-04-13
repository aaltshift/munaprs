using System.Collections.Generic;
using System.Linq;
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
                depends.on<MissingCommandFactory>(() => null);
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

            public class and_it_does_not_have_the_command : when_finding_a_command_that_can_process_a_request
            {
                Establish c2 = () =>
                {
                    Enumerable.Range(1,100).each(x => all_commands.Add(fake.an<ICanProcessOneUniqueRequest>()));
                    the_special_case = fake.an<ICanProcessOneUniqueRequest>();
                    depends.on<MissingCommandFactory>(() => the_special_case);
                };

                It should_return_the_special_case = () =>
                    result.ShouldEqual(the_special_case);

                static ICanProcessOneUniqueRequest the_special_case;
            }
            protected static ICanProcessOneUniqueRequest result;
            protected static IContainRequestDetails request;
            protected static IList<ICanProcessOneUniqueRequest> all_commands;

        }
    }
}
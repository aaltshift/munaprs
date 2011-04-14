using developwithpassion.specifications.moq;
using Machine.Specifications;
using nothinbutdotnetstore.stubs;
using Arg = Moq.It;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    public class StubSpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(Stub))]
        public class when_creating_an_instance_of_a_stub_and_configuration_is_provided : concern
        {
            Establish c = () =>
            {
                options = () =>
                {
                    was_run = true;
                };
            };
            Because b = () =>
                result = Stub.a<ItemToStub>(options);

            It should_return_the_stub_instance = () =>
                result.ShouldBeAn<ItemToStub>();

            It should_execute_the_options = () =>
                was_run.ShouldBeTrue();



            static ItemToStub result;
            static StubOptions options;
            static bool was_run;
        }

        class ItemToStub
        {
        }
    }
}
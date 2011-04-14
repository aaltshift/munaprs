 using Machine.Specifications;
 using developwithpassion.specifications.moq;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.core;
 using Arg = Moq.It;

namespace nothinbutdotnetstore.specs
{   
    public class FrontControllerSpecs
    {
        public abstract class concern : Observes<IProcessIncomingWebRequests,
                                            FrontController>
        {
        
        }

        [Subject(typeof(FrontController))]
        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                command_registry = depends.on<ICanFindCommandsThatCanProcessRequests>();
                request_details = fake.an<IContainRequestDetails>();
                command_that_can_handle_the_request = fake.an<ICanProcessOneUniqueRequest>();

                command_registry.setup(x => x.get_the_command_that_can_handle(request_details)).Return(command_that_can_handle_the_request);
                
            };

            Because b = () =>
                sut.process(request_details);


            It should_delegate_the_processing_to_the_command_that_can_handle_the_request = () =>
                command_that_can_handle_the_request.received(x => x.process(request_details));

            static ICanProcessOneUniqueRequest command_that_can_handle_the_request;
            static IContainRequestDetails request_details;
            static ICanFindCommandsThatCanProcessRequests command_registry;
        }
    }
}

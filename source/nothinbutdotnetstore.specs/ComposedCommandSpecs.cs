 using System.Web.Configuration;
 using Machine.Specifications;
 using developwithpassion.specifications.moq;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.application;
 using Arg = Moq.It;

namespace nothinbutdotnetstore.specs
{   
    public class ComposedCommandSpecs
    {
        public abstract class concern : Observes<ICanProcessOneUniqueRequest    ,
                                            ComposedCommand>
        {
        
        }

        [Subject(typeof(ComposedCommand))]
        public class when_determining_if_it_can_process_a_request : concern
        {
            Establish c = () =>
            {
                request = fake.an<IContainRequestDetails>();
                depends.on<RequestCriteria>(x => true);
            };

            Because b = () =>
                result = sut.can_process(request);


            It should_make_the_determination_by_using_its_request_specification = () =>
                result.ShouldBeTrue();


            static bool result;
            static IContainRequestDetails request;
        }
        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                request = fake.an<IContainRequestDetails>();
                application_behaviour = depends.on<IEncapsulateApplicationSpecificFunctionality>();
            };

            Because b = () =>
                sut.process(request);



            It should_delegate_processing_to_the_application_behaviour = () =>
                application_behaviour.received(x => x.process(request));


            static bool result;
            static IContainRequestDetails request;
            static IEncapsulateApplicationSpecificFunctionality application_behaviour;
        }
    }
}

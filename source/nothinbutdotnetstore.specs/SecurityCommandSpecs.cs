 using Machine.Specifications;
 using developwithpassion.specifications.moq;
 using developwithpassion.specifications.extensions;
 using Arg = Moq.It;

namespace nothinbutdotnetstore.specs
{
    using System.Security;

    using nothinbutdotnetstore.web.core;

    public class SecurityCommandSpecs
    {
        public abstract class concern : Observes<IEncapsulateApplicationSpecificFunctionality,
                                            SecurityCommand>
        {
        
        }

        [Subject(typeof(SecurityCommand))]
        public class when_run : concern
        {
            private Establish c = () =>
                {
                    result = false;
                    depends.on<ICheckWhetherAUserIsEligible>(() => result = true);
                    the_request = fake.an<IContainRequestDetails>();
                };
            
            Because b = () => sut.process(the_request);

            It should_call_the_security_check = () => result.ShouldBeTrue();

            static IContainRequestDetails the_request;
            static bool result;
            static ICheckWhetherAUserIsEligible security_check;
        }
    }
}

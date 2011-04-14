using System.Web;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;
using Machine.Specifications;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using Arg = Moq.It;

namespace nothinbutdotnetstore.specs
{
    public class ViewMainDepartmentsInTheStoreSpecs
    {
        public abstract class concern : Observes<IEncapsulateApplicationSpecificFunctionality,
                                            ViewMainDepartmentsInTheStore>
        {
        }

        [Subject(typeof(ViewMainDepartmentsInTheStore))]
        public class when_observation_name : concern
        {
            private Establish e = () =>
                                  {
                                      sendsResponse = depends.on<ICanSendHttpResponse>();
                                      var requestProcessor = depends.on<ICanProcessViewMainDeparmentsRequest>();
                                      requestProcessor.setup(x => x.process(request_details)).Return(view_main_departmens_response);
                                  };

            Because b = () =>
                                sut.process(request_details);

            It should_send_http_response = () =>
                                                                        sendsResponse.received(
                                                                            x =>
                                                                            x.SendResponse(view_main_departmens_response));

            private static ICanSendHttpResponse sendsResponse;
            private static HttpResponse view_main_departmens_response;
            private static IContainRequestDetails request_details;
        }
    }

    
}
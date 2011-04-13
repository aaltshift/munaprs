using System.Web;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;
using Machine.Specifications;
using nothinbutdotnetstore.specs.utility;
using Arg = Moq.It;

namespace nothinbutdotnetstore.specs
{
    public class RawHandlerSpecs
    {
        public abstract class concern : Observes<IHttpHandler,
                                            RawHandler>
        {
        }

        [Subject(typeof(RawHandler))]
        public class when_processing_an_incoming_http_context : concern
        {
            Establish c = () =>
            {
                front_controller = depends.on<IProcessIncomingWebRequests>();
                request_factory = depends.on<ICreateRequests>();
                the_request = fake.an<IContainRequestDetails>();
                an_http_context = ObjectFactory.create_http_context();

                request_factory.setup(x => x.create_request_from(an_http_context)).Return(the_request);
            };

            Because b = () =>
                sut.ProcessRequest(an_http_context);

            It should_delegate_the_processing_to_the_front_controller = () =>
                front_controller.received(x => x.process(the_request));

            static IProcessIncomingWebRequests front_controller;
            static IContainRequestDetails the_request;
            static HttpContext an_http_context;
            static ICreateRequests request_factory;
        }
    }
}
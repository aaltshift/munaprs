using System.Web;

using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;
using Machine.Specifications;

using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class ICanDisplayReportModelsSpecs
    {
        public abstract class concern : Observes<ICanDisplayReportModels,
                                        ResponseEngine>
        {
        }

        [Subject(typeof(ResponseEngine))]
        public class when_displaying_a_report_model : concern
        {
            Establish c = () =>
            {
                context = ObjectFactory.create_http_context();
                report_model = new TestModel();
                view = fake.an<IHttpHandler>();
                view_factory = depends.on<ICreateViewsBoundToReportModels>();
                view_factory.setup(x => x.create_view_to_display(report_model)).Return(view);

                depends.on(context);
            };

            Because of = () => sut.display(report_model);

            It should_use_the_view_factory_to_create_a_physical_view_for_the_model =
                () => view_factory.received(x => x.create_view_to_display(report_model));

            It should_request_view_location =
                () => view.received(x => view.ProcessRequest(context));

            static IHttpHandler view;
            static HttpContext context;
            static TestModel report_model;
            static ICreateViewsBoundToReportModels view_factory;

            class TestModel
            {
            }
        }
    }
}
using System;
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
                the_currently_active_context = ObjectFactory.create_http_context();
                depends.on<CurrentContextResolver>(() => the_currently_active_context);
                report_model = new TestModel();
                view = new SomeFakeHandler();

                view_factory = depends.on<ICreateViewsBoundToReportModels>();
                view_factory.setup(x => x.create_view_to_display(report_model)).Return(view);
            };

            Because of = () => sut.display(report_model);

            It should_use_the_view_factory_to_create_a_physical_view_for_the_model =
                () => view_factory.received(x => x.create_view_to_display(report_model));

            It should_tell_view_to_process_request =
                () =>
                    view.context.ShouldEqual(the_currently_active_context);

            static SomeFakeHandler view;
            static HttpContext the_currently_active_context;
            static TestModel report_model;
            static ICreateViewsBoundToReportModels view_factory;

            class TestModel
            {
            }

            class SomeFakeHandler : IHttpHandler
            {
                public HttpContext context;

                public void ProcessRequest(HttpContext context)
                {
                    this.context = context;
                }

                public bool IsReusable
                {
                    get { throw new NotImplementedException(); }
                }
            }
        }
    }
}
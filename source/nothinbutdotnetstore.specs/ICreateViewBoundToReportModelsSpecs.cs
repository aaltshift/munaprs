using System;
using System.Web;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;
using Machine.Specifications;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class ICreateViewBoundToReportModels
    {
        public abstract class concern : Observes<ICreateViewsBoundToReportModels,
                                            ViewFactory>
        {
        }

        [Subject(typeof(ViewFactory))]
        public class when_creating_a_view_from_a_report_model : concern
        {
            Establish c = () =>
            {
                report_model = new TestModel();
                virtual_path_provider = depends.on<ICanResolveVirtualPathFromReportModel>();
            };

            Because of = () => 
                sut.create_view_to_display(report_model);

            It should_use_virtual_path_provider_to_get_the_path =
                () => virtual_path_provider.received(x => x.get_path<TestModel>());

            static TestModel report_model;
            static ICanResolveVirtualPathFromReportModel virtual_path_provider;

            class TestModel
            {
            }
        }
    }
}
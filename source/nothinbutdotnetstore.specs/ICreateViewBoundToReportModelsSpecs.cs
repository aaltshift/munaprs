using System;
using System.Web;
using System.Web.UI;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;
using Machine.Specifications;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.asp;

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
                view = new FakeView();
                the_path_to_the_real_page = "blah.aspx";
                path_registry = depends.on<ICanResolveVirtualPathFromReportModel>();

                path_registry.setup(x => x.get_path<TestModel>()).Return(the_path_to_the_real_page);
                depends.on<PageFactory>((page, type) =>
                {
                    path_requested = page;
                    type_requested = type;

                    return view;
                });
            };

            Because of = () =>
                result = sut.create_view_to_display(report_model);

            It should_use_virtual_path_provider_to_get_the_path =
                () => path_registry.received(x => x.get_path<TestModel>());

            It should_use_the_build_manager_to_create_the_page_using_the_correct_information = () =>
            {
                path_requested.ShouldEqual(the_path_to_the_real_page);
                type_requested.ShouldEqual(typeof(IRenderA<TestModel>));
            };

            It should_populate_the_view_with_its_report_model = () =>
                view.report_model.ShouldEqual(report_model);

            It should_return_the_view_to_the_caller = () =>
                result.ShouldEqual(view);

  

            static TestModel report_model;
            static ICanResolveVirtualPathFromReportModel path_registry;
            static string path_requested;
            static string the_path_to_the_real_page;
            static Type type_requested;
            static IRenderA<TestModel> view;
            static IHttpHandler result;

            public class TestModel
            {
            }

            public class FakeView : IRenderA<TestModel>
            {
                public TestModel report_model { get; set; }

                public void ProcessRequest(HttpContext context)
                {
                }

                public bool IsReusable
                {
                    get { return false; }
                }
            }
        }
    }
}
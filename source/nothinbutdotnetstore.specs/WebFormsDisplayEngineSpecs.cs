 using Machine.Specifications;
 using developwithpassion.specifications.moq;
 using developwithpassion.specifications.extensions;
 using Arg = Moq.It;

namespace nothinbutdotnetstore.specs
{
    using System;
    using System.Web;

    using nothinbutdotnetstore.web.core;

    public class WebFormsDisplayEngineSpecs
    {
        public abstract class concern : Observes<ICanDisplayReportModels,
                                            WebFormsDisplayEngine>
        {
        
        }

        [Subject(typeof(WebFormsDisplayEngine))]
        public class when_display : concern
        {
            Establish c = () =>
                {
                    view_registry = depends.on<ICanFindViewsThatCanDisplayReportModels>();

                    the_report_model = fake.an<object>();

                    view_registry.setup(x => x.get_the_view_name_that_can_display(the_report_model)).Return("view");
                };

            Because b = () => sut.display(the_report_model);

            private It should_call_the_getter_on_the_view_registry =
                () => { view_registry.get_the_view_name_that_can_display(the_report_model); };

            static object the_report_model;
            static ICanFindViewsThatCanDisplayReportModels view_registry;
            private static HttpContext http_context;
        }
    }

    public class WebFormsDisplayEngine : ICanDisplayReportModels
    {
        ICanFindViewsThatCanDisplayReportModels view_registry;

        public WebFormsDisplayEngine(ICanFindViewsThatCanDisplayReportModels view_registry)
        {
            this.view_registry = view_registry;
        }

        public void display<ReportModel>(ReportModel report_model)
        {
            string view_name = view_registry.get_the_view_name_that_can_display(report_model);
            // ...
        }
    }

    public interface ICanFindViewsThatCanDisplayReportModels
    {
        string get_the_view_name_that_can_display(object theReportModel);
    }
}

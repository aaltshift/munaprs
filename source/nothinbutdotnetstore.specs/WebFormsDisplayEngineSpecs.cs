 using Machine.Specifications;
 using developwithpassion.specifications.moq;
 using developwithpassion.specifications.extensions;
 using Arg = Moq.It;

namespace nothinbutdotnetstore.specs
{
    using System;

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
                    the_report_model = fake.an<object>();

                };

            Because b = () => sut.display(the_report_model);

            private It should_call_the_getter_on_the_view_registry =
                () => { view_registry.get_the_view_that_can_display(the_report_model); };

            static object the_report_model;
            static ICanFindViewsThatCanDisplayReportModels view_registry;
        }
    }

    public class WebFormsDisplayEngine : ICanDisplayReportModels
    {
        public void display<ReportModel>(ReportModel report_model)
        {
            throw new NotImplementedException();
        }
    }

    public interface ICanFindViewsThatCanDisplayReportModels
    {
        object get_the_view_that_can_display(object theReportModel);
    }
}

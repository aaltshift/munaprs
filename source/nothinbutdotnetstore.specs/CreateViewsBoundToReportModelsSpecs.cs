 using Machine.Specifications;
 using developwithpassion.specifications.moq;
 using developwithpassion.specifications.extensions;
 using Arg = Moq.It;

namespace nothinbutdotnetstore.specs
{
    using System;
    using System.Web;

    using nothinbutdotnetstore.specs.utility;
    using nothinbutdotnetstore.web.core;

    public class CreateViewsBoundToReportModelsSpecs
    {
        public abstract class concern : Observes<ICreateViewsBoundToReportModels,
                                            CreateViewsBoundToReportModels>
        {
        
        }

        [Subject(typeof(CreateViewsBoundToReportModels))]
        public class when_creating_a_view_with_a_valid_report_model_and_path : concern
        {
            Establish c = () =>
                {
                    the_report_model = fake.an<object>();
                };

            Because b = () => result = sut.create_view_to_display(the_report_model);

            It should_return_a_view = () => result.ShouldNotBeNull();
                
            static object the_report_model;
            static IHttpHandler result;
        }
    }

    public class CreateViewsBoundToReportModels : ICreateViewsBoundToReportModels
    {
        public IHttpHandler create_view_to_display<ReportModel>(ReportModel model)
        {
            throw new NotImplementedException();
        }
    }
}

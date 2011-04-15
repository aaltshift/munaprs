using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;
using Machine.Specifications;
using nothinbutdotnetstore.web.core;
using Arg = Moq.It;

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
                report_model = new TestModel();
                view_factory = depends.on<ICreateViewsBoundToReportModels>();
            };

            Because of = () => sut.display(report_model);

            It should_use_the_view_factory_to_create_a_physical_view_for_the_model =
                () => view_factory.received(x => x.create_view_to_display(report_model));

            static TestModel report_model;
            static ICreateViewsBoundToReportModels view_factory;


            class TestModel
            {
            }
        }}
}
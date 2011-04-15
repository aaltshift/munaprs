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
                view_finder = depends.on<ICanFindAPhysicalView>();
            };

            Because of = () => sut.display(report_model);

            It should_use_the_viewfinder_to_locate_a_physical_view_for_the_model =
                () => view_finder.received(x => x.find<TestModel>());

            static TestModel report_model;
            static ICanFindAPhysicalView view_finder;


            class TestModel
            {
            }
        }}
}
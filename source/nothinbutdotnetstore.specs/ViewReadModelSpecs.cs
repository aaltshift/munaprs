using System;
using System.Collections.Generic;

using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;
using Machine.Specifications;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using Arg = Moq.It;

namespace nothinbutdotnetstore.specs
{
    public class ViewReadModelSpecs
    {
        public abstract class concern : Observes<IEncapsulateApplicationSpecificFunctionality,
                                            ViewReadModel<Object>>
        {
        }

        [Subject(typeof(ViewReadModel<Object>))]
        public class when_run : concern
        {
            Establish e = () =>
                          {
                              read_model_accessor = depends.on<IReadModelAccessor<object>>();
                              response_engine = depends.on<ICanDisplayReportModels>();
                              request = depends.on<IContainRequestDetails>();
                              report_model = new object();

                              read_model_accessor.setup(x => x.get_read_model(request)).Return(report_model);
                          };

            private Because b = () =>
                                sut.process(request);

            private It should_display_the_read_model = () =>
                                                       response_engine.received(x => x.display(report_model));

            private It should_get_the_read_model = () =>
                                                   { };
              

            private static IReadModelAccessor<object> read_model_accessor;
            private static IContainRequestDetails request;
            private static ICanDisplayReportModels response_engine;
            private static object report_model;
        }

    }
}
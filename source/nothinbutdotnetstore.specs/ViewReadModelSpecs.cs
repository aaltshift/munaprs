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
                                            ViewReadModel<IEnumerable<Person>>>
        {
        }

        [Subject(typeof(ViewReadModel<IEnumerable<Person>>))]
        public class when_run : concern
        {
            Establish e = () =>
            {
                report_model = new List<Person>();
                depends.on<Query<IEnumerable<Person>>>(x => report_model);
                response_engine = depends.on<ICanDisplayReportModels>();
                request = depends.on<IContainRequestDetails>();
            };

            Because b = () =>
                sut.process(request);

            It should_display_the_read_model = () =>
                response_engine.received(x => x.display(report_model));


            static Query<IEnumerable<Person>> person_query;
            static IContainRequestDetails request;
            static ICanDisplayReportModels response_engine;
            static IEnumerable<Person> report_model;
        }

        public class Person
        {
        }
    }
}
using developwithpassion.specifications.moq;
using Machine.Specifications;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using Arg = Moq.It;

namespace nothinbutdotnetstore.specs
{
    using System.Collections.Generic;

    using developwithpassion.specifications.extensions;

    public class ViewDepartmentsInDepartmentSpecs
    {
        public abstract class concern : Observes<IEncapsulateApplicationSpecificFunctionality,
                                            ViewTheDepartmentsInADepartment>
        {
        }

        [Subject(typeof(ViewTheDepartmentsInADepartment))]
        public class when_run : concern
        {
            Establish e = () =>
            {
                the_departments = new List<DepartmentModel> { new DepartmentModel() };
                request_details = fake.an<IContainRequestDetails>();
                department = fake.an<DepartmentModel>();
                response_engine = depends.on<ICanDisplayReportModels>();
                reporting_gateway = depends.on<ICanFindInformationInTheStoreCatalog>();
                reporting_gateway.setup(x => x.get_departments_in_a_department(department)).Return(the_departments);
            };

            Because b = () =>
                sut.process(request_details);

            It should_tell_the_response_engine_to_display_the_model = () =>
                response_engine.received(x => x.display(the_departments));

            static ICanDisplayReportModels response_engine;
            static IContainRequestDetails request_details;
            static ICanFindInformationInTheStoreCatalog reporting_gateway;
            static IEnumerable<DepartmentModel> the_departments;
            static DepartmentModel department;
        }
    }
}
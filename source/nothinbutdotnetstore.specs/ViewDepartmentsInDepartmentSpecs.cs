using System.Collections.Generic;

using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;
using Machine.Specifications;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using Arg = Moq.It;

namespace nothinbutdotnetstore.specs
{
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
                department = fake.an<DepartmentModel>();
                the_sub_departments = new List<DepartmentModel> { new DepartmentModel() };
                request_details = fake.an<IContainRequestDetails>();
                response_engine = depends.on<ICanDisplayReportModels>();
                reporting_gateway = depends.on<ICanFindInformationInTheStoreCatalog>();
                reporting_gateway.setup(x => x.get_the_sub_departments_in_a_department(Arg.IsAny<DepartmentModel>())).Return(the_sub_departments);
                depends.on(department);
            };

            It should_tell_the_response_engine_to_display_the_model = () =>
                response_engine.received(x => x.display(the_sub_departments));

            It should_retrieve_the_departments_in_a_department = () =>
                reporting_gateway.received(x => x.get_the_sub_departments_in_a_department(department));

            static ICanDisplayReportModels response_engine;
            static IContainRequestDetails request_details;
            static ICanFindInformationInTheStoreCatalog reporting_gateway;
            static IEnumerable<DepartmentModel> the_sub_departments;
            static DepartmentModel department;
        }
    }
}
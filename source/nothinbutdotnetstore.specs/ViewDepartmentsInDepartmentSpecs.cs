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
                response_engine = depends.on<ICanDisplayReportModels>();
                parent_department = depends.on<DepartmentModel>();
                request_details = fake.an<IContainRequestDetails>();
                sub_departments = new List<DepartmentModel> {new DepartmentModel()};
                reporting_gateway = depends.on<ICanFindInformationInTheStoreCatalog>();
                reporting_gateway.setup(x => x.get_the_sub_departments_in(parent_department)).Return(sub_departments);

                request_details.setup(x => x.map<DepartmentModel>()).Return(parent_department);

            };

            Because b = () =>
                sut.process(request_details);


            It should_retrieve_the_departments_in_a_department = () =>
            {
            };

            It should_display_the_sub_departments = () =>
                response_engine.received(x => x.display(sub_departments));
  


            static IContainRequestDetails request_details;
            static ICanFindInformationInTheStoreCatalog reporting_gateway;
            static DepartmentModel parent_department;
            static ICanDisplayReportModels response_engine;
            static IEnumerable<DepartmentModel> sub_departments;
        }
    }
}
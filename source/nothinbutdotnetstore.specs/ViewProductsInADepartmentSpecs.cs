using System.Collections.Generic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;
using Machine.Specifications;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class ViewProductsInADepartmentSpecs
    {
        public abstract class concern : Observes<IEncapsulateApplicationSpecificFunctionality,
                                            ViewProductsInADepartment>
        {
        }

        [Subject(typeof(ViewProductsInADepartment))]
        public class when_run : concern
        {
            Establish e = () =>
            {
                request_details = depends.on<IContainRequestDetails>();
                store_catalog = depends.on<ICanFindInformationInTheStoreCatalog>();
                response_engine = depends.on<ICanDisplayReportModels>();
                department_with_products = fake.an<DepartmentModel>();
                products = fake.an<IEnumerable<ProductModel>>();

                request_details.setup(x => x.map<DepartmentModel>()).Return(department_with_products);

                store_catalog.setup(x => x.get_the_products_in_department(department_with_products)).Return(products);
            };

            Because b = () =>
                sut.process(request_details);

            It should_display_the_products = () =>
                response_engine.received(x => x.display(products));

            It should_try_to_get_the_products_for_the_department = () =>
            {
            };

            static IContainRequestDetails request_details;
            static ICanFindInformationInTheStoreCatalog store_catalog;
            static DepartmentModel department_with_products;
            static ICanDisplayReportModels response_engine;
            static IEnumerable<ProductModel> products;
        }
    }
}
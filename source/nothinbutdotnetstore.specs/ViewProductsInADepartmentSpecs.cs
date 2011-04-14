using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                              department = fake.an<DepartmentModel>();
                              products = fake.an<IEnumerable<ProductModel>>();

                              request_details.setup(x => x.map<DepartmentModel>()).Return(department);
                              store_catalog.setup(x => x.get_the_products_at_department(department)).Return(products);
                          };

            Because b = () =>
                sut.process(request_details);

            private It should_display_the_products = () =>
                                                     response_engine.received(x => x.display(products));

            private It should_try_to_get_the_products_for_the_department = () =>
                                                                           { };
                

            private static IContainRequestDetails request_details;
            private static ICanFindInformationInTheStoreCatalog store_catalog;
            private static DepartmentModel department;
            private static ICanDisplayReportModels response_engine;
            private static IEnumerable<ProductModel> products;
        }
    }
}

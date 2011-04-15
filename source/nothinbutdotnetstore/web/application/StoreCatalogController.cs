using System.Collections.Generic;
using nothinbutdotnetstore.web.application.models;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class StoreCatalogController
    {
        ICanFindInformationInTheStoreCatalog catalog;

        public StoreCatalogController(ICanFindInformationInTheStoreCatalog catalog)
        {
            this.catalog = catalog;
        }

        public IEnumerable<DepartmentModel> get_the_main_departments_in_the_store()
        {
            return catalog.get_the_main_departments_in_the_store();
        }

        public IEnumerable<DepartmentModel> get_the_sub_departments_in(DepartmentModel parent_department)
        {
            return catalog.get_the_sub_departments_in(parent_department);
        }

        public IEnumerable<ProductModel> get_the_products_in_department(DepartmentModel department)
        {
            return catalog.get_the_products_in_department(department);
        }
    }
}
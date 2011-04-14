using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class ViewProductsInADepartment : IEncapsulateApplicationSpecificFunctionality
    {
        private IContainRequestDetails request_details;
        private ICanFindInformationInTheStoreCatalog store_catalog;
        private ICanDisplayReportModels response_engine;

        public ViewProductsInADepartment(IContainRequestDetails requestDetails, ICanFindInformationInTheStoreCatalog storeCatalog, ICanDisplayReportModels responseEngine)
        {
            request_details = requestDetails;
            response_engine = responseEngine;
            store_catalog = storeCatalog;
        }

        public void process(IContainRequestDetails request)
        {
            response_engine.display(store_catalog.get_the_products_at_department(request_details.map<DepartmentModel>()));
        }
    }
}

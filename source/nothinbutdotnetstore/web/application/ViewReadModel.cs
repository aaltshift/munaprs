using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class ViewReadModel : IEncapsulateApplicationSpecificFunctionality
    {
        private IReadModelAccessor read_model_accessor;
        private ICanDisplayReportModels response_engine;

        public ViewReadModel(IReadModelAccessor read_model_accessor, ICanDisplayReportModels response_engine)
        {
            this.read_model_accessor = read_model_accessor;
            this.response_engine = response_engine;
        }

        public void process(IContainRequestDetails request)
        {
            response_engine.display(read_model_accessor.get_read_model(request));
        }
    }
}

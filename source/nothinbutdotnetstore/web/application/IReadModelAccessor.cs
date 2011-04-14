using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public interface IReadModelAccessor
    {
        object get_read_model(IContainRequestDetails request_details );
    }
}

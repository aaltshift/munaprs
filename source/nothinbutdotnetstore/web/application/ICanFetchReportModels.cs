using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public interface ICanProcessViewMainDeparmentsRequest
    {
        HttpResponse process(IContainRequestDetails viewDepartmentDetails);
    }
}

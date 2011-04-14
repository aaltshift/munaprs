using System;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class ViewMainDepartmentsInTheStore : IEncapsulateApplicationSpecificFunctionality
    {
        private readonly ICanSendHttpResponse _sendsResponse;
        private readonly ICanProcessViewMainDeparmentsRequest _canProcessViewMainDeparmentsRequest;

        public ViewMainDepartmentsInTheStore(ICanSendHttpResponse sendsResponse, ICanProcessViewMainDeparmentsRequest canProcessViewMainDeparmentsRequest)
        {
            _sendsResponse = sendsResponse;
            _canProcessViewMainDeparmentsRequest = canProcessViewMainDeparmentsRequest;
        }

        public void process(IContainRequestDetails request)
        {
            _sendsResponse.SendResponse(_canProcessViewMainDeparmentsRequest.process(request));
        }
    }
}
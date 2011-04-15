using System.Security;

namespace nothinbutdotnetstore.web.core
{

    public class SecurityCommand : IEncapsulateApplicationSpecificFunctionality
    {
        private IEncapsulateApplicationSpecificFunctionality inner_command;
        private ICheckWhetherAUserIsEligible security_check;

        public SecurityCommand(IEncapsulateApplicationSpecificFunctionality inner_command, ICheckWhetherAUserIsEligible security_check)
        {
            this.inner_command = inner_command;
            this.security_check = security_check;
        }

        public void process(IContainRequestDetails request)
        {
            security_check();
            inner_command.process(request);
        }
    }

    public delegate void ICheckWhetherAUserIsEligible();
}

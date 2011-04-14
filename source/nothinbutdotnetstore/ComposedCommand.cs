using nothinbutdotnetstore.application;

namespace nothinbutdotnetstore
{
    public class ComposedCommand : ICanProcessOneUniqueRequest
    {
        RequestCriteria criteria;
        IEncapsulateApplicationSpecificFunctionality application_command;

        public ComposedCommand(RequestCriteria criteria,
                               IEncapsulateApplicationSpecificFunctionality application_command)
        {
            this.criteria = criteria;
            this.application_command = application_command;
        }

        public void process(IContainRequestDetails request)
        {
            application_command.process(request);
        }

        public bool can_process(IContainRequestDetails request)
        {
            return criteria(request);
        }
    }
}
using nothinbutdotnetstore.application;

namespace nothinbutdotnetstore
{
    public interface ICanProcessOneUniqueRequest  : IEncapsulateApplicationSpecificFunctionality
    {
        bool can_process(IContainRequestDetails request);
    }
}
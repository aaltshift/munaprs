namespace nothinbutdotnetstore.web.core
{
    public interface ICanProcessOneUniqueRequest  : IEncapsulateApplicationSpecificFunctionality
    {
        bool can_process(IContainRequestDetails request);
    }
}
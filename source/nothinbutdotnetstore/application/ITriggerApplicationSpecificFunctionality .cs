namespace nothinbutdotnetstore.application
{
    public interface IEncapsulateApplicationSpecificFunctionality 
    {
        void process(IContainRequestDetails request);
    }
}
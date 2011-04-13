namespace nothinbutdotnetstore
{
    public interface ICanProcessOneUniqueRequest 
    {
        void run_using(IContainRequestDetails request);
    }
}
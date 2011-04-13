namespace nothinbutdotnetstore
{
    public interface IProcessIncomingWebRequests 
    {
        void process(IContainRequestDetails the_request);
    }
}
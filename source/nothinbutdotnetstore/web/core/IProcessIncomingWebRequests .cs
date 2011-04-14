namespace nothinbutdotnetstore.web.core
{
    public interface IProcessIncomingWebRequests 
    {
        void process(IContainRequestDetails the_request);
    }
}
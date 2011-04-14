namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubCommandFactory
    {
        public static ICanProcessOneUniqueRequest missing()
        {
            return new StubFakeMissingCommand();
        }

        class StubFakeMissingCommand : ICanProcessOneUniqueRequest
        {
            public void process(IContainRequestDetails request)
            {
            }

            public bool can_process(IContainRequestDetails request)
            {
                return false;
            }
        }
    }
}
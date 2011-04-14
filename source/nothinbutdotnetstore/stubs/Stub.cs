namespace nothinbutdotnetstore.stubs
{
    public class Stub
    {
        public static StubToCreate a<StubToCreate>() where StubToCreate : new()
        {
            return new StubToCreate();
        }
    }
}
using System.Linq;

namespace nothinbutdotnetstore.stubs
{
    public class Stub
    {
        public static StubToCreate a<StubToCreate>(params StubOptions[] options) where StubToCreate : new()
        {
            options.ToList().ForEach(x => x());
            return new StubToCreate();
        }
    }
}
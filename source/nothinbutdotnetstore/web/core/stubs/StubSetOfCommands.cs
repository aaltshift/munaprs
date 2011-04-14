using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubSetOfCommands : IEnumerable<ICanProcessOneUniqueRequest>
    {
        public IEnumerator<ICanProcessOneUniqueRequest> GetEnumerator()
        {
            yield return new ComposedCommand(x => true,
                                             new ViewMainDepartmentsInTheStore());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
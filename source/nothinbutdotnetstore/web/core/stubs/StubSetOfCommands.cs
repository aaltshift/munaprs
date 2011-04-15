using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.stubs;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.models;
using nothinbutdotnetstore.web.application.stubs;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubSetOfCommands : IEnumerable<ICanProcessOneUniqueRequest>
    {
        public IEnumerator<ICanProcessOneUniqueRequest> GetEnumerator()
        {
            var catalog = Stub.a<StubStoreCatalog>();

            yield return new ComposedCommand(x => true,
                                             new ViewReadModel<IEnumerable<DepartmentModel>>(
                                                 new GetTheMainDepartmentsInTheStore().run_using));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
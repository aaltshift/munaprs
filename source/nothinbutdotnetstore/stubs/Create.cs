using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetstore.stubs
{
    public class Create
    {
        public static TypeToCreate a<TypeToCreate>() where TypeToCreate : new()
        {
            return new TypeToCreate();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperLibrary
{
    public interface IMapperCache
    {
        void Add(MappingPair pair, Delegate function);
        Delegate GetCache (MappingPair pair);
        bool Contains(MappingPair pair);
    }
}

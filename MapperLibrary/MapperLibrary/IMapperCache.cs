using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperLibrary
{
    public interface IMapperCache
    {
        void Add<TSource, TDestination>(MappingPair pair, Func<TSource, TDestination> function);
        Func<TSource, TDestination> GetCache<TSource, TDestination>(MappingPair pair);
        bool Contains(MappingPair pair);
    }
}

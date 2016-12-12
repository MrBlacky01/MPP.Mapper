using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperLibrary
{
    class MapperCache  : IMapperCache
    {
        private readonly Dictionary<MappingPair, Delegate> _cache = new Dictionary<MappingPair, Delegate>();

        public void Add<TSource, TDestination>(MappingPair mappingInfo, Func<TSource, TDestination> mappingFunction)
        {
            _cache.Add(mappingInfo, mappingFunction);
        }

        public Func<TSource, TDestination> GetCache<TSource, TDestination>(MappingPair mappingInfo)
        {
            return (Func<TSource,TDestination>)_cache[mappingInfo];
        }

        public bool Contains(MappingPair mappingInfo)
        {
            return _cache.ContainsKey(mappingInfo);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperLibrary
{
    class MapperCache : IMapperCache
    {
        private readonly Dictionary<MappingPair, Delegate> _cache = new Dictionary<MappingPair, Delegate>();

        public void Add(MappingPair mappingInfo, Delegate mappingFunction)
        {
            _cache.Add(mappingInfo, mappingFunction);
        }

        public Delegate GetCache(MappingPair mappingInfo)
        {
            return _cache[mappingInfo];
        }

        public bool Contains(MappingPair mappingInfo)
        {
            return _cache.ContainsKey(mappingInfo);
        }
    }
}

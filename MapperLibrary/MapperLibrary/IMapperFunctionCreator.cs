using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperLibrary
{
    interface IMapperFunctionCreator
    {
        Func<TSource, TDestination> CreateFunction <TSource, TDestination>(IEnumerable<MappingPropertyInfoPair> properties)
            where TDestination : new();
    }
}

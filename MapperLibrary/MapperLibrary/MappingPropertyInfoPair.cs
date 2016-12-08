using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MapperLibrary
{
    public class MappingPropertyInfoPair
    {
        public PropertyInfo SourceProperty { get; private set; }
        public PropertyInfo DestinationProperty { get; private set; }

        public MappingPropertyInfoPair(PropertyInfo source, PropertyInfo destination)
        {
            SourceProperty = source;
            DestinationProperty = destination;
        }
    }
}

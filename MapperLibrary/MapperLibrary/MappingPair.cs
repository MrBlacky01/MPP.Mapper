using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperLibrary
{
    internal class MappingPair
    {
        public Type Source { get; set; }
        public Type Destination { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            var comparrigMappingElement = obj as MappingPair;
            return comparrigMappingElement != null && Equals(comparrigMappingElement);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 23 + (Source == null ? 0 : Source.GetHashCode());
                hash = hash * 23 + (Destination == null ? 0 : Destination.GetHashCode());
                return hash;
            }
        }

        protected bool Equals(MappingPair other)
        {
            return Source == other.Source && Destination == other.Destination;
        }
    }
}

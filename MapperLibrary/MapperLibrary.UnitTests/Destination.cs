using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperLibrary.UnitTests
{
    internal class Destination
    {
        public long FirstProperty { get; set; }
        public string SecondProperty { get; set; }
        public float ThirdProperty { get; set; }
        public DateTime FourthProperty { get; set; }
        public TempClass DtoTempClass { get; set; }
        

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this == obj) return true;
            var comparrigDestination = obj as Destination;
            return comparrigDestination != null && IsElementsEqual(comparrigDestination);
        }

        private bool IsElementsEqual(Destination obj)
        {
            return this.FirstProperty == obj.FirstProperty &&
                   this.SecondProperty == obj.SecondProperty &&
                   this.ThirdProperty == obj.ThirdProperty &&
                   this.FourthProperty == obj.FourthProperty &&
                   this.DtoTempClass == obj.DtoTempClass;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MapperLibrary.UnitTests
{
    [TestFixture]
    internal class MapperTest
    {
        private static readonly Source Source = new Source()
        {
            FirstProperty = 5,
            SecondProperty = "5",
            ThirdProperty = 5.0,
            FourthProperty = 5 ,
            DtoTempClass = new TempSubClass()
        };

        private static readonly Destination ExpectedDestination = new Destination()
        {
            FirstProperty = 5,
            SecondProperty = "5",
            DtoTempClass = Source.DtoTempClass
        };

        [Test]
        public void IsValidPatameter_Null_Exception()
        {
            Mapper mapper = new Mapper();

            Assert.Catch<ArgumentNullException>(() => mapper.Map<object, object>(null));
        }

        [Test]
        public void Mapping_SimpleMapping_Equal()
        {
            Mapper mapper = new Mapper();

            Destination dest = mapper.Map<Source, Destination>(Source);

            Assert.AreEqual(ExpectedDestination, dest);
        }

        [Test]
        public void Mapping_NoCompatibilityProperties_ReturnsEmpty()
        {
            Mapper mapper = new Mapper();

            Destination dest = mapper.Map<TempClass, Destination>(new TempClass() );

            Assert.AreEqual(new Destination(), dest);
        }

        [Test]
        public void Mapping_WithCache_Equals()
        {
            Mapper mapper = new Mapper();
            mapper.Map<Source, Destination>(Source);

            Destination temp = mapper.Map<Source, Destination>(Source);

            Assert.AreEqual(ExpectedDestination, temp);
        }



    }
}

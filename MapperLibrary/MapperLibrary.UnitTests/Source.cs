﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperLibrary.UnitTests
{
    internal class Source
    {
        public int FirstProperty { get; set; }
        public string SecondProperty { get; set; }
        public double ThirdProperty { get; set; }
        public short FourthProperty { get; set; }
        public TempClass DtoTempClass { get; set; }
    }
}

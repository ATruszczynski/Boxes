using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxesTest.Testing
{
    public class TestTuple
    {
        public int HowMany { get; set; }
        public int MinBoxCount { get; set; }
        public int MaxBoxCount { get; set; }
        public int MinW { get; set; }
        public int MaxW { get; set; }
        public int MinL { get; set; }
        public int MaxL { get; set; }

        public TestTuple(int howMany, int minBoxCount, int maxBoxCount, int minW, int maxW, int minL, int maxL)
        {
            HowMany = howMany;
            MinBoxCount = minBoxCount;
            MaxBoxCount = maxBoxCount;
            MinW = minW;
            MaxW = maxW;
            MinL = minL;
            MaxL = maxL;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxesTest
{
    class Box
    {
        public int width;
        public int height;
        public bool rotated = false;

        public Box(int w, int h)
        {
            width = w;
            height = h;
        }

        public void Invert()
        {
            int tmp = width;
            width = height;
            height = tmp;
            rotated = !rotated;
        }
    }
}

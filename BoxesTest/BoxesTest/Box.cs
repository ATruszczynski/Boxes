using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxesTest
{
    public class Box
    {
        public int width;
        public int height;
        public bool rotated = false;

        public Box(int w, int h)
        {
            width = w;
            height = h;
        }

        public void Rotate()
        {
            int tmp = width;
            width = height;
            height = tmp;
            rotated = !rotated;
        }
        public override string ToString()
        {
            return String.Format("Box is {0}rotated. width: {1} height: {2}", (rotated ? "not " : ""), width, height);
        }
    }
}

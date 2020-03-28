using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxesTest
{
    /// <summary>
    /// Class representing the single box. Box has width and length. Also can be rotated by 90 degrees.
    /// </summary>
    public class Box
    {
        public int width;
        public int length;
        public bool rotated = false;
        /// <summary>
        /// Constructor of Box
        /// </summary>
        /// <param name="w">width</param>
        /// <param name="l">length</param>
        public Box(int w, int l)
        {
            width = w;
            length = l;
        }
        /// <summary>
        /// Rotate Box by 90 degrees.
        /// </summary>
        public void Rotate()
        {
            int tmp = width;
            width = length;
            length = tmp;
            rotated = !rotated;
        }
        public override string ToString()
        {
            return String.Format("Box is {0}rotated, width: {1} height: {2}", (rotated ? "" : "not "), width, length);
        }
    }
}

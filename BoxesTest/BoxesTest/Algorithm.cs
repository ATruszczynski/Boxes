using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxesTest
{
    public static class BoxStackingAlgorithm
    {
        /// <summary>
        /// Function sets boxes so that they are in proper position, width>=height
        /// </summary>
        /// <param name="boxes">List of Boxes</param>
        /// <returns>List of boxes in the proper position</returns>
        static public List<Box> RotateBoxesToProper(List<Box> boxes)
        {
            for (int i = 0; i < boxes.Count; i++)
            {
                if(boxes[i].height>boxes[i].width)
                {
                    boxes[i].Rotate();
                }
            }
            return boxes;
        }
        /// <summary>
        /// Function sorts boxes firstly by width then by height
        /// </summary>
        /// <param name="boxes">list of all boxes that are in proper position (width>=height)</param>
        /// <returns>List of sorted boxes</returns>
        static public List<Box> SortBoxes(List<Box> boxes)
        {
            boxes.Sort((x, y) => { return x.width >= y.width ? true : (x.width < y.width ? false : x.height >= y.height});
            return boxes;
        }
        /// <summary>
        /// Function runs the whole algorithm
        /// </summary>
        /// <param name="boxes">List of all the boxes</param>
        /// <returns>List of stacked boxes</returns>
      static public  List<Box> Count(List<Box> boxes)
        {
            boxes = RotateBoxesToProper(boxes);
            boxes = SortBoxes(boxes);
            
            //gettables
            //getstack
            return new List<Box>();
        }

    }
}

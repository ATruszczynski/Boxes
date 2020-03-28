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
                if (boxes[i].length > boxes[i].width)
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
            //On average, this method is an O(n log n) operation, where n is Count; in the worst case it is an O(n ^ 2)
            boxes.Sort((x, y) => { return x.width > y.width ? -1 : (x.width < y.width ? 1 : (x.length >= y.length ? -1 : 1)); });
            return boxes;
        }
        /// <summary>
        /// Function counts the maximal number of boxes on stack.
        /// </summary>
        /// <param name="boxes">sorted list of boxes</param>
        /// <returns>number of boxes that can be put on top of each other on stack</returns>
        static public int CountHeight(List<Box> boxes)
        {
            // 0 means there is just one box, 1 that there is one box below
            int[] Heights = new int[boxes.Count];
            //O(n^2)
            for (int i = 1; i < boxes.Count; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    // checks wether you can put the ith box on the jth box
                    if (boxes[j].width >= boxes[i].width && boxes[j].length >= boxes[i].length)
                    {
//checks which of the stacks would be higher
                        Heights[i] = Math.Max(Heights[j] + 1, Heights[i]);
                    }
                }
            }
            //Max is O(n)
            return Heights.Max() + 1;

        }
        /// <summary>
        /// Function runs the whole algorithm
        /// </summary>
        /// <param name="boxes">List of all the boxes</param>
        /// <returns>List of stacked boxes</returns>
        static public List<Box> Count(List<Box> boxes)
        {
            boxes = RotateBoxesToProper(boxes);
            boxes = SortBoxes(boxes);
            Console.WriteLine(CountHeight(boxes));
            //gettables
            //getstack
            return boxes;
        }

    }
}

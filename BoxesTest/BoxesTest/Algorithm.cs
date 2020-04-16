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
            //boxes.Sort((x, y) => { return x.width > y.width ? -1 : (x.width < y.width ? 1 : (x.length >= y.length ? -1 : 1)); });
            boxes.Sort((x, y) => {
                int res = 0;

                if (x.width > y.width)
                    res = -1;
                if (x.width == y.width)
                    res = y.length.CompareTo(x.length);
                if (x.width < y.width)
                    res = 1;
                return res;
            });
            return boxes;
        }
        /// <summary>
        /// Function counts the maximal stack of boxes. Dynamic programming
        /// </summary>
        /// <param name="boxes">sorted list of boxes</param>
        /// <returns>number of boxes that can be put on top of each other on stack</returns>
        static public  List<Box> GetSequence(List<Box> boxes)
        {
            // 1 means there is just one box, 2 that there is one box below
            List<Box>[] Heights = new  List<Box>[boxes.Count];
            for (int i = 0; i < boxes.Count; i++)
            {
                Heights[i] =  new List<Box>() { boxes[i] };
            }
            //for (int i = 0; i < Heights.Length; i++)
            //{
            //    Console.WriteLine($"{Heights[i][0].width} {Heights[i][0].length}");
            //}
            //O(n^2)
            for (int i = 1; i < boxes.Count; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    // checks wether you can put the ith box on the jth box 
                    // and  if with you put ith box on the jth you could get higher than if you just have what you have
                    if (boxes[j].width >= boxes[i].width && boxes[j].length >= boxes[i].length && Heights[i].Count < Heights[j].Count + 1)
                    {
                        //add the ith element to the jth stack and keep it in ith stack.
                        Heights[i] = Heights[j].Concat(new List<Box>(){ boxes[i] }).ToList();
                    }
                }
            }
            //Max is O(n)
            return GetMax(Heights);
        }

        /// <summary>
        /// Finds the highest stack of boxes
        /// </summary>
        /// <param name="heights">table of stacks, heights[i] - stack of boxes that ith box is the highest</param>
        /// <returns>Maximum stack</returns>
       public static List<Box> GetMax(List<Box>[] heights)
        {
            List<Box> max = heights[0];
            for (int i = 1; i < heights.Length; i++)
            {
                if(heights[i].Count>max.Count)
                {
                    max = heights[i];
                }
            }
            return max;
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
            return GetSequence(boxes);
        }

    }
}

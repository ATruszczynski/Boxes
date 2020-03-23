using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>() { new Box(1,1),
                                                new Box(2,1),
                                                new Box(2,2),
                                                new Box(2,2),
                                                new Box(4,1),
                                                new Box(2,4),
                                                new Box(3,5),
                                                };

            var maxes = new int[boxes.Count];
            var previous = new int[boxes.Count];

            foreach (var box in boxes)
            {
                if (box.width > box.height)
                    box.Invert();
            }

            for(int i = 0; i < boxes.Count; i++)
            {
                int maxInd = -1;
                for (int j = 0; j <= i; j++)
                {
                    if(maxInd == -1 || (maxes[maxInd] < maxes[j] && boxes[j].width <= boxes[i].width && boxes[j].height <= boxes[j].height))
                    {
                        maxInd = j;
                    }
                }
                maxes[i] = maxes[maxInd] + 1;
                previous[i] = maxInd;
            }

            for (int i = 0; i < maxes.Length; i++)
            {
                Console.Write(maxes[i] + ", ");
            }
            Console.WriteLine();


            for (int i = 0; i < previous.Length; i++)
            {
                Console.Write(previous[i] + ", ");
            }
            Console.WriteLine();

        }
    }
}

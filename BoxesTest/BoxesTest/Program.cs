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
            //List<Box> boxes = new List<Box>() { new Box(1,1),
            //                                    new Box(2,1),
            //                                    new Box(2,2),
            //                                    new Box(2,2),
            //                                    new Box(4,1),
            //                                    new Box(2,4),
            //                                    new Box(3,5),
            //                                    };

            Console.WriteLine("how many boxes?");
            int n = Int32.Parse(Console.ReadLine());

            Console.WriteLine("give the dimensions of boxes");
            List<Box> boxes = new List<Box>();
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                var dimentions = line.Split(' ');
                boxes.Add(new Box(Int32.Parse(dimentions[0]), Int32.Parse(dimentions[1])));
            }


            var stackedBoxes = BoxStackingAlgorithm.Count(boxes);



            foreach (var box in stackedBoxes)
            {

            }

        }
    }
}

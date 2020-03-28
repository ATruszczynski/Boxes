using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxesTest
{
    class Program
    {
        static List<Box> ReadBoxes()
        {
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
            return boxes;
        }

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

            var boxes = ReadBoxes();

            Console.WriteLine("All Boxes:");
            foreach (var box in boxes)
            {
                Console.WriteLine($"{box}");
            }



            var stackedBoxes = BoxStackingAlgorithm.Count(boxes);


            Console.WriteLine("Solution:");
            foreach (var box in stackedBoxes)
            {
                Console.WriteLine($"{box}");
            }

        }
    }
}

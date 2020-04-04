using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxesTest
{
    class Program
    {
        /// <summary>
        /// Read from file
        /// </summary>
        /// <param name="path">path to the file with the boxes configuration</param>
        /// <returns></returns>
        static List<Box> ReadBoxesFromFile(string path)
        {
            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                List<Box> boxes = new List<Box>();
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var dimentions = line.Split(' ');
                    var w = Int32.Parse(dimentions[0]);
                    var l = Int32.Parse(dimentions[1]);
                    if (l <= 0 || w <= 0)
                    {
                        Console.WriteLine("Length or Width should be > 0!");
                        throw new Exception();
                    }
                    boxes.Add(new Box(w, l));
                }
                return boxes;
            }
            throw new Exception();
        }
        /// <summary>
        /// Reads the configuration from terminal
        /// </summary>
        /// <returns>List of Boxes</returns>
        static List<Box> ReadBoxes()
        {
            Console.WriteLine("how many boxes?");

            int n = Int32.Parse(Console.ReadLine());
            if (n < 1)
            {
                Console.WriteLine("Number of boxes should be>0!");
                throw new Exception();
            }
            Console.WriteLine("give the dimensions of boxes");
            List<Box> boxes = new List<Box>();
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                var dimentions = line.Split(' ');
                var w = Int32.Parse(dimentions[0]);
                var l = Int32.Parse(dimentions[1]);
                if (l <= 0 || w <= 0)
                {
                    Console.WriteLine("Length or Width should be > 0!");
                    throw new Exception();
                }
                boxes.Add(new Box(w, l));
            }
            return boxes;
        }
        static public void PrintTheBoxes(List<Box> boxes)
        {
            foreach (var box in boxes)
            {
                Console.WriteLine($"{box}");
            }
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Give the path to the file, if you want to write to terminal write: !T");
            var path = Console.ReadLine();
            List<Box> boxes;

            try
            {
                if (path == "!T")
                {
                    boxes = ReadBoxes();
                }
                else
                {
                    boxes = ReadBoxesFromFile(path);

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong format configuration of boxes!");
                return;
            }

            var stackedBoxes = BoxStackingAlgorithm.Count(boxes);


            Console.WriteLine($"Height of the solution: {stackedBoxes.Count}");
            Console.WriteLine("Solution:");
            PrintTheBoxes(stackedBoxes);
            Console.ReadLine();
        }
    }
}

using BoxesTest.Testing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace BoxesTest
{
    class Program
    {
        /// <summary>
        /// Read from file
        /// </summary>
        /// <param name="path">path to the file with the boxes configuration</param>
        /// <returns></returns>
        public static List<Box> ReadBoxesFromFile(string path)
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
            Console.WriteLine($"Boxes in solution {boxes.Count}");
            foreach (var box in boxes)
            {
                Console.WriteLine($"{box.width} {box.length}");
            }
        }
        static public void SaveSolutionToFile(List<Box> boxes, string path)
        {
            string dirName = Path.GetDirectoryName(path);
            string fileName = Path.GetFileName(path);

            path = dirName + Path.DirectorySeparatorChar + "out-" + fileName;
            var fileStream = new FileStream(path, FileMode.Create,  FileAccess.Write );
            using (var streamWritter = new StreamWriter(fileStream, Encoding.UTF8))
            {
                streamWritter.WriteLine($"{boxes.Count}");
                //Console.WriteLine($"{boxes.Count}");
                foreach (var box in boxes)
                {
                    streamWritter.WriteLine($"{box.width} {box.length}");
                    //Console.WriteLine($"{box.width} {box.length}");
                }
            }

        }


       


        static void Main(string[] args)
        {
            //TestGenerator.MakeTests(100, 100, 1000, 200, 200, "Tests", 1001, true);
            //Tester.Test("Tests", "TestResults", 10);

            Console.WriteLine("Give the path to the file, if you want to write to terminal write: !T");
            var path = Console.ReadLine();
            List<Box> boxes;

            try
            {
                if (path == "!T")
                {
                    var d = DateTime.Now;
                    path = $"./manual_test_{d.Hour}_{d.Minute}_{d.Second}.txt";
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
                Console.ReadKey();
                return;
            }

            var stackedBoxes = BoxStackingAlgorithm.Compute(boxes);

            Console.WriteLine("\nSolution:");
            PrintTheBoxes(stackedBoxes);
            Console.WriteLine();

            bool loop = true;

            while (loop)
            {
                Console.WriteLine("Do you want to save solution (y/n)?");
                string opt = Console.ReadLine();

                if (opt == "y")
                {
                    SaveSolutionToFile(stackedBoxes, path);
                    Console.WriteLine("Output file saved");
                    loop = false;
                }
                else if (opt == "n")
                {
                    Console.WriteLine("Output file not saved");
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Option not recognised");
                }
            }
            Console.ReadLine();
        }

    }
}

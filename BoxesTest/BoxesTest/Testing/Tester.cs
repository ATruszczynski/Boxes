using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace BoxesTest.Testing
{
    class Tester
    {
        static public int Rand = 20;
        static public void Test(string testDirPath, string resultDirPath, int repetitions)
        {
            var testFilesPaths = Directory.GetFiles(testDirPath, "*.txt");
            var outDir = Directory.CreateDirectory(resultDirPath);
            var now = DateTime.Now;
            string resultFilePath = $"{outDir.FullName}{Path.DirectorySeparatorChar}test_{now.Hour}_{now.Minute}_{now.Second}.csv";
            var resultFileStream = new StreamWriter(resultFilePath);
            resultFileStream.WriteLine("name,boxCount,meanWidth,stdDevWidth,meanLen,stdDevLen,meanArea,stdArea,cvArea,solutionCount,time");

            //Dictionary<string, List<Box>> tests = new Dictionary<string, List<Box>>();
            double totalJob = 0;

            Parallel.ForEach(testFilesPaths, testFilePath =>
            {
                var list = Program.ReadBoxesFromFile(testFilePath);
                totalJob += list.Count * list.Count;
            });

            double currentJob = 0;

            Random randmo = new Random();

            GC.Collect();

            Parallel.ForEach(testFilesPaths, new ParallelOptions() { MaxDegreeOfParallelism = 4 }, testFilePath => {

                var testBoxes = Program.ReadBoxesFromFile(testFilePath);
                var tmpBoxes = BoxStackingAlgorithm.RotateBoxesToProper(testBoxes);

                List<double> widths = new List<double>();
                List<double> lengths = new List<double>();
                List<double> areas = new List<double>();

                for (int i = 0; i < tmpBoxes.Count; i++)
                {
                    int wid = tmpBoxes[i].width;
                    int len = tmpBoxes[i].length;
                    widths.Add(wid);
                    lengths.Add(len);
                    areas.Add(wid * len);
                }

                double[] meanDevW = MeanAndDev(widths);
                double[] meanDevL = MeanAndDev(lengths);
                double[] meanDevA = MeanAndDev(areas);

                Stopwatch stopwatch = new Stopwatch();

                var result = new List<Box>();
                stopwatch.Start();
                for (int i = 0; i < repetitions; i++)
                {
                    result = BoxStackingAlgorithm.Compute(testBoxes);
                    GC.Collect();
                }
                stopwatch.Stop();
                var l = stopwatch.ElapsedMilliseconds / repetitions;
                lock (resultFileStream)
                {
                    resultFileStream.WriteLine($"{Path.GetFileName(testFilePath)},{testBoxes.Count},{meanDevW[0]},{meanDevW[1]},{meanDevL[0]},{meanDevL[1]},{meanDevA[0]},{meanDevA[1]},{meanDevA[1]/meanDevA[0]},{result.Count},{stopwatch.ElapsedMilliseconds / repetitions}");
                    resultFileStream.Flush();
                    currentJob += testBoxes.Count * testBoxes.Count;
                }


                if (randmo.Next(Rand) == 0)
                {
                    Console.WriteLine($"Tests completion: {Math.Round(currentJob / totalJob * 100, 4).ToString("#0.0000")} %");
                }
                
            });

            resultFileStream.Flush();
            resultFileStream.Close();
        }

        static string GetRoundedDot(double value, int deciamals = 2)
        {
            return Math.Round(value, 2).ToString("#0.00");
        }

        static double[] MeanAndDev(List<double> values)
        {
            double[] results = new double[2];

            results[0] = values.Average();

            double sumSquares = 0;

            foreach (var val in values)
            {
                sumSquares += Pow(val, 2);
            }

            double variance = sumSquares / values.Count - Pow(results[0], 2);

            results[1] = Sqrt(variance);

            return results;
        }
    }
}

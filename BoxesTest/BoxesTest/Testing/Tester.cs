using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using static System.Math;

namespace BoxesTest.Testing
{
    class Tester
    {
        static public void Test(string testDirPath, string resultDirPath, int repetitions)
        {
            var testFilesPaths = Directory.GetFiles(testDirPath, "*.txt");
            var outDir = Directory.CreateDirectory(resultDirPath);
            var now = DateTime.Now;
            string resultFilePath = $"{outDir.FullName}{Path.DirectorySeparatorChar}test_{now.Hour}_{now.Minute}_{now.Second}.csv";
            var resultFileStream = new StreamWriter(resultFilePath);
            resultFileStream.WriteLine("name,boxCount,meanWidth,stdDevWidth,meanLen,stdDevLen,solutionCount,time");

            Dictionary<string, List<Box>> tests = new Dictionary<string, List<Box>>();
            double totalJob = 0;

            foreach (var testFilePath in testFilesPaths)
            {
                var list = Program.ReadBoxesFromFile(testFilePath);
                tests[testFilePath] = list;
                totalJob += list.Count * list.Count;
            }

            double currentJob = 0;
            foreach (var testFilePath in testFilesPaths)
            {
                var testBoxes = tests[testFilePath];
                var tmpBoxes = BoxStackingAlgorithm.RotateBoxesToProper(testBoxes);

                List<double> widths = new List<double>();
                List<double> lengths = new List<double>();

                for (int i = 0; i < tmpBoxes.Count; i++)
                {
                    widths.Add(tmpBoxes[i].width);
                    lengths.Add(tmpBoxes[i].length);
                }

                double[] meanDevW = MeanAndDev(widths);
                double[] meanDevL = MeanAndDev(lengths);

                Stopwatch stopwatch = new Stopwatch();

                var result = new List<Box>();

                stopwatch.Start();
                for (int i = 0; i < repetitions; i++)
                {
                    result = BoxStackingAlgorithm.Compute(testBoxes);
                }
                stopwatch.Stop();
                var l = stopwatch.ElapsedMilliseconds / repetitions;
                resultFileStream.WriteLine($"{Path.GetFileName(testFilePath)},{testBoxes.Count},{meanDevW[0]},{meanDevW[1]},{meanDevL[0]},{meanDevL[1]},{result.Count},{stopwatch.ElapsedMilliseconds / repetitions}");

                currentJob += testBoxes.Count * testBoxes.Count;
                Console.WriteLine($"Tests completion: {Math.Round(currentJob / totalJob * 100, 4).ToString("#0.0000")} %");
            }

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

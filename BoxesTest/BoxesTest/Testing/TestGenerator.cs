using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BoxesTest.Testing
{
    class TestGenerator
    {
        static Random Random { get; set; }
        static int TestNumber = 0;
        public static void GenerateTestsInFiles(int howMany, int minBoxCount, int maxBoxCount, int minW, int maxW, int minL, int maxL, string dirPath, int seed, bool appendTests)
        {
            var dir = Directory.CreateDirectory(dirPath);
            
            if(!appendTests)
            {
                foreach(var file in dir.GetFiles())
                {
                    file.Delete();
                }
            }

            for (int i = 0; i < howMany; i++)
            {
                var now = DateTime.Now;
                StreamWriter sw = new StreamWriter($"{dir.FullName}{Path.DirectorySeparatorChar}test_{now.Month}{now.Day}{now.Hour}{now.Minute}{now.Second}{now.Millisecond}_{++TestNumber}.txt");

                int boxCount = GetRandomInclusive(minBoxCount, maxBoxCount);
                if (boxCount == 0)
                    ;
                for (int j = 0; j < boxCount; j++)
                {
                    int w = GetRandomInclusive(minW, maxW);
                    int l = GetRandomInclusive(minL, maxL);

                    if (j != boxCount - 1)
                        sw.WriteLine($"{w} {l}");
                    else
                        sw.Write($"{w} {l}");
                }

                sw.Flush();
                sw.Close();
            }
        }

        static int GetRandomInclusive(int min, int max)
        {
            return Random.Next(min, max + 1);
        }

        static public List<TestTuple> GenerateKartesianTests(int howMany, List<int> minBoxCountList, List<int> maxBoxCountList, List<int> minWList, List<int> maxWList, List<int> minLList, List<int> maxLList)
        {
            List<TestTuple> result = new List<TestTuple>();

            for (int i = 0; i < minBoxCountList.Count; i++)
            {
                for (int j = 0; j < minWList.Count; j++)
                {
                    for (int k = 0; k < minLList.Count; k++)
                    {
                        result.Add(new TestTuple(howMany, minBoxCountList[i], maxBoxCountList[i], minWList[j], maxWList[j], minLList[k], maxLList[k]));
                    }
                }
            }

            return result;
        }

        static public List<int> GenerateRange(int minInc, int maxInc, int step = 1)
        {
            List<int> result = new List<int>();

            for(int number = minInc; number <= maxInc; number += step)
            {
                result.Add(number);
            }

            return result;
        }

        static public List<int> Repeat(int value, int repeats)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < repeats; i++)
            {
                result.Add(value);
            }

            return result;

        }

        //static public void MakeTests(string path, int seed, bool append)
        //{
        //    Random = new Random(seed);

        //    int howMany = 10;

        //    List<int> minBoxCount = GenerateRange(1, 4801, 400);
        //    List<int> maxBoxCount = GenerateRange(200, 5000, 400);
        //    List<int> minW = GenerateRange(1, 81, 20);
        //    List<int> maxW = GenerateRange(20, 100, 20);
        //    List<int> minL = GenerateRange(1, 81, 20);
        //    List<int> maxL = GenerateRange(20, 100, 20);

        //    minW.AddRange(GenerateRange(1, 61, 20));
        //    maxW.AddRange(GenerateRange(40, 100, 20));
        //    minW.AddRange(GenerateRange(1, 41, 20));
        //    maxW.AddRange(GenerateRange(60, 100, 20));
        //    minW.AddRange(GenerateRange(1, 21, 20));
        //    maxW.AddRange(GenerateRange(80, 100, 20));

        //    minL.AddRange(GenerateRange(1, 61, 20));
        //    maxL.AddRange(GenerateRange(40, 100, 20));
        //    minL.AddRange(GenerateRange(1, 41, 20));
        //    maxL.AddRange(GenerateRange(60, 100, 20));
        //    minL.AddRange(GenerateRange(1, 21, 20));
        //    maxL.AddRange(GenerateRange(80, 100, 20));



        //    List<TestTuple> testTuples = GenerateKartesianTests(howMany, minBoxCount, maxBoxCount, minW, maxW, minL, maxL);

        //    foreach(var test in testTuples)
        //    {
        //        GenerateTestsInFiles(test.HowMany, test.MinBoxCount, test.MaxBoxCount, test.MinW, test.MaxW, test.MinL, test.MaxL, path, seed, append);
        //    }
        //}

        static public void MakeTests(int amount, int lowerCount, int upperCount, int upperW, int upperL, string path, int seed, bool cleanUp = false)
        {
            Random = new Random(seed);

            if (cleanUp)
            {
                var dir = Directory.CreateDirectory(path);

                foreach (var files in dir.GetFiles())
                {
                    files.Delete();
                }
            }

            for (int i = 0; i < amount; i++)
            {
                int maxCount = GetRandomInclusive(lowerCount, upperCount);
                int minCount = GetRandomInclusive(lowerCount, maxCount);
                int maxW = GetRandomInclusive(1, upperW);
                int minW = GetRandomInclusive(1, maxW);
                int maxL = GetRandomInclusive(1, upperL);
                int minL = GetRandomInclusive(1, maxL);

                GenerateTestsInFiles(1, minCount, maxCount, minW, maxW, minL, maxL, path, seed, true);
            }
        }
    }
}

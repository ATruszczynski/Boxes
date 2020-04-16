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
        public static void GenerateTestsInFiles(int howMany, int minBoxCount, int maxBoxCount, int minW, int maxW, int minL, int maxL, string dirPath, int seed)
        {
            Random = new Random(seed);
            var dir = Directory.CreateDirectory(dirPath);

            for (int i = 0; i < howMany; i++)
            {
                StreamWriter sw = new StreamWriter($"{dir.FullName}{Path.DirectorySeparatorChar}test_{++TestNumber}.txt");

                int boxCount = GetRandomInclusive(minBoxCount, maxBoxCount);

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
    }
}

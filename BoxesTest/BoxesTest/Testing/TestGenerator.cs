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
        public static void GenerateTestsInFiles(int howMany, int minBoxCount, int maxBoxCount, int minW, int maxW, int minL, int maxL, string dirPath)
        {
            var dir = Directory.CreateDirectory(dirPath);

            for (int i = 0; i < howMany; i++)
            {
                StreamWriter sw = new StreamWriter($"{dir.FullName}{Path.DirectorySeparatorChar}test_{i+1}.txt");

                int boxCount = GetRandomInclusive(minBoxCount, maxBoxCount);

                for (int j = 0; j < boxCount; j++)
                {
                    int w = GetRandomInclusive(minW, maxW);
                    int l = GetRandomInclusive(minL, maxL);

                    sw.WriteLine($"{w} {l}");
                }

                sw.Flush();
            }
        }

        static int GetRandomInclusive(int min, int max)
        {
            if (Random == null)
                Random = new Random();

            return Random.Next(min, max + 1);
        }
    }
}

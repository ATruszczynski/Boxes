using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoxesTest.Testing;

namespace TestGenApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestGenerator.Random = new Random();
            int howMany = 0;
            int minBoxCount = 0;
            int maxBoxCount = 0;
            int minW = 0;
            int maxW = 0;
            int minL = 0;
            int maxL = 0;
            string dirPath = "./";

            bool loop = true;

            while (loop)
            {
                Console.WriteLine("Podaj liczbę testów do wygenerowania");
                loop = !int.TryParse(Console.ReadLine(), out howMany);
            }

            loop = true;

            while (loop)
            {
                Console.WriteLine("Podaj minimalną liczbę pudełek");
                loop = !int.TryParse(Console.ReadLine(), out minBoxCount);
            }

            loop = true;

            while (loop)
            {
                Console.WriteLine("Podaj maksymalną liczbę pudełek");
                loop = !int.TryParse(Console.ReadLine(), out maxBoxCount);
            }

            loop = true;

            while (loop)
            {
                Console.WriteLine("Podaj minimalną szerokość pudełek");
                loop = !int.TryParse(Console.ReadLine(), out minW);
            }

            loop = true;

            while (loop)
            {
                Console.WriteLine("Podej maksymalną szerokość pudełek");
                loop = !int.TryParse(Console.ReadLine(), out maxW);
            }

            loop = true;

            while (loop)
            {
                Console.WriteLine("Podaj minimalną długość pudełek");
                loop = !int.TryParse(Console.ReadLine(), out minL);
            }

            loop = true;

            while (loop)
            {
                Console.WriteLine("Podej maksymalną długość pudełek");
                loop = !int.TryParse(Console.ReadLine(), out maxL);
            }

            loop = true;

            while (loop)
            {
                Console.WriteLine("Podaj ścieżke do folderu, w którym testy mają być wygenerowane (folder zostanie stworzony, jeśli nie istnieje)");
                dirPath = Console.ReadLine();
                loop = string.IsNullOrEmpty(dirPath);
            }

            TestGenerator.GenerateTestsInFiles(howMany, minBoxCount, maxBoxCount, minW, maxW, minL, maxL, dirPath, 1001, false);
            Console.WriteLine("Tests generated");
            Console.ReadLine();
        }
    }
}

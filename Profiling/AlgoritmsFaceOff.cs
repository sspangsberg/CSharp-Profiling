using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Profiling
{
    public class AlgoritmsFaceOff
    {
        const int numberOfIterations = 100000;

        private static void Algorithm1()
        {
            string result = "";

            for (int i = 0; i < numberOfIterations; i++)
            {
                result += 'a';

            }
        }
        private static void Algorithm2()
        {
            StringBuilder sb = new StringBuilder();


            for (int i = 0; i < numberOfIterations; i++)
            {
                sb.Append('a');

            }

            string result = sb.ToString();
        }

        public static void StartShowOff()
        {            
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Algorithm1();
            sw.Stop();

            Console.WriteLine(sw.Elapsed);

            sw.Reset();
            sw.Start();
            Algorithm2();
            sw.Stop();

            Console.WriteLine(sw.Elapsed);
            Console.WriteLine("Ready...");
            Console.ReadLine();
        }
    }
}

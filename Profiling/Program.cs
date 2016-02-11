using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Profiling
{
    class Program
    {        
        static void Main(string[] args)
        {
            Start();
        }

        static void DisplaySimpleMemoryInfomation()
        {
            Console.WriteLine("Press escape key to stop");

            using (PerformanceCounter pc = new PerformanceCounter("Processor", "% Processor Time"))
            {
                string text = "Available Memory:";

                Console.Write(text);

                do
                {
                    while (!Console.KeyAvailable)
                    {
                        Console.Write(pc.RawValue);
                        Console.SetCursorPosition(text.Length, Console.CursorTop);
                    }
                }
                while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }

            Console.ReadLine();
        }


        static void TestCustomPerformanceCounters()
        {
            if (CreatePerformanceCounters())
            {
                Console.WriteLine("Created performance counters");
                Console.WriteLine("Please restart application");
                Console.ReadKey();
                return;
            }

            var totalOperationsCounter = new PerformanceCounter("MyCategory", "# operations executed", "", false);
            var operationsPerSecondCounter = new PerformanceCounter("MyCategory", "# operations / sec", "", false);

            totalOperationsCounter.Increment();
            operationsPerSecondCounter.Increment();
        }

        static bool CreatePerformanceCounters()
        {
            if (!PerformanceCounterCategory.Exists("MyCategory"))
            {
                CounterCreationDataCollection counters = new CounterCreationDataCollection
                {
                    new CounterCreationData("# operations executed","Total number of operations executed",PerformanceCounterType.NumberOfItems32),
                    new CounterCreationData("# operations / sec","Number of operations executed per second",PerformanceCounterType.RateOfCountsPerSecond32),
                };

                PerformanceCounterCategory.Create("MyCategory", "Sample category for Codeproject", counters);

                return true;
            }

            return false;
        }
               

        /// <summary>
        /// Displays menu and handles user input
        /// </summary>
        public static void Start()
        {
            int choice = -1;

            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("1: Profiling ShowOff Demo");
                Console.WriteLine("2: Simple Performance Counter (Memory) Demo");
                Console.WriteLine("3: Custom Performance Counters Demo");
                

                Console.WriteLine("0: EXIT");

                Console.Write("\nChose a number...");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        ResetConsole("Kører 'Profiling ShowOff Demo'...\n");
                        AlgoritmsFaceOff.StartShowOff();
                        break;
                    case 2:
                        ResetConsole("Kører 'Simple Performance Counter (Memory)'...\n");
                        DisplaySimpleMemoryInfomation();
                        break;
                    case 3:
                        ResetConsole("Kører 'Custom Performance Counters Demo'...\n");
                        TestCustomPerformanceCounters();
                        break;
                    
                    default:
                        break;
                }
            }
            while (choice != 0);

        }


        public static void ResetConsole(string text)
        {
            Console.Clear();
            Console.WriteLine(text);
        }
    }
}

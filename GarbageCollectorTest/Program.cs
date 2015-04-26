using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollectorTest
{
    class Program
    {
        /*
         * Concurrent
         * 704 ms
         * 
         * No Concurrent
         * 1518 ms
         * 
         * Background collecting is around two times faster. 
         */

        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 100; i++)
                {
                    string[] stringArray = new string[10000000];
                }
            }

            GC.Collect();

            stopWatch.Stop();
            Console.WriteLine("Elapsed={0}", stopWatch.ElapsedMilliseconds / 10);
            Console.ReadLine();
        }
    }
}

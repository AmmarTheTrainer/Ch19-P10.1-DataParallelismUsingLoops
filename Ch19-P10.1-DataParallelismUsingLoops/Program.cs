using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch19_P10._1_DataParallelismUsingLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ============== Parallel.For Loop ============== ");

            Stopwatch sw = new Stopwatch();
            sw.Reset();
            sw.Start();
            WaitCallback callback = new WaitCallback(PrintNumbers);

            //for (int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine("\n Loop Itertion Count = {0} , Thread ID = {1} ", i, Thread.CurrentThread.ManagedThreadId);
            //    PrintNumbers(1);
            //    Thread.Sleep(50);
            //}

            Parallel.For(1, 100, (i) =>
            {
                Console.WriteLine(" Loop Itertion Count = {0} , Thread ID = {1} ", i, Thread.CurrentThread.ManagedThreadId);
                PrintNumbers(1);
                Thread.Sleep(50);
            });

            sw.Stop();

            Console.WriteLine("\n Total Time : {0} ", sw.ElapsedTicks);
            Console.WriteLine(" Total Time ( Miliseconds ) : {0} ", sw.ElapsedMilliseconds);
            Console.WriteLine(" Total Time ( Seconds ) : {0} ", sw.ElapsedMilliseconds / 1000);

            Console.ReadLine();
        }

        private static void PrintNumbers(object obj)
        {
            Console.WriteLine(" Printing Numbers... ");

            for (int i = 1; i < 21; i++)
            {
                Console.Write(" " +i);
                Thread.Sleep(30);
            }
            Console.WriteLine();
        }
    }
}

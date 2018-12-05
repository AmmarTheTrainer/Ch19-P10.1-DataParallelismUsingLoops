using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//using System.
using System.Drawing;
using System.IO;

namespace Ch19_P10._1_DataParallelismUsingLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Parallel.For Loop

            //Console.WriteLine(" ============== Parallel.For Loop ============== ");

            //Stopwatch sw = new Stopwatch();
            //sw.Reset();
            //sw.Start();
            //WaitCallback callback = new WaitCallback(PrintNumbers);

            ////for (int i = 0; i < 100; i++)
            ////{
            ////    Console.WriteLine("\n Loop Itertion Count = {0} , Thread ID = {1} ", i, Thread.CurrentThread.ManagedThreadId);
            ////    PrintNumbers(1);
            ////    Thread.Sleep(50);
            ////}

            //Parallel.For(1, 100, (i) =>
            //{
            //    Console.WriteLine(" Loop Itertion Count = {0} , Thread ID = {1} ", 
            //                                i, Thread.CurrentThread.ManagedThreadId);
            //    PrintNumbers(1);
            //    Thread.Sleep(50);
            //});

            //sw.Stop();

            //Console.WriteLine("\n Total Time : {0} ", sw.ElapsedTicks);
            //Console.WriteLine(" Total Time ( Miliseconds ) : {0} ", sw.ElapsedMilliseconds);
            //Console.WriteLine(" Total Time ( Seconds ) : {0} ", sw.ElapsedMilliseconds / 1000);

            //Console.ReadLine();
            #endregion

            #region Parallel.ForEach Loop

            // A simple source for demonstration purposes. Modify this path as necessary.
            String[] files = System.IO.Directory.GetFiles(@"C:\Users\Ammar Shaukat\Pictures\Saved Pictures", "*.jpg");
            String newDir = @"C:\Users\Public\Pictures\Modified";
            System.IO.Directory.CreateDirectory(newDir);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();

            // Method signature: Parallel.ForEach(IEnumerable<TSource> source, Action<TSource> body)
            // Be sure to add a reference to System.Drawing.dll.
            Parallel.ForEach(files, (currentFile) =>
            {
                // The more computational work you do here, the greater 
                // the speedup compared to a sequential foreach loop.
                String filename = System.IO.Path.GetFileName(currentFile);
                Bitmap bitmap = new Bitmap(currentFile);

                bitmap.RotateFlip(RotateFlipType.Rotate90FlipY);
                bitmap.Save(Path.Combine(newDir, filename));

                // Peek behind the scenes to see how work is parallelized.
                // But be aware: Thread contention for the Console slows down parallel loops!!!

                Console.WriteLine("Processing {0} on thread {1}", filename, Thread.CurrentThread.ManagedThreadId);
                //close lambda expression and method invocation
            });



            //// Method signature: Parallel.ForEach(IEnumerable<TSource> source, Action<TSource> body)
            //// Be sure to add a reference to System.Drawing.dll.
            //foreach (var currentFile in files)
            //{
            //    // The more computational work you do here, the greater 
            //    // the speedup compared to a sequential foreach loop.
            //    String filename = System.IO.Path.GetFileName(currentFile);
            //    Bitmap bitmap = new Bitmap(currentFile);

            //    bitmap.RotateFlip(RotateFlipType.Rotate90FlipY);
            //    bitmap.Save(Path.Combine(newDir, filename));

            //    // Peek behind the scenes to see how work is parallelized.
            //    // But be aware: Thread contention for the Console slows down parallel loops!!!

            //    Console.WriteLine("Processing {0} on thread {1}", filename, Thread.CurrentThread.ManagedThreadId);
            //    //close lambda expression and method invocation
            //}

            stopwatch.Stop();
            Console.WriteLine(" Time ( miliseconds ) = {0} ",stopwatch.ElapsedMilliseconds);

            // Keep the console window open in debug mode.
            Console.WriteLine("Processing complete. Press any key to exit.");

            Console.ReadKey();

            #endregion

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

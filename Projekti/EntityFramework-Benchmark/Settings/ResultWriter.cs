using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Benchmark.Settings
{
    public class ResultWriter
    {
        public static void WriteHeader(string query)
        {
            Console.WriteLine("=================================================================");
            Console.WriteLine(" Query: " + query);
            Console.WriteLine(" ----------------------------------------------------------------");
        }

        public static void WriteFooter(int count)
        {
            Console.WriteLine(" Total number of records: " + count);

            Console.WriteLine(" Elapsed time: " + BStopwatch.ElapsedMilliseconds() + " ms.");
            Console.WriteLine("=================================================================");
        }

        public static void WriteElapsedTime(int i, long elapsedTime)
        {
            Console.WriteLine(i + ". Elapsed time for query: " + elapsedTime);
        }

        public static void WriteAverageFooter(double average)
        {
            Console.WriteLine(" Average elapsed time: " + Math.Round(average, 2) + "ms.");
            Console.WriteLine("=================================================================");
        }
    }
}

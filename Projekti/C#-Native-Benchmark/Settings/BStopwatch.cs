using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Settings
{
    public class BStopwatch
    {
        private static readonly System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

        public static void Start()
        {
            stopwatch.Reset();
            stopwatch.Start();
        }

        public static void Stop()
        {
            stopwatch.Stop();
        }

        public static long ElapsedMilliseconds()
        {
            return stopwatch.ElapsedMilliseconds;
        }

        public static int ElapsedSeconds()
        {
            return stopwatch.Elapsed.Seconds;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    class TimePrinter
    {
        public void Print()
        {
            DateTime startTime = DateTime.UtcNow;
            TimeSpan future = TimeSpan.FromMinutes(.10);
            while (DateTime.UtcNow - startTime < future)
            {
                Debug.WriteLine("Delay" + DateTime.Now.ToString("hh:MM:ss"));
            }
            Debug.WriteLine("Delay over");
        }

        public Task<int> PrintAsync()
        {
            return Task.Run(() =>
            {
                Print();
                return 10;
            });
        }
    }
}
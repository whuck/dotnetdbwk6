using System;
using System.IO;
using NLog.Web;

namespace DotNetDbWk6
{
    class Program
    {
        static void Main(string[] args)
        {   //fire up logger
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            var logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();
            //instantiate FileParser obj
            FileParser fp = new FileParser("data.txt");

            //test run of week creation
            string w = "8/30/2020,7|4|10|12|6|10|10";
            SleepData sd = new SleepData();
            sd.AddWeek(w);
            Console.WriteLine(sd.ToString());

        }
    }
}

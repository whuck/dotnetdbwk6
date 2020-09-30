using System;
using System.IO;
using NLog.Web;
using System.Collections;
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
            ArrayList lines = fp.ParseFile();
            //test run of week creation
            //string w = "8/30/2020,7|4|10|12|6|10|10";
            //string w2 = "9/30/2020,3|2|10|12|6|11|11";
            SleepData sd = new SleepData(lines);

            //sd.AddWeek(w);
            //sd.AddWeek(w2);
            Console.WriteLine(sd.ToString());

        }
    }
}

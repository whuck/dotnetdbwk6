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
        }
    }
}

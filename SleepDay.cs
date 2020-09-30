using System;
using NLog.Web;
using System.IO;
namespace DotNetDbWk6
{
    class SleepDay
    {
        private int hoursSlept {get; set;}
        private DateTime sleepDayDate {get; set;}
        private NLog.Logger logger;
        public SleepDay(int h, DateTime d)
        {
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            this.logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();
            this.logger.Debug($"Creating SleepDay({h},{d.ToString()})");
            this.hoursSlept = h;
            this.sleepDayDate = d;
        }
        public override string ToString()
        {       
            return this.hoursSlept.ToString();
        }
    }
}
using System;
using NLog.Web;

namespace DotNetDbWk6
{
    class SleepDay
    {
        private int hoursSlept {get; set;}
        private DateTime sleepDayDate {get; set;}
        public SleepDay(int h, DateTime d)
        {
            this.hoursSlept = h;
            this.sleepDayDate = d;
        }
    }
}
using System;
using NLog.Web;
using System.Collections;
namespace DotNetDbWk6
{
    class SleepWeek
    {
        private ArrayList days {get; set;}
        private DateTime startDate {get; set;}
        private DateTime endDate {get; set;}
        private Double avgHrs {get; set;}
        public SleepWeek(ArrayList days, DateTime startDate)
        {
            this.days = new ArrayList(days);
            this.startDate = startDate;
            this.endDate = startDate.AddDays(7);
        }

    }
}
using System;
using NLog.Web;
using System.Collections;
using System.IO;
namespace DotNetDbWk6
{
    class SleepData
    {
        private ArrayList weeks {get; set;}
        private NLog.Logger logger;
        public SleepData()
        {
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            this.logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();
            this.weeks = new ArrayList();
            this.logger.Debug("Creating SleepData Object");
        }
        
        public void AddWeek(string weekData)
        {   
            this.logger.Debug($"AddWeek({weekData})");
            //weekData  : 8/30/2020,7|4|10|12|6|10|10
            string[] lineItems = weekData.Split(',');
            //lineItems[0] is 8/30/2020
            //lineItems[1] is 7|4|10|12|6|10|10
            
            //cast date string to DateTime
            DateTime startDate = DateTime.Parse(lineItems[0]);
            //cast week hours string in an array
            string weekHrs = lineItems[1];
            SleepWeek week = new SleepWeek(startDate, weekHrs);
            //grab hours and toss in an array
            //string[] lineHours = lineItems[1].Split('|');
            
            // //iterate through array of string ints and create SleepDay objs for the week
            // int totalHrs = 0;
            // double avgHrs = 0;

            // ArrayList week = new ArrayList();
            // for(int i = 0; i < lineHours.Length; i++)
            //     {
            //         int dayHours = short.Parse(lineHours[i]);
            //         DateTime dayDate = lineDate.AddDays(i);
            //         SleepDay day = new SleepDay(dayHours,dayDate);
            //         totalHrs+=short.Parse(lineHours[i]);
            //         week.Add(day);
            //     }
            // avgHrs = totalHrs / 7;
            // string avg = $"{avgHrs:0.0}";
            this.weeks.Add(week);
        }
        public override string ToString()
        {
            string outty = "";
            for(int i =0; i < this.weeks.Count; i++)
            {
                outty += this.weeks[i].ToString();
            }
            return outty;
        }
        
    }
}
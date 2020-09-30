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
        public SleepData(ArrayList lines)
        {
            this.weeks = new ArrayList();
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            this.logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();
            foreach(string week in lines)
            {
                this.AddWeek(week);
            }
            //this.weeks = new ArrayList();
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
            //creat week obj and toss into weeks array
            SleepWeek week = new SleepWeek(startDate, weekHrs);
            this.weeks.Add(week);
        }
        public override string ToString()
        {
            string outty = "";
            for(int i =0; i < this.weeks.Count; i++)
            {
                outty += this.weeks[i].ToString() + System.Environment.NewLine;
            }
            return outty;
        }
        
    }
}
using System;
using NLog.Web;
using System.Collections;
using System.IO;
namespace DotNetDbWk6
{
    class SleepWeek
    {
        private ArrayList days {get; set;}
        private DateTime startDate {get; set;}
        private DateTime endDate {get; set;}
        private double avgHrs {get; set;}
        private int totalHrs {get; set;}
        private NLog.Logger logger;
        public SleepWeek(DateTime startDate,string hours)
        {
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            this.logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();
            this.logger.Debug($"Creating SleepWeek({startDate.ToString()},{hours})");

            this.startDate = startDate;
            this.endDate = startDate.AddDays(7);
            ArrayList week = new ArrayList();
            
            //split string of hours and toss in an array
            string[] weekHours = hours.Split('|');

            for(int i = 0; i < 7; i++)
                {
                    //cast hour to int
                    int dayHours = short.Parse(weekHours[i]);
                    //add hours to week's total hours for average calc
                    this.totalHrs += dayHours;
                    //make individual day's date by adding loop index to startdate
                    DateTime dayDate = startDate.AddDays(i);
                    //create day obj and toss into week array
                    SleepDay day = new SleepDay(dayHours,dayDate);
                    week.Add(day);
                }  
            this.avgHrs = this.totalHrs / 7;
            this.days = week;
        }
        public override string ToString()
        {
            string outty = "";
            //week ToString header
            outty+=$"Week of {this.startDate:MMM}, {this.startDate:dd}, {this.startDate:yyyy}" + System.Environment.NewLine;
            outty+=$"{"Su",3}{"Mo",3}{"Tu",3}{"We",3}{"Th",3}{"Fr",3}{"Sa",3}{"Tot",4}{"Avg",4}" + System.Environment.NewLine;
            outty+=$"{"--",3}{"--",3}{"--",3}{"--",3}{"--",3}{"--",3}{"--",3}{"---",4}{"---",4}" + System.Environment.NewLine; 
            //loop through days arraylist 
            for (int i = 0; i < 7; i++)
            {
                outty += $"{this.days[i].ToString(),3}";
            }
            //toss on avg & total hours
            string avg = $"{this.avgHrs:0.0}";
            outty += $"{this.totalHrs,4}{avg,4}" + System.Environment.NewLine;
            return outty;
        }

    }
}
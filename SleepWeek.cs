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
        private double avgHrs {get; set;}
        private int totalHrs {get; set;}
        public SleepWeek(DateTime startDate,string hours)
        {
            //this.days = new ArrayList(days);
            this.startDate = startDate;
            this.endDate = startDate.AddDays(7);
            ArrayList week = new ArrayList();
            
            //split string of hours and toss in an array
            string[] weekHours = hours.Split('|');

            for(int i = 0; i < 6; i++)
                {
                    //cast hour to int
                    int dayHours = short.Parse(weekHours[i]);
                    //add hours to week's total hours for average calc
                    this.totalHrs += dayHours;
                    //make individual day's date by adding loop index to startdate
                    DateTime dayDate = startDate.AddDays(i);
                    
                    SleepDay day = new SleepDay(dayHours,dayDate);
                    //hours+=short.Parse(hours[i]);
                    week.Add(day);
                }  
            this.avgHrs /= 7;
            this.days = week;
        }

    }
}
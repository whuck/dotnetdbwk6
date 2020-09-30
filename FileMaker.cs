using System;
using System.IO;
using NLog.Web;
using System.Collections;
namespace DotNetDbWk6
{
    class FileMaker
    {

        private string fileName;
        private NLog.Logger logger;
        private StreamWriter sw;
        public FileMaker(string fileName)
        {
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();
            this.fileName = fileName;
        }
        public void MakeFile(int numWeeks)
        {
                // determine start and end date
                DateTime today = DateTime.Now;
                // we want full weeks sunday - saturday
                DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
                // subtract # of weeks from endDate to get startDate
                DateTime dataDate = dataEndDate.AddDays(-(numWeeks * 7));
                
                // random number generator
                Random rnd = new Random();

                // create file
                this.sw = new StreamWriter(fileName);
                // loop for the desired # of weeks
                while (dataDate < dataEndDate)
                {
                    // 7 days in a week
                    int[] hours = new int[7];
                    for (int i = 0; i < hours.Length; i++)
                    {
                        // generate random number of hours slept between 4-12 (inclusive)
                        hours[i] = rnd.Next(4, 13);
                    }
                    // M/d/yyyy,#|#|#|#|#|#|#
                    //Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                    sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
                    logger.Debug($"writing line to file{dataDate:M/d/yyyy},{string.Join("|", hours)}");
                    // add 1 week to date
                    dataDate = dataDate.AddDays(7);
                }
                sw.Close();            
        }
    }
}
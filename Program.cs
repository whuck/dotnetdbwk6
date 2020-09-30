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
            FileMaker fm = new FileMaker("data.txt");
            //fm.MakeFile(10);

            FileParser fp = new FileParser("data.txt");
            //ArrayList lines = fp.ParseFile();

            //SleepData sd = new SleepData(lines);

            //Console.WriteLine(sd.ToString());


            

            string resp = "";
            do {
                Console.WriteLine("Enter 1 to create data file.");
                Console.WriteLine("Enter 2 to parse data.");
                Console.WriteLine("Enter anything else to quit.");
                // input response
                resp = Console.ReadLine();
                switch (resp)
                {
                    case "1" :
                    // create data file
                    // ask a question
                    Console.WriteLine("How many weeks of data is needed?");
                    // input the response (convert to int)
                    int weeks = int.Parse(Console.ReadLine());
                    fm.MakeFile(weeks);
                    break;
                    
                    case "2" : 
                    SleepData sd = new SleepData(fp.ParseFile());
                    Console.WriteLine(sd.ToString());
                    break;

                    default : break;
                }
            } while (resp=="1" || resp=="2");

        }
    }
}

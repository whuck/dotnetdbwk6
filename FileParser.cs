using System;
using System.IO;
using NLog.Web;
using System.Collections;
namespace DotNetDbWk6
{
    class FileParser
    {
        private string fileName;
        private NLog.Logger logger;
        private StreamReader sr;
        public FileParser(string fileName)
        {
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();
            this.fileName = fileName;
            
        }
        public ArrayList ParseFile()
        {
            logger.Debug("parsing file");
            ArrayList lines = new ArrayList();
            try 
            {                
                sr = new StreamReader(this.fileName);
                while(!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine());
                }
                sr.Close();                
            } catch {
                logger.Debug($"StreamReader({fileName}) died!");                
            }
            return lines;
        }
    }
}

using System;
using System.IO;
using NLog.Web;
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
        public void ParseFile()
        {
            try 
            {
                sr = new StreamReader(this.fileName);
            } catch {
                logger.Debug($"StreamReader({fileName}) died!");
            }
        }
    }
}

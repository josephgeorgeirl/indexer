using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer.Core
{
    public class Logger
    {
        private static Object thisLock = new Object();
        public static void Log(Exception ex)
        {
            //Log error details

            //throw ex;
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("LogFileLocation") + @"\IndexLog.txt";
                lock (thisLock)
                {
                    FileInfo fi = new FileInfo(filePath);
                    if (!fi.Directory.Exists)
                    {
                        System.IO.Directory.CreateDirectory(fi.DirectoryName);
                    }
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                           "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                        writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                    }
                }

            }
            catch (Exception)
            {

                
            }

           
        }

       
    }
}

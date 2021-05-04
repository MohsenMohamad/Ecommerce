using System;
using System.IO;

namespace ServerApi
{
    //singleton thread safe class
    public class Logger
    {
        private static string path = Path.GetFullPath(@"..\..\..\ServerApi\");
        private static object _myLock = new object();
        private static Logger logger = null;
    
        private Logger() { }
    
        public static Logger GetInstance()
        {
            if (logger == null) // The first check
            {
                lock (_myLock)
                {
                    if (logger == null) // The second (double) check
                    {
                        logger = new Logger();
                    }
                }
            }
    
            return logger;
        }
        public void Error(string msg)
        {
            string errorLogger = path+"errorLogger.txt";
            try
            {
                if (!File.Exists(errorLogger))
                {
                    File.Create(errorLogger);
                }
                using (StreamWriter sw = File.AppendText(errorLogger))
                {
                    sw.WriteLine(DateTime.Now.ToString() + ": " + msg + "  . ");
                    sw.Dispose();
                    sw.Close();
                }
            }
            catch
            { }
        }
        public  void Event(string msg)
        {
            string eventLogger = path+"eventLogger.txt";
            try
            {
                if (!File.Exists(eventLogger))
                {
                    File.Create(eventLogger);
                }
                using (StreamWriter sw = File.AppendText(eventLogger))
                {
                    sw.WriteLine(DateTime.Now.ToString() + ": " + msg + "  .");
                    sw.Dispose();
                    sw.Close();
                }
            }
            catch { }
        }
    }
}



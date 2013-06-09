using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;   
using System.IO;

namespace SMS.UI.Mvc3.Helpers
{
    /// <summary>   
    /// LogHelper: write log using log4net   
    /// </summary>   
    public class LogHelper   
    {
        private LogHelper()   
        {   

        }   
  
        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");   //choose settings in <logger name="loginfo">

        public static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");   //hoose settings in <logger name="logerror">
   
        /// <summary>
        /// initialize the log configuration
        /// </summary>
        public static void SetConfig()   
        {   
            log4net.Config.XmlConfigurator.Configure();   
        }   
  
        /// <summary>
        /// initialize the log configuration
        /// </summary>
        /// <param name="configFile">log file path</param>
        public static void SetConfig(FileInfo configFile)   
        {   
            log4net.Config.XmlConfigurator.Configure(configFile);    
        }   
  
        /// <summary>
        /// write info log
        /// </summary>
        /// <param name="info">info text</param>
        public static void WriteLog(string info)   
        {   
            if(loginfo.IsInfoEnabled)   
            {   
                loginfo.Info(info);   
            }   
        }   
  
        /// <summary>
        /// write error log
        /// </summary>
        /// <param name="info">error info</param>
        /// <param name="se">exception info</param>
        public static void WriteLog(string info, Exception se)   
        {   
            if(logerror.IsErrorEnabled)   
            {   
                logerror.Error(info,se);   
            }   
        }   
    } 
}
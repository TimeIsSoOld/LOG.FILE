using System;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Base.Log
{
    public interface ILog4Net: log4net.ILog
    {

    }
    public class Log4Net
    {
        private static Log4Net _Log4Net = null;
        public Log4Net()
        {
            //var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + ConfigurationManager.AppSettings["log4net"];
            //var fi = new System.IO.FileInfo(path);
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/Web.config")));
        }

        public static Log4Net GetLog4Net()
        {
            if (_Log4Net == null)
            {
                _Log4Net = new Log4Net();
            }
            return _Log4Net;
        }

        public log4net.ILog Log(string Level)
        {
            log4net.ILog log = null;
            switch (Level)
            {
                case "FATAL":
                    log = log4net.LogManager.GetLogger("FATAL.Logging");
                    break;
                case "ERROR":
                    log = log4net.LogManager.GetLogger("ERROR.Logging");
                    break;
                case "INFO":
                    log = log4net.LogManager.GetLogger("INFO.Logging");
                    break;
                case "DEBUG":
                    log = log4net.LogManager.GetLogger("DEBUG.Logging");
                    break;
                case "WARN":
                default:
                    log = log4net.LogManager.GetLogger("WARN.Logging");
                    break;
            }
            return log;
        }

        public void WriteLog(string Level,string Info)
        {
            log4net.ILog ILog = Log(Level);
            switch (Level)
            {
                case "FATAL":
                    if (ILog.IsFatalEnabled) ILog.Fatal(Info);
                    break;
                case "ERROR":
                    if (ILog.IsErrorEnabled) ILog.Error(Info);
                    break;
                case "INFO":
                    if (ILog.IsInfoEnabled) ILog.Info(Info);
                    break;
                case "DEBUG":
                    if (ILog.IsDebugEnabled) ILog.Debug(Info);
                    break;
                case "WARN":
                default:
                    if (ILog.IsWarnEnabled) ILog.Warn(Info);
                    break;
            }
        }
        public void WriteLog(string Level, string Info, Exception ex)
        {
            log4net.ILog ILog = Log(Level);
            switch (Level)
            {
                case "FATAL":
                    if (ILog.IsFatalEnabled) ILog.Fatal(Info, ex);
                    break;
                case "ERROR":
                    if (ILog.IsErrorEnabled) ILog.Error(Info, ex);
                    break;
                case "INFO":
                    if (ILog.IsInfoEnabled) ILog.Info(Info, ex);
                    break;
                case "DEBUG":
                    if (ILog.IsDebugEnabled) ILog.Debug(Info, ex);
                    break;
                case "WARN":
                default:
                    if (ILog.IsWarnEnabled) ILog.Warn(Info, ex);
                    break;
            }
        }
    }
}

using LoRaWAN.Logging.Abstract;
using LoRaWAN.Logging.Enums;
using LoRaWAN.Logging.Extensions;
using NLog;

namespace LoRaWAN.Logging.Concrete
{
    public class NLogManager : ILogManager
    {
        #region Info
        public void Info(object logMessage, string location = "Data.Info")
        {
            Info(LogTarget.File, logMessage, location);
        }
        public void Info(LogTarget logTarget, object logMessage, string location = "Data.Info")
        {
            var logger = LogManager.GetLogger(logTarget + "." + location);
            logger.Info($"{logMessage.Serializing()}\r");
        }

        public void Info(string logTitle, object logMessage, string location = "Data.Info")
        {
            Info(LogTarget.File, logTitle, logMessage, location);
        }
        public void Info(LogTarget logTarget, string logTitle, object logMessage, string location = "Data.Info")
        {
            var logger = LogManager.GetLogger(logTarget + "." + location);
            logger.Info($"\r{logTitle}\r{logMessage.Serializing()}\r");
        }
        #endregion

        #region Trace

        public void Trace(object logMessage, string location = "Data")
        {
            Trace(LogTarget.File, logMessage, location);
        }

        public void Trace(LogTarget logTarget, object logMessage, string location = "Data")
        {
            var logger = LogManager.GetLogger(logTarget + "." + location);
            logger.Trace($"{logMessage.Serializing()}\r");
        }

        public void Trace(string logTitle, object logMessage, string location = "Data")
        {
            Trace(LogTarget.File, logTitle, logMessage, location);
        }

        public void Trace(LogTarget logTarget, string logTitle, object logMessage, string location = "Data")
        {
            var logger = LogManager.GetLogger(logTarget + "." + location);
            logger.Trace($"\r{logTitle}\r{logMessage.Serializing()}\r");
        }

        #endregion

        #region Debug
        public void Debug(object logMessage, string location = "Data")
        {
            Debug(LogTarget.File, logMessage, location);
        }

        public void Debug(LogTarget logTarget, object logMessage, string location = "Data")
        {
            var logger = LogManager.GetLogger(logTarget + "." + location);
            logger.Debug($"{logMessage.Serializing()}\r");
        }

        public void Debug(string logTitle, object logMessage, string location = "Data")
        {
            Debug(LogTarget.File, logTitle, logMessage, location);
        }

        public void Debug(LogTarget logTarget, string logTitle, object logMessage, string location = "Data")
        {
            var logger = LogManager.GetLogger(logTarget + "." + location);
            logger.Debug($"\r{logTitle}\r{logMessage.Serializing()}\r");
        }
        #endregion

        #region Warm
        public void Warn(object logMessage, string location = "Data")
        {
            Warn(LogTarget.File, logMessage, location);
        }

        public void Warn(LogTarget logTarget, object logMessage, string location = "Data")
        {
            var logger = LogManager.GetLogger(logTarget + "." + location);
            logger.Warn($"{logMessage.Serializing()}\r");
        }

        public void Warn(string logTitle, object logMessage, string location = "Data")
        {
            Warn(LogTarget.File, logTitle, logMessage, location);
        }

        public void Warn(LogTarget logTarget, string logTitle, object logMessage, string location = "Data")
        {
            var logger = LogManager.GetLogger(logTarget + "." + location);
            logger.Warn($"\r{logTitle}\r{logMessage.Serializing()}\r");
        }

        #endregion

        #region Error
        public void Error(object logMessage, string location = "Error")
        {
            Error(LogTarget.File, logMessage, location);
        }

        public void Error(LogTarget logTarget, object logMessage, string location = "Error")
        {
            var logger = LogManager.GetLogger(logTarget + "." + location);
            logger.Error($"{logMessage.Serializing()}\r");
        }

        public void Error(string logTitle, object logMessage, string location = "Error")
        {
            Error(LogTarget.File, logTitle, logMessage, location);
        }

        public void Error(LogTarget logTarget, string logTitle, object logMessage, string location = "Error")
        {
            var logger = LogManager.GetLogger(logTarget + "." + location);
            logger.Error($"\r{logTitle}\r{logMessage.Serializing()}\r");
        }

        #endregion

        #region Fatal
        public void Fatal(object logMessage, string location = "Error")
        {
            Fatal(LogTarget.File, logMessage, location);
        }

        public void Fatal(LogTarget logTarget, object logMessage, string location = "Error")
        {
            var logger = LogManager.GetLogger(logTarget + "." + location);
            logger.Fatal($"{logMessage.Serializing()}\r");
        }

        public void Fatal(string logTitle, object logMessage, string location = "Error")
        {
            Fatal(LogTarget.File, logTitle, logMessage, location);
        }

        public void Fatal(LogTarget logTarget, string logTitle, object logMessage, string location = "Error")
        {
            var logger = LogManager.GetLogger(logTarget + "." + location);
            logger.Fatal($"\r{logTitle}\r{logMessage.Serializing()}\r");
        }

        #endregion
    }
}

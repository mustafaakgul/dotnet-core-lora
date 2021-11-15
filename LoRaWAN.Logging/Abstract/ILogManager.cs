using LoRaWAN.Logging.Enums;

namespace LoRaWAN.Logging.Abstract
{
    public interface ILogManager
    {
        void Info(object logMessage, string location = "Data");
        void Info(LogTarget logTarget, object logMessage, string location = "Data");
        void Info(string logTitle, object logMessage, string location = "Data");
        void Info(LogTarget logTarget, string logTitle, object logMessage, string location = "Data");
        void Debug(object logMessage, string location = "Data");
        void Debug(LogTarget logTarget, object logMessage, string location = "Data");
        void Debug(string logTitle, object logMessage, string location = "Data");
        void Debug(LogTarget logTarget, string logTitle, object logMessage, string location = "Data");
        void Warn(object logMessage, string location = "Data");
        void Warn(LogTarget logTarget, object logMessage, string location = "Data");
        void Warn(string logTitle, object logMessage, string location = "Data");
        void Warn(LogTarget logTarget, string logTitle, object logMessage, string location = "Data");
        void Error(object logMessage, string location = "Data");
        void Error(LogTarget logTarget, object logMessage, string location = "Data");
        void Error(string logTitle, object logMessage, string location = "Data");
        void Error(LogTarget logTarget, string logTitle, object logMessage, string location = "Data");
        void Fatal(object logMessage, string location = "Data");
        void Fatal(LogTarget logTarget, object logMessage, string location = "Data");
        void Fatal(string logTitle, object logMessage, string location = "Data");
        void Fatal(LogTarget logTarget, string logTitle, object logMessage, string location = "Data");
        void Trace(object logMessage, string location = "Data");
        void Trace(LogTarget logTarget, object logMessage, string location = "Data");
        void Trace(string logTitle, object logMessage, string location = "Data");
        void Trace(LogTarget logTarget, string logTitle, object logMessage, string location = "Data");
    }
}

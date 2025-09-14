using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace CuahangNongduoc.Utils.Logger
{
    public class Logger<T> : ILogger
    {
        private readonly string _className;
        private readonly Level _current = Level.Debug;
        private static readonly string ConfigKey = "LogLevel";
        private static readonly string LogFileKey = "LogFile";
        private static readonly string DefaultLogFile = "app.log";
        private string _logFile;
        public Logger()
        {
            _className = typeof(T).Name;
            string configLevel = ConfigurationManager.AppSettings[ConfigKey];
            string logFile = ConfigurationManager.AppSettings[LogFileKey];
            if (!string.IsNullOrEmpty(logFile))
            {
                _logFile = logFile;
            }
            else
            {
                _logFile = DefaultLogFile;
            }
            try
            {
                Level level = (Level)Enum.Parse(typeof(Level), configLevel, true);
                _current = level;
            }
            catch (Exception ex)
            {
                this.Error("Missing log config", ex);
            }
        }

        private void Log(Level level, string message, Exception ex = null)
        {
            if (level < _current) return;

            string logMessage = $"[{DateTime.Now}][{_className}][{level}] {message}";
            Console.WriteLine(logMessage);
            if (ex != null)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }

            if (level > Level.Debug)
            {
                this.WriteLog(logMessage, ex);
            }

        }

        private void WriteLog(string message, Exception ex)
        {
            // Write log to file or database
            System.IO.File.AppendAllText(_logFile, message + Environment.NewLine);
            if (ex != null)
            {
                System.IO.File.AppendAllText(_logFile, ex.ToString() + Environment.NewLine);
            }
        }

        public void Info(string message) => this.Log(Level.Info, message);
        public void Error(string message, Exception ex) => this.Log(Level.Error, message, ex);
        public void Debug(string message) => this.Log(Level.Debug, message);
    }
}

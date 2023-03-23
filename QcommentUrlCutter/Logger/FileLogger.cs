﻿namespace QcommentUrlCutter.Logger
{
    public class FileLogger : ILogger
    {
        private readonly string _logpath = "errors.log";
        public void Log(string message)
        {
            File.AppendAllText(_logpath, $"{DateTime.Now} - {message}{Environment.NewLine}");
        }
    }
}

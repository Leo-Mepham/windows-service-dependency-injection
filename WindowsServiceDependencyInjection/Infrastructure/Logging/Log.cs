using System;
using System.Diagnostics;

namespace Infrastructure.Logging
{
    public class Log : ILog
    {
        void ILog.Log(LogLevel logLevel, string logEntry)
        {
            var eventLogEntryType = (EventLogEntryType)Enum.Parse(typeof(EventLogEntryType), logLevel.ToString());

            using (EventLog eventLog = new EventLog("Application"))
            {             
                eventLog.Source = "Application";
                eventLog.WriteEntry(logEntry, eventLogEntryType);
            }
        }
    }
}

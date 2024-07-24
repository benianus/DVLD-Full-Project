using System;

namespace Utility
{
    public class clsUtility
    {
        public static void CreateEventLog(Exception errorMessage)
        {
            string Source = "DVLD App";

            if (!EventLog.SourceExists(Source))
            {
                EventLog.CreateEventSource(Source, "Application");
            }

            EventLog.WriteEntry(Source, errorMessage.ToString(), EventLogEntryType.Error);
        }
    }
}
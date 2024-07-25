using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDataLayer
{
    public static class clsDataSettings
    {
        public static string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        public static void CreateEventLog(Exception error)
        {
            string Source = "DLVL Program";

            if (!EventLog.SourceExists(Source))
            {
                EventLog.CreateEventSource(Source, "Application");
            }

            EventLog.WriteEntry(Source, error.Message, EventLogEntryType.Error);
        }

    }

   
}

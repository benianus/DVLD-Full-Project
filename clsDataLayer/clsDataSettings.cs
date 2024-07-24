using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDataLayer
{
    public static class clsDataSettings
    {
        public static string connectionString = "Server = .; DataBase = DVLD; User id = sa; Password = 123456;";

        public static void CreateEventLog(Exception error)
        {
            string Source = error.Source;

            if (!EventLog.SourceExists(Source))
            {
                EventLog.CreateEventSource(Source, "Application");
            }

            EventLog.WriteEntry(Source, error.Message, EventLogEntryType.Error);
        }

    }

   
}

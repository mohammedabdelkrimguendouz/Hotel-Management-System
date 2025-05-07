using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.Logging.EventLog;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsEventLogData
    {
        public static void WriteEvent(string Message, EventLogEntryType eventLogEntryType)
        {

            string SourceName = "DVLD";

            try
            {
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, "Application");
                }

                EventLog.WriteEntry(SourceName, Message, eventLogEntryType);
            }
            catch (Exception Ex)
            {

            }
            
        }
    }
}

using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsEventLog
    {
        public static void WriteEvent(string Message, EventLogEntryType eventLogEntryType)
        {
            clsEventLogData.WriteEvent(Message, eventLogEntryType);
        }
    }
}

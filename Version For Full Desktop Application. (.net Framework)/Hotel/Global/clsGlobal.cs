using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using Hotel_Buisness;

namespace DVLD.Global_Classes
{
    public class clsGlobal
    {
        static public clsEmployee CurrentEmployee;
        
        public static bool GetStoredCredential(ref string UserName, ref string Password)
        {
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\Hotel";
            string ValueNameUserName="UserName";
            string ValueNamePassword = "Password";

            try
            {
                UserName = Registry.GetValue(KeyPath, ValueNameUserName, null) as string;
                Password= Registry.GetValue(KeyPath, ValueNamePassword, null) as string;

                return (UserName != "" && Password != "");
            }
            catch(Exception Ex)
            {
                clsEventLog.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                return false;
            }

        }

        public static bool RememberUserNameAndPassword(string UserName, string Password)
        {

            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\Hotel";
            string ValueNameUserName = "UserName";  string ValueDataUserName = UserName;
            string ValueNamePassword = "Password";  string ValueDataPassword = Password;

            try
            {
                Registry.SetValue(KeyPath, ValueNameUserName,ValueDataUserName,RegistryValueKind.String);
                Registry.SetValue(KeyPath, ValueNamePassword, ValueDataPassword, RegistryValueKind.String);

                return true;
            }
            catch (Exception Ex)
            {
                clsEventLog.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                return false;
            }


        }

    }
}

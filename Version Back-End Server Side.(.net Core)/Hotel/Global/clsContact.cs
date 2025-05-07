using DVLD_Buisness;
using DVLD_DataAccess;
using EASendMail;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Global.Classes
{
    public class clsContact
    {
        static public bool SendEmail(string ToEmail, string Subject, string Body)
        {
            string FromEmail = "dvld.system.algeria@gmail.com";
            string Password = "xnso jfnl lbnl msgz";
            try
            {
                SmtpMail Mail = new SmtpMail("TryIt");
                Mail.From = FromEmail;// إميل الشخص الذي يرسل الرسالة 
                Mail.To = ToEmail; // إميل الشخص الذي يستقبل الرسالة
                Mail.Subject = Subject;// موضوع الرسالة  
                Mail.TextBody = Body;// محتوى الرسالة 

                SmtpServer Server = new SmtpServer("smtp.gmail.com");// smtp.live.com  ------> @hotmail///smtp.gmail.com---->@gmail
                Server.User = FromEmail;// إميل الشخص الذي يرسل الرسالة
                Server.Password = Password;  // كلمة السر  
                Server.ConnectType = SmtpConnectType.ConnectTryTLS;
                Server.Port = 587;  //  25 or 587 or 465
                Server.ConnectType = SmtpConnectType.ConnectSSLAuto;

                SmtpClient smtp = new SmtpClient();
                smtp.SendMail(Server, Mail);
            }
            catch (Exception Ex)
            {
                clsEventLogData.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                return false;
            }
            return true;
        }
    }
}

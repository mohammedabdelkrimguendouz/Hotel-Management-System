using DVLD_Buisness;
using EASendMail;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.Directives;
using System.Windows.Forms;

namespace DVLD.Global_Classes
{
    public class clsUtil
    {
       
        static public byte[] ReadImageFile(string ImagePath)
        {
            byte[] ImageAsByte;
            try
            {
                ImageAsByte= File.ReadAllBytes(ImagePath);
            }
            catch (Exception Ex)
            {
                clsEventLog.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                ImageAsByte=null;
            }

            return ImageAsByte;
        }

        static public Image ConvertByteArrayToImage(byte[] byteArray)
        {
            Image image;
            try
            {
                using (MemoryStream ms = new MemoryStream(byteArray))
                {
                    image= Image.FromStream(ms);
                }
            }
            catch (Exception Ex)
            {
                clsEventLog.WriteEvent($" Message : {Ex.Message} \n\n Source : {Ex.Source} \n\n Target Site :  {Ex.TargetSite} \n\n Stack Trace :  {Ex.StackTrace}", EventLogEntryType.Error);
                image= null;
            }

            return image;
        }

    }
}

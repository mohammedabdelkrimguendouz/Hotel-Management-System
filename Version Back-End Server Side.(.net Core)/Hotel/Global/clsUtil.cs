using DVLD_Buisness;
using DVLD_DataAccess;
using EASendMail;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Global_Classes
{
    public class clsUtil
    {

        static public byte[] ConvertImageToByteArray(IFormFile image)
        {
            using (var memoryStream = new MemoryStream())
            {
                image.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        static public IFormFile ConvertBytesToFormFile(byte[] fileBytes)
        {
            // إنشاء MemoryStream من مصفوفة البايتات
            var stream = new MemoryStream(fileBytes);

            // إنشاء FormFile من MemoryStream بدون تحديد اسم ملف أو نوع محتوى
            IFormFile formFile = new FormFile(stream, 0, fileBytes.Length, "file", "defaultFileName")
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/octet-stream" // استخدام نوع محتوى افتراضي
            };

            return formFile;
        }

    }
}

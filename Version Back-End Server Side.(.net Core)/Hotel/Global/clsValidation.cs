using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD_Buisness.Global_Classes
{
    public class clsValidation
    {
        public static bool ValidateEmail(string EmailAddress)
        {
            var Pattern = @"^[a-zA-Z0-9._%+-]{6,30}@gmail\.com$";
            var regex =new Regex(Pattern);
            return regex.IsMatch(EmailAddress);
        }
        public static bool ValidateInteger(string Number)
        {
            var Pattern = @"^\d+$";
            var regex = new Regex(Pattern);
            return regex.IsMatch(Number);
        }
        public static bool validateFloat(string Number)
        {
            var Pattern = @"^-?\d+(\.\d+)?$";
            var regex = new Regex(Pattern);
            return regex.IsMatch(Number);
        }
        public static bool IsNumber(string Number)
        {
            return (ValidateInteger(Number)||validateFloat(Number)) ;
        }

    }
}

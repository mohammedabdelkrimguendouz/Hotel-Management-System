using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Buisness
{
    public class clsSetting
    {
        public static float GetFoodPrice()
        {
            return clsSettingData.GetFoodPrice();
        }
    }
}

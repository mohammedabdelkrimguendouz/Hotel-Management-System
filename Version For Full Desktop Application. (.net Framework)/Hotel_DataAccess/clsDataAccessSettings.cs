﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DVLD_DataAccess
{
    static public class clsDataAccessSettings
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
    }
}

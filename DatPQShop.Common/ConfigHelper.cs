﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatPQShop.Common
{
    public class ConfigHelper
    {
        public static string GetBykey(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
    }
}

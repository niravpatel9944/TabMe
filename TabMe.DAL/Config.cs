using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace PMS.DAL
{
    public class Config
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["TabMe"].ConnectionString;
            }
        }
        public static string ProviderName
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["TabMe"].ProviderName;
            }
        }
    }
}

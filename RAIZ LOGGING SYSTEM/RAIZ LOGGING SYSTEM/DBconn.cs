using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace RAIZ_LOGGING_SYSTEM
{
    class DBconn
    {
        //private static string strcon = ConfigurationSettings.AppSettings.Get("MyConstring"); //getting configuration from app.config file
        private static string strcon = ConfigurationSettings.AppSettings.Get("MyConstring");

        public static string ConnectMe
        {
            get { return strcon; }
            set { strcon = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAIZ_LOGGING_SYSTEM
{
    class myvar
    {
        private static string getname = "";

        public static string name
        {
            get { return getname; }
            set { getname = value; }
        }
    }
}

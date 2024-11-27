using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace KULSOVAYA.Controller
{
    class ConnectionString
    {
        public static string ConnStr
        {
            get
            {
                return "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=komandirovki.mdb";
            }
        }
    }
}

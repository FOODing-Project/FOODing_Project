using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOODingManager
{
    public class Config
    {
        public static readonly string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
    }
}

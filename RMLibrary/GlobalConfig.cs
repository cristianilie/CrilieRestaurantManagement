using RMLibrary.DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMLibrary
{
    public static class GlobalConfig
    {
        public static SqlConnection Connection { get; private set; } = new SqlConnection();

    }
}

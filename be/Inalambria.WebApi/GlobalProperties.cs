using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inalambria.WebApi
{
    public class GlobalProperties
    {
        public static string JWT_SecretKey { get; set; }
        public static int JWT_ExpirationHours { get; set; }
        public const string DateFormatFilter = "yyyy-MM-dd HH:mm:ss";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Jift.Common
{
    public static class TokenMake
    {
        public static string getToken()
        {
            Random random = new Random();
            string token=DateTime.Now.ToString("ffffff");
            return token;
        }
       
    }
}

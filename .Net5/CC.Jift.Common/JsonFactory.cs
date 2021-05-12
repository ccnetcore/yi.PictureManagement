using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Text.Json;
using Newtonsoft.Json;


namespace CC.Jift.Common
{
    public static class JsonFactory
    {
        public static object getResult(int mycode, bool myflag, string mymessage,int mytotal, object[] data)
        {
            object mydata = new { code = mycode, flag = myflag, message = mymessage, data = new { total=mytotal,rows= data } };
            //return JsonSerializer.Serialize(mydata);
            return JsonConvert.SerializeObject(mydata);
        }
        public static object getResult(int mycode, bool myflag, string mymessage)
        {
            object mydata = new { code = mycode, flag = myflag, message = mymessage};
            //return JsonSerializer.Serialize(mydata);
            return JsonConvert.SerializeObject(mydata);
        }
        public static object getResult(int mycode, bool myflag, string mymessage, object dataEnd)
        {
            object mydata = new { code = mycode, flag = myflag, message = mymessage, data =dataEnd };
            //return JsonSerializer.Serialize(mydata);
            return JsonConvert.SerializeObject(mydata);

        }
    }
}

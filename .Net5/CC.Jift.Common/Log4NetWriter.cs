//using log4net;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WC.YouthLearning.Controllers;

//namespace CC.Jift.Common
//{
//    public class Log4NetWriter : ILogWrite
//    {
//        private ILog log;
//        public Log4NetWriter()
//        {
//            this.log = LogManager.GetLogger(Startup.repository.Name, typeof(HomeController));
//        }


//        public void WriteLogInfo(string txt)
//        {
//            //ILog logWriter = log4net.LogManager.GetLogger("Demo");
//            //logWriter.Error(txt);
//            log.Info(txt);
//        }
//    }
//}

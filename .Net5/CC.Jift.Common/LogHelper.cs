//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace CC.Jift.Common
//{
//    public delegate void WriteLogDel(string str);//定义一个接受一个字符串参数的委托
//    public class LogHelper
//    {
//        public static List<ILogWrite> LogWriteList = new List<ILogWrite>();
//        //定义一个静态队列集合Queue<string>，只要出现异常就加入到这个队列里来(队列是存放在内存中的)
//        public static Queue<string> ExceptionStringQueue = new Queue<string>();

//        //把错误信息写入到队列里去
//        public static void WriteLog(string exceptionText)
//        {
//            lock (ExceptionStringQueue)
//            {
//                ExceptionStringQueue.Enqueue(exceptionText);//错误信息入队，即是加入到Queue<string>集合末尾
//            }
//        }
//        public static WriteLogDel WriteLogDelFunc;//委托类型变量

//        //往日志文件里写错误消息
//        public static void WriteLogToFile(string txt)
//        { }
//        //往Mongodb里写错误消息
//        public static void WriteLogToMongodb(string txt)
//        { }
//        //静态构造函数是在创建第一个类实例或任何静态成员被引用时，.NET将自动调用静态构造函数来初始化类
//        static LogHelper()
//        {
//            //WriteLogDelFunc = new WriteLogDel(WriteLogToFile);//这就是写入到日志文件
//            //WriteLogDelFunc += WriteLogToMongodb;//如果还要写入到Mongdb中去，就用多播委托。如果还要写入到数据库里面去，就再加一个方法，然后再加一条多播委托语句就OK了。
//            //LogWriteList.Add(new TextFileWriter());//把观察者加入进来
//            //LogWriteList.Add(new SqlServerWriter());//把观察者加入进来

//            LogWriteList.Add(new Log4NetWriter());
//            //把从队列里获取的错误消息写到日志文件里面去
//            //QueueUserWorkItem作用是把方法写入队列，以便执行
//            ThreadPool.QueueUserWorkItem(o =>
//            {
//                //不断循环队列中的消息
//                while(true)
//                {
//                    if (ExceptionStringQueue.Count > 0)
//                    {
//                        lock (ExceptionStringQueue)
//                        {
//                            string str = ExceptionStringQueue.Dequeue();//出队
//                                                                        //出队之后，把错误信息写到日志文件里面去。当然以后需求可能发生变化，比如写到数据库里面去，同时写到日志文件和数据库文件里面去等。我们希望不管怎么变化，我们代码改变最小。——用观察者模式，弄个委托
//                                                                        //WriteLogDelFunc(str);

//                            //观察者设计模式实现
//                            //如果仅写到一种类型文件里面去，下面代码即可
//                            //ILogWrite logWrite = new TextFileWriter();
//                            //ILogWrite logWrite = new SqlServerWriter();
//                            //logWrite.WriteLogInfo(str);

//                            //写到多个文件里去
//                            foreach (var logWrite in LogWriteList)
//                            {
//                                logWrite.WriteLogInfo(str);
//                            }
//                        }
//                    }
//                    else
//                    {
//                        Thread.Sleep(30);//如果队列中没有消息，让线程睡眠30毫秒
//                    }
//                }
//            });
//        }

        
            
//    }

// }

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    public class TaskMethod
    {
        public static void AddTask(object o)
        {
            Log(o?.ToString());
        }

        private static object s_logObj = new object();

        public static void Log(string title)
        {
            lock (s_logObj)
            {
                Console.WriteLine(title);
                Console.WriteLine($"task id:{Task.CurrentId?.ToString()??"no task"}, "+
                    $"thread : {Thread.CurrentThread.ManagedThreadId}");
#if(!DNXCORE)
                Console.WriteLine($"THread:  {Thread.CurrentThread.IsThreadPoolThread}");
#endif
                Console.WriteLine($"is back: {Thread.CurrentThread.IsBackground}");
                Console.WriteLine();
            }
        }
    }
}

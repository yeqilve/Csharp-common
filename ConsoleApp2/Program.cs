using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        /// <summary>
        /// cancel a task 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Tasks.CancelTask.CancelParallelFor();
            Console.Read();
        }

        /// <summary>
        /// different ways to start a task
        /// </summary>
        /// <param name="args"></param>
        //static void Main(string[] args)
        //{
        //    var tf = new TaskFactory();
        //    Task t1 = tf.StartNew(Tasks.TaskMethod.AddTask, "using a task factory");
        //    Task t2 = Task.Factory.StartNew(Tasks.TaskMethod.AddTask, "factory via a task");
        //    var t3 = new Task(Tasks.TaskMethod.AddTask, "using constructor and start");
        //    t3.Start();
        //    Task t4 = Task.Run(() => Tasks.TaskMethod.AddTask("using the run method"));
        //    Console.Read();
        //}

        /// <summary>
        /// Parallel multi thread function
        /// </summary>
        /// <param name="args"></param>
        //static void Main(string[] args)
        //{
        //    string[] data = { "one", "two", "three", "four", "five", "six", "seven" };
        //    ParallelLoopResult result = Parallel.ForEach<string>(data, s =>
        //    {                
        //        Console.WriteLine(s);                
        //    });
        //    Console.Read();

        //}

        /// <summary>
        /// Parallel.For foreach the function
        /// </summary>
        /// <param name="prefix"></param>
        //static void Main(string[] args)
        //{
        //    var result = Parallel.For(0, 20, (int i, ParallelLoopState pls) =>
        //    {
        //        log($"S {i}");
        //        if (i > 12)
        //        {
        //            pls.Break();
        //            log($"breadking now {i}");
        //        }
        //        log($"E {i}");
        //    });
        //    Console.WriteLine($"IsCompelted: {result.IsCompleted}");
        //    Console.Read();
        //}

        private static void log(string prefix)
        {
            Console.WriteLine($"{prefix},taks:{Task.CurrentId}" + $"thread :{Thread.CurrentThread.ManagedThreadId}");
        }
    }
}

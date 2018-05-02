using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        #region variable
        static Thread thread1 = null;
        static Thread thread2 = null;
        static Thread thread3 = null;
        static Mutex mutex = null;
        #endregion

        static void Main(string[] args)
        {
            //Console.Write(2<<2);
            //Console.Read();
            //Test t = new Test();
            Program p = new Program();
            p.RunThread();
            Console.ReadLine();
        }

        public Program()
        {
            mutex = new Mutex();
            thread1 = new Thread(new ThreadStart(thread1Func));
            thread2 = new Thread(new ThreadStart(thread2Func));
            thread3 = new Thread(new ThreadStart(thread3Func));
        }



        public void RunThread()
        {
            thread1.Start();
            thread2.Start();
            thread3.Start();
        }

        private void thread1Func()
        {
            for (int count = 0; count < 10; count++)
            {
                TestFunc("a");
            }
        }
        private void thread2Func()
        {
            Thread.Sleep(5);
            for (int count = 0; count < 10; count++)
            {
                TestFunc("b");
            }
        }

        private void thread3Func()
        {
            Thread.Sleep(6);
            for (int count = 0; count < 10; count++)
            {
                TestFunc("c\n");
            }
        }

        private void TestFunc(string str)
        {
            Monitor.Enter(this);

            Console.Write(str);
            Thread.Sleep(5);
            Monitor.Exit(this);
        }
        private static void TestIdWorker()
        {
            HashSet<long> set = new HashSet<long>();
            IdWorker idWorker1 = new IdWorker(0, 0);
            IdWorker idWorker2 = new IdWorker(1, 0);
            Thread t1 = new Thread(() => DoTestIdWoker(idWorker1, set));
            t1.IsBackground = true;

            t1.Start();
            try
            {
                Thread.Sleep(30000);
                t1.Abort();
            }
            catch (Exception e)
            {
            }

            Console.ReadLine();
        }

        private static void DoTestIdWoker(IdWorker idWorker, HashSet<long> set)
        {
            long prev = 0;
            for (int i = 0; i < 10; i++)
            {
                long id = idWorker.nextId();
                Console.WriteLine(id + "   " + (id - prev));
                if (!set.Add(id))
                {
                    Console.WriteLine("duplicate:" + id);
                }
                prev = id;
                Thread.Sleep(1);
            }
        }

    }

    public class Test
    {
        static Test()
        {

        }

        public Test()
        {

        }
    }
}

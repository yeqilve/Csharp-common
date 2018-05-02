using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo
{
    class Program
    {
        /// <summary>
        /// 多线程修改
        /// </summary>
        /// <param name="args"></param>
        //static void Main(string[] args)
        //{
        //    var state = new StateObject();
        //    for (int i = 0; i < 2; i++)
        //    {
        //        Task.Run(() => { new SimpleTask().RaceCondition(state); });
        //    }
        //    Console.Read();
        //}

        ///<summary>
        ///lock  
        /// </summary>
        //static void Main(string[] args)
        //{
        //    int num = 20;
        //    var state = new StateSet();
        //    var job = new object();
        //    var tasks = new Task[num];
        //    for (int i = 0; i < num; i++)
        //    {
        //        tasks[i] = Task.Run(() => new Sync(state).DoTheJob());
        //    }
        //    Task.WaitAll(tasks);
        //    Console.WriteLine(state.State);
        //    Console.Read();
        //}
    }

    #region add lock to keep thread safe
    public class StateSet
    {
        private int _state = 0;
        private object _sync = new object();
        public int State => _state;

        public int Increment()
        {
            lock (_sync)
            {
                return ++_state;
            }
        }

    }

    public class Sync
    {
        private StateSet state;
        public object e = new object();
        public Sync(StateSet state)
        {
            this.state = state;
        }

        public void DoTheJob()
        {
            for (int i = 0; i < 50000; i++)
            {

                state.Increment();
            }
        }
    }
    #endregion
    public class StateObject
    {
        private int _state = 5;

        private object synv = new object();
        public void ChangeState(int loop)
        {
            lock (synv)
            {
                if (_state == 5)
                {
                    _state++;
                    Trace.Assert(_state == 6, $"Race Condition occur after {loop} times");

                }
                _state = 5;
            }
        }
    }

    public class SimpleTask
    {
        public void RaceCondition(object o)
        {
            Trace.Assert(o is StateObject, $"o must be a type of stateobject");
            StateObject so = o as StateObject;
            int i = 0;
            while (true)
            {
                so.ChangeState(i++);
            }
        }
    }
}

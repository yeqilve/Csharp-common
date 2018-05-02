using System;
using System.Collections.Generic;
using System.Threading;

namespace DAL
{
    public class Factory<T> where T : class
    {
        interface ICreate
        {
            T Create();
        }
        class Creater<U> : ICreate where U : T, new()
        {
            public T Create()
            {
                return new U();
            }
        }
        class SingletonCreater<U> : ICreate where U : T, new()
        {
            class InstanceClass
            {
                public static readonly T Instance = new U();
            }
            public T Create()
            {
                return InstanceClass.Instance;
            }
        }
        #region 无参数的
        static ICreate creater;
        public static T Get()
        {
            return creater.Create();
        }
        public static void Reg<S>() where S : T, new()
        {
            creater = new Creater<S>();
        }
        public static void RegSingleton<S>() where S : T, new()
        {
            creater = new SingletonCreater<S>();
        }
        #endregion

        #region 有参数的
        static IDictionary<string, ICreate> creaters = new System.Collections.Concurrent.ConcurrentDictionary<string, ICreate>();
        public static T Get(string key)
        {
            ICreate ct;
            if (creaters.TryGetValue(key, out ct))
                return ct.Create();
            throw new Exception("未注册");
        }
        public static void Reg<S>(string key) where S : T, new()
        {
            creaters[key] = new Creater<S>();
        }
        public static void RegSingleton<S>(string key) where S : T, new()
        {
            creaters[key] = new SingletonCreater<S>();
        }
        #endregion
    }
}

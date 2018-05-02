using System;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using static System.Console;
using System.Collections.Immutable;
using System.Collections;
using System.Collections.Generic;

namespace ObserableCollection
{
    class Program
    {
        /// <summary>
        /// Immutable Collection
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var accountlist = new List<Account>()
            {
                new Account("test","test1"),
                new Account("shawn","ex"),
                new Account("lv chester","asdf")
            };

            ImmutableList<Account> immutableList = accountlist.ToImmutableList();
            //foreach (var item in immutableList)
            //{
            //    Console.WriteLine($"{item.name}, {item.sec}");
            //}
            immutableList.ForEach(s => { Console.WriteLine($"{s.name}, {s.sec}"); });
            Console.Read();
        }
        /// <summary>
        /// obserable collection
        /// </summary>
        /// <param name="args"></param>
        //static void Main(string[] args)
        //{
        //    var data = new ObservableCollection<string>();
        //    data.CollectionChanged += ObserableCollect.data_CollectionChanged;
        //    data.Add("one");
        //    data.Add("two");
        //    data.Insert(1, "three");
        //    data.Remove("one");
        //    Console.Read();
        //}
    }

    public class ObserableCollect
    {
        public static void data_CollectionChanged(Object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine($"Action: {e.Action.ToString()}");
            if (e.OldItems != null)
            {
                Console.WriteLine($"old items :");
                foreach (var item in e.OldItems)
                {
                    Console.WriteLine(item);
                }
            }
            
            if (e.NewItems != null)
            {
                Console.WriteLine($"start index for new items :{e.NewStartingIndex}");
                Console.WriteLine("new items ");
                foreach (var item in e.NewItems)
                {
                    Console.WriteLine(item);
                }

            }
            Console.WriteLine();

        }
    }

    public class Account
    {
        public Account(string name, string sec)
        {
            this.name = name;
            this.sec = sec;
        }
        public string name { get; set; }
        public string sec { get; set; }
    }
}

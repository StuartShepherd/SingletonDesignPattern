using System;
using System.Threading;

namespace Singleton.Singleton
{
    // this Singleton implementation is called "double check lock". 
    // it is safe in multithreaded environment and provides lazy initialization for the singleton object.
    public class Singleton
    {
        private Singleton() { }

        private static Singleton _instance;

        // we now have a lock object that will be used to synchronize threads during first access to the Singleton.
        private static readonly object _lock = new object();

        public static Singleton GetInstance(string value)
        {
            // this conditional is needed to prevent threads stumbling over the lock once the instance is ready.
            if (_instance == null)
            {
                // now, imagine that the program has just been launched. 
                // since there's no Singleton instance yet, multiple threads can simultaneously pass the previous conditional and reach this point almost at the same time. 
                // the first of them will acquire lock and will proceed further, while the rest will wait here.
                lock (_lock)
                {
                    // the first thread to acquire the lock, reaches this conditional, goes inside and creates the singleton instance. 
                    // once it leaves the lock block, a thread that might have been waiting for the lock release may then enter this section. 
                    // but since the singleton field is already initialized, the thread won't create a new object.
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                        _instance.Value = value;
                    }
                }
            }
            return _instance;
        }

        // we'll use this property to prove that our Singleton really works.
        public string Value { get; set; }
    }
}

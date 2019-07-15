using System;
using System.Threading;

namespace ParallelSync
{
    class MutexClient : Client
    {
        static Mutex mutexObj = new Mutex();
        private static int x = 0;
        public MutexClient()
        {
            Execute();
        }

        public override void Execute()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread myThread = new Thread(Count);
                myThread.Name = "Thread" + i.ToString();
                myThread.Start();
            }
        }

        public static void Count()
        {
            mutexObj.WaitOne();
            x = 1;
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x);
                x++;
                Thread.Sleep(100);
            }
            mutexObj.ReleaseMutex();
        }
    }
}
using System;
using System.Threading;

namespace ParallelSync
{
    class AutoResetEventClient : Client
    {
        static AutoResetEvent waitHandler = new AutoResetEvent(true);
        private static int x = 0;

        public AutoResetEventClient()
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
            waitHandler.WaitOne();
            x = 1;
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x);
                x++;
                Thread.Sleep(100);
            }
            waitHandler.Set();
        }
    }
}
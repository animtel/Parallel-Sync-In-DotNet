using System;
using System.Threading;

namespace ParallelSync
{
    class MonitorExampleClient : Client
    {
        static int x = 0;
        static object locker = new object();

        public override void Execute()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread myThread = new Thread(Count);
                myThread.Name = "Threat " + i.ToString();
                myThread.Start();
            }
        }

        public static void Count()
        {
            try
            {
                Monitor.Enter(locker);
                x = 1;
                for (int i = 1; i < 9; i++)
                {
                    Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x);
                    x++;
                    Thread.Sleep(100);
                }
            }
            finally
            {
                Monitor.Exit(locker);
            }
        }
    }
}
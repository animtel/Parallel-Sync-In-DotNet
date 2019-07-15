using System;
using System.Threading;

namespace ParallelSync
{
    class LockExampleClient : Client
    {
        private static int staticNumber = 0;
        static object locker = new object();

        public LockExampleClient()
        {
            Execute();
        }

        public override void Execute()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread tesThread = new Thread(Count);
                tesThread.Name = "Threat " + i.ToString();
                tesThread.Start();
            }
        }

        public static void Count()
        {
            lock (locker)
            {
                staticNumber = 1;
                for (int i = 0; i < 9; i++)
                {
                    Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, staticNumber);
                    staticNumber++;
                    Thread.Sleep(100);
                }
            }
        }
    }
}
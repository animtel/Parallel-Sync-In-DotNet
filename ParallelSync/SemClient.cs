using System;
using System.Threading;

namespace ParallelSync
{
    class SemClient : Client
    {
        public SemClient()
        {
            Execute();
        }

        public override void Execute()
        {
            for (int i = 1; i < 6; i++)
            {
                var reader = new Reader(i);
            }
        }

        class Reader
        {
            static Semaphore sem = new Semaphore(3, 3);
            private Thread myThread;
            private int count = 3;

            public Reader(int i)
            {
                myThread = new Thread(Read);
                myThread.Name = "Reader " + i.ToString();
                myThread.Start();
            }

            public void Read()
            {
                while (count > 0)
                {
                    sem.WaitOne();

                    Console.WriteLine("{0} log to library", Thread.CurrentThread.Name);

                    Console.WriteLine("{0} reading", Thread.CurrentThread.Name);
                    Thread.Sleep(1000);

                    Console.WriteLine("{0} log out from library", Thread.CurrentThread.Name);

                    sem.Release();

                    count--;
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
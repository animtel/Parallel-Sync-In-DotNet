using System;
using System.Threading;

namespace ParallelSync
{
    class TimerClient:Client
    {
        public TimerClient()
        {
            Execute();
        }
        public override void Execute()
        {
            int callBackInputObj = 0;
            TimerCallback tm = new TimerCallback(Count);
            Timer timer = new Timer(tm, callBackInputObj, 0, 2000);
        }

        public void Count(object callBackInputObj)
        {
            int x = (int)callBackInputObj;
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("{0}", x*i);
            }
        }
    }
}
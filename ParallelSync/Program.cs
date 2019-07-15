using System;
using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Threading;

namespace ParallelSync
{
    class Program
    {
        static void Main(string[] args)
        {
            //var lockExample = new LockExampleClient();
            //var monitorExample = new MonitorExampleClient();
            //var autoResetEventClient = new AutoResetEventClient();
            //var mutexClient = new MutexClient();
            //var semClient = new SemClient();
            //var timerClient = new TimerClient();
            //var oSSingletonClient = new OSSingletonClient();

            Console.ReadKey();
        }

        class OSSingletonClient : Client
        {
            public OSSingletonClient()
            {
                Execute();
            }
            public override void Execute()
            {
                (new Thread(() =>
                {
                    Computer comp2 = new Computer();
                    comp2.OS = OS.GetInstanceOs("Windows 10");
                    Console.WriteLine(comp2.OS.Name);

                })).Start();

                Computer comp = new Computer();
                comp.Launch("Windows 8.1");
                Console.WriteLine(comp.OS.Name);
                Console.ReadLine();
            }

            class Computer
            {
                public OS OS { get; set; }
                public void Launch(string osName)
                {
                    OS = OS.GetInstanceOs(osName);
                }
            }

            class OS
            {
                private static OS instanceOs;

                public string Name { get; private set; }
                private static object syncRoot = new object();

                public OS(string name)
                {
                    Name = name;
                }

                public static OS GetInstanceOs(string name)
                {
                    if (instanceOs == null)
                        lock (syncRoot)
                            if (instanceOs == null)
                                instanceOs = new OS(name);

                    return instanceOs;
                }
            }
        }
    }
}

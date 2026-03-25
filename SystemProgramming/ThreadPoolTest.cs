using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemProgramming;

internal class ThreadPoolTest
{
    public void Run()
    {
        const int N = 3;
        CountdownEvent done = new(N);
        Console.WriteLine("Start main");
        for (int i = 0; i < N; i++)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Console.WriteLine("Thread start");
                Thread.Sleep(500);
                Console.WriteLine("Thread finish");
                done.Signal();
            });
        }


        done.Wait();
        Console.WriteLine("End Main");
    }
}

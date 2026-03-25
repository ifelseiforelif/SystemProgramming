using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemProgramming;

internal class ThreadDemo
{
    private static object _locker = new object();
    private static int _total = 0;
    private static bool _isWork = true;
    public static void Run()
    {
        
    }

    private static void TestThread1()
    {
        const int COUNT_THREADS = 5;
        Thread[] threads = new Thread[COUNT_THREADS];
        for (int i = 0; i < COUNT_THREADS; i++)
        {
            threads[i] = new Thread(Up);
            threads[i].Start();
        }
        for (int i = 0; i < COUNT_THREADS; i++)
        {
            threads[i].Join();
        }
        Console.WriteLine("Total {0}", _total);
        Thread thread = new Thread(() =>
        {
            Console.WriteLine($"Thread by name {Thread.CurrentThread.Name} start....");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

        });
        if (thread.Name == null)
        {
            thread.Name = "Test";
        }
        thread.Start();
        thread.Join();
        Console.WriteLine("Main end");

    }

    private static void TestThread2()
    {
        Thread[] threads = new Thread[Environment.ProcessorCount - 1];

        Console.WriteLine("Start Main");
        Console.WriteLine("Cores: {0}", Environment.ProcessorCount);
        Console.WriteLine($"Core Main {Thread.GetCurrentProcessorId()}");
        Console.WriteLine($"Thread # {Thread.CurrentThread.ManagedThreadId}");
        Thread thread = new Thread(TestThread);
        thread.Start(20);
        //your code
        for (int i = 0; i < 20; i++)
        {
            if (i == 2)
            {
                _isWork = false;
            }
            Console.WriteLine($"Thread # {Thread.CurrentThread.ManagedThreadId} {i}");
            Thread.Sleep(1000);
        }

        thread.Join();
        Console.WriteLine("Finish Main");
    }


    public static void TestThread3()
    {

        Stopwatch time = new Stopwatch();
        time.Start();
        BigData bigData = new BigData(10000);
        bigData.CreateChunk(Environment.ProcessorCount);
        Thread[] threads = new Thread[Environment.ProcessorCount];
        for (int i = 0; i < bigData.Chunks.Count; i++)
        {
            threads[i] = new Thread(Sum);
            threads[i].Start(bigData.Chunks[i]);
        }
        foreach (Thread thread in threads)
        {
            thread.Join();
        }
        time.Stop();
        Console.WriteLine($"Total: {_total} Time: {time.ElapsedMilliseconds} ms");
    }
    private static void Up()
    {
        //RACE CONDITION
        const int N = 10;
        for (int i = 0; i < N; i++)
        {
            lock (_locker)
            {
                ++_total;
            }

            Thread.Sleep(1);
        }
    }

    private static void TestThread(object n)
    {
        for (int i = 0; i < (int)n; i++)
        {
            if (_isWork == false)
            {
                break;
            }
            Console.WriteLine($"Thread # {Thread.CurrentThread.ManagedThreadId} {i}");
            Thread.Sleep(500);
        }
        Thread.Sleep(3000);

        Console.WriteLine("Start TestThread");
        Console.WriteLine($"Core Main {Thread.GetCurrentProcessorId()}");
        Console.WriteLine($"Thread # {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine("Finish TestThread");
    }


    private static void Sum(object numbers)
    {

        int[] array = (int[])numbers;
        _total += array.Sum();


    }

}

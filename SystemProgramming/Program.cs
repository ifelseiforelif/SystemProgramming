using System.Threading;
using System.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;
namespace SystemProgramming;

class Pizza
{
    public string? Name { get; set; }
    public int Price { get; set; }
    public override string ToString()
    {
        return $"{Name} {Price}";
    }
}
class Currency
{
    public int r030 { get; set; }
    public string? txt { get; set; }
    public decimal rate { get; set; }

    public override string ToString()
    {
        return $"Currency: {txt} Rate: {rate}";
    }

}

internal class Program
{
    #region Lock
    //private static object _locker = new object();   
    //private static bool isWork = true;
    //private static int total = 0;
    //static void TestThread(object n)
    //{
    //    for (int i = 0; i < (int)n; i++)
    //    {
    //        if (isWork == false)
    //        {
    //            break;
    //        }
    //        Console.WriteLine($"Thread # {Thread.CurrentThread.ManagedThreadId} {i}");
    //        Thread.Sleep(500);
    //    }
    //    //Thread.Sleep(3000);

    //    //Console.WriteLine("Start TestThread");
    //    //Console.WriteLine($"Core Main {Thread.GetCurrentProcessorId()}");
    //    //Console.WriteLine($"Thread # {Thread.CurrentThread.ManagedThreadId}");
    //    //Console.WriteLine("Finish TestThread");
    //}

    //static void Sum(object numbers)
    //{

    //    int[] array = (int[])numbers;
    //    total += array.Sum();


    //}

    //static void Up()
    //{
    //    //RACE CONDITION
    //    const int N = 10;
    //    for (int i=0;i<N;i++)
    //    {
    //        lock (_locker)
    //        {
    //            ++total;
    //        }

    //        Thread.Sleep(1);
    //    }
    //}
    #endregion
    private static readonly string _url = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";  

    

    static async Task<List<Currency>?> GetCurrency()
    {
        using(HttpClient client = new HttpClient())
        {
            try
            {
                var response = await client.GetStringAsync(_url);
                var obj = JsonSerializer.Deserialize<List<Currency>>(response);
                if (obj != null)
                {
                    return obj;

                }        
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }

    static async Task Main(string[] args)
    {

        var data = await GetCurrency();
        if (data != null)
        {
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }
        Console.ReadLine();


        //Console.WriteLine("Робимо замовлення піци");
        //var pizza = DoPizza();
        //int i = 0;
        //while (!pizza.IsCompleted)
        //{

        //    Console.WriteLine($"Ми працюємо {i}....");
        //    Thread.Sleep(500);
        //    i++;

        //}

        //pizza.Wait();
        //Console.WriteLine("Отримали піцу");
        //Console.WriteLine(pizza.Result);

        //const int N = 3;
        //CountdownEvent done = new (N);
        //Console.WriteLine("Start main");
        //for (int i = 0; i < N; i++)
        //{
        //    ThreadPool.QueueUserWorkItem(_ => {
        //        Console.WriteLine("Thread start");
        //        Thread.Sleep(500);
        //        Console.WriteLine("Thread finish");
        //        done.Signal();
        //    });
        //}


        //done.Wait();
        //Console.WriteLine("End Main");


        //const int COUNT_THREADS = 5;
        //Thread[] threads = new Thread[COUNT_THREADS];
        //for (int i = 0; i < COUNT_THREADS; i++)
        //{
        //    threads[i] = new Thread(Up);
        //    threads[i].Start(); 
        //}
        //for (int i = 0; i < COUNT_THREADS; i++)
        //{
        //    threads[i].Join();
        //}
        //Console.WriteLine("Total {0}", total);
        //Thread thread = new Thread(() =>
        //{
        //    Console.WriteLine($"Thread by name {Thread.CurrentThread.Name} start....");
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine(i);
        //    }

        //});
        //if(thread.Name==null)
        //{
        //    thread.Name = "Test";
        //}
        //thread.Start();
        //thread.Join();
        //Console.WriteLine("Main end");


        #region Threading Intro
        //Thread[] threads = new Thread[Environment.ProcessorCount-1];
        ////new ProcessDemo().Run();
        //// new WorkerDllCPlusPlus().Run();
        //Console.WriteLine("Start Main");
        //Console.WriteLine("Cores: {0}", Environment.ProcessorCount);
        //Console.WriteLine($"Core Main {Thread.GetCurrentProcessorId()}");
        //Console.WriteLine($"Thread # {Thread.CurrentThread.ManagedThreadId}");
        //Thread thread = new Thread(TestThread);
        //thread.Start(20);
        ////your code
        //for (int i = 0; i < 20; i++)
        //{
        //    if(i==2)
        //    {
        //        isWork = false;
        //    }
        //    Console.WriteLine($"Thread # {Thread.CurrentThread.ManagedThreadId} {i}");
        //    Thread.Sleep(1000);
        //}

        //thread.Join();
        //Console.WriteLine("Finish Main");
        #endregion
        //Stopwatch time = new Stopwatch();
        //time.Start();
        //BigData bigData = new BigData(10000);
        //bigData.CreateChunk(Environment.ProcessorCount);
        //Thread[] threads = new Thread[Environment.ProcessorCount];
        //for(int i=0;i<bigData.Chunks.Count;i++)
        //{
        //    threads[i] = new Thread(Sum);
        //    threads[i].Start(bigData.Chunks[i]);
        //}
        //foreach (Thread thread in threads)
        //{
        //    thread.Join();
        //}
        //time.Stop();
        //Console.WriteLine($"Total: {total} Time: {time.ElapsedMilliseconds} ms");


    }





    static async Task<Pizza> DoPizza()
    {
        Console.WriteLine("Отримали замовлення");
        Console.WriteLine("Починаємо готувати");
        await Task.Delay(500);
        Console.WriteLine("Готуємо тісто ");
        await Task.Delay(1000);
        Console.WriteLine("Готуємо начинку ");
        await Task.Delay(3000);
        Console.WriteLine("Випікаємо піцу тісто ");
        await Task.Delay(3000);
        Console.WriteLine("Все готове ");
        return new Pizza { Name = "Margarita", Price = 300 };
    }
}

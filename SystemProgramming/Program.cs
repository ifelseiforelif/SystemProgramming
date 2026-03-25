using System.Threading;
using System.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using SystemProgramming.Models;
namespace SystemProgramming;

internal class Program
{


    static async Task Main(string[] args)
    {

        //await new CurrencyAsync().RunAsync();
        //await new PizzaAsync().RunAsync();
        //new ProcessDemo().Run();
        // new WorkerDllCPlusPlus().Run();
        new ThreadPoolTest().Run();

    }


}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemProgramming;

internal class ProcessDemo
{
    public void Run()
    {
        Console.WriteLine("Process Demo");
        ShowAllProcesses();
    }

    private void ShowAllProcesses()
    {
        //Вивести у консоль перелік процесів та ті, які повторюються порахувати їх кількість і вивести напроти імені
        //процеса цю кількість
        Process[] processes = Process.GetProcesses();
        Dictionary<String, int> procs = new Dictionary<String, int>();
        foreach (var process in processes)
        {
            try
            {
                Console.WriteLine($"{process.ProcessName} PID: {process.Id}");
            }
            catch(Exception)
            {
                Console.WriteLine("Unknown process");
            }
         
        }
    }
}

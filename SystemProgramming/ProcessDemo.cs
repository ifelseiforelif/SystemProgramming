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
        ConsoleKeyInfo key;
        do
        {
            Console.WriteLine("Process Demo");
            Console.WriteLine("1 - ShowAllProcessesFilter");
            Console.WriteLine("2- ShowAllProcesses");
            Console.WriteLine("3 - GetProcessByPid");
            Console.WriteLine("4 - CreateProcess");
            Console.WriteLine("5 - KillProcess");
            Console.WriteLine("0 - Exist");
            key = Console.ReadKey();
            switch (key.KeyChar)
            {
                case '1':
                    ShowAllProcessesFilter();
                    break;
                case '2':
                    ShowAllProcesses();
                    break;
                case '3':
                    GetProcessByPid();
                    break;
                case '4':
                    CreateProcess();
                    break;
                default :
                    Console.WriteLine("unknown operation");
                    break;

            }
        } while(key.KeyChar != '0');
      

    }


    private void GetProcessByPid()
    {
        try
        {
            Console.WriteLine("Enter pid:");
            int pid = Convert.ToInt32(Console.ReadLine());
            var process = Process.GetProcessById(pid);
            Console.WriteLine($"{process.ProcessName}");
        } catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
       
    }
    private void ShowAllProcessesFilter()
    {
        //Вивести у консоль перелік процесів та ті, які повторюються порахувати їх кількість і вивести напроти імені
        //процеса цю кількість
        Process[] processes = Process.GetProcesses();
        Dictionary<String, int> taskManager = new Dictionary<String, int>();
        foreach (var process in processes)
        {
            string processName =string.Empty;
            try
            {
                processName = process.ProcessName;
            }
            catch (Exception)
            {
                processName = "unknown";
            }
            if(taskManager.ContainsKey(processName))
            {
                taskManager[processName] += 1;
            }
            else
            {
                taskManager[processName] = 1;
            }
        }
        foreach (var process in taskManager)
        {
            Console.WriteLine($"{process.Key} {process.Value}");
        }
    }
    private void ShowAllProcesses()
    {
        Process[] processes = Process.GetProcesses();

        foreach (var process in processes)
        {
            Console.WriteLine($"{process.ProcessName} PID: {process.Id}");
        }
    }
    private void CreateProcess()
    {
        Console.WriteLine("Enter programm name: ");
        string? programm = Console.ReadLine();
        if (programm != null)
        {
            Console.WriteLine(Process.Start(programm).Id) ;
        }
    }
}

/*
 1) Якщо ви процес запустили, і він ще працює, то знову не запускати
 2) Зробити метод, який дозволить вбити обраний процес
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemProgramming.Models;

namespace SystemProgramming;

internal class PizzaAsync
{
    public async Task RunAsync()
    {


        Console.WriteLine("Робимо замовлення піци");
        var pizza = DoPizzaAsync();
        int i = 0;
        while (!pizza.IsCompleted)
        {

            Console.WriteLine($"Ми працюємо {i}....");
            Thread.Sleep(500);
            i++;

        }

        await pizza;
        Console.WriteLine("Отримали піцу");
        Console.WriteLine(pizza.Result);

    }
    private static async Task<Pizza> DoPizzaAsync()
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

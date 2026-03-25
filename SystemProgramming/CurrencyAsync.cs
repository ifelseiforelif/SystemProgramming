using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SystemProgramming.Models;

namespace SystemProgramming;

internal class CurrencyAsync
{
    private static readonly string _url = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";

    public async Task RunAsync()
    {
        var data = await GetCurrencyAsync();
        if (data != null)
        {
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }
        Console.ReadLine();
    }

 
    private static async Task<List<Currency>?> GetCurrencyAsync()
    {
        using (HttpClient client = new HttpClient())
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }

}

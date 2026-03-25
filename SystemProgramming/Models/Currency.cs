using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemProgramming.Models;

internal class Currency
{
    public int r030 { get; set; }
    public string? txt { get; set; }
    public decimal rate { get; set; }

    public override string ToString()
    {
        return $"Currency: {txt} Rate: {rate}";
    }
}

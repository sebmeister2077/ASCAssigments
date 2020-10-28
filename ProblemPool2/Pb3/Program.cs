using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            n = int.Parse(Console.ReadLine());
            int s = 0, p = 1;
            for(int i=1;i<=n;i++)
            { s += i;p *= i; }
            Console.WriteLine($"Suma={s}\nProdusul={p}");
        }
    }
}

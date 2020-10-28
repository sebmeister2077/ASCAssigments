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
            int n, k;
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());
            if(n%k==0)
                Console.WriteLine($"{n} se divide cu {k}");
            else
                Console.WriteLine($"{n} nu se divide cu {k}");

        }
    }
}

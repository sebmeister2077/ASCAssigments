using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb15
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            c = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine(Math.Min(Math.Min(a,b),c));
            Console.WriteLine(Math.Min(Math.Max(a,b),Math.Min(Math.Max(a,c),Math.Max(c,b))));
            Console.WriteLine(Math.Max(Math.Max(a,b),c));
        }
    }
}

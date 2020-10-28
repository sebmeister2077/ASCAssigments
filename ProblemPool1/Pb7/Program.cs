using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb7
{
    class Program
    {
        static void SwapMethod(ref int a,ref int b)
        {
            int aux = a;
            a = b;
            b = aux;
        }
        static void Main(string[] args)
        {
            int a, b;
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            SwapMethod(ref a,ref b);
            Console.WriteLine();
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}

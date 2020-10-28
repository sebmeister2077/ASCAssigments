using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb8
{
    class Program
    {
        static void Swap(ref int a,ref int b)
        {
            a += b;
            b = a-b;
            a -= b;

        }
        static void Main(string[] args)
        {
            int a, b;
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            Swap(ref a,ref b);
            Console.WriteLine();
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}

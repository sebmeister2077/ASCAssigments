using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb12
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, n,result=0;
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            n = int.Parse(Console.ReadLine());
            for (int i = a; i <= b; i++)
                if (i % n == 0)
                    result++;
            Console.WriteLine(result);

        }
    }
}

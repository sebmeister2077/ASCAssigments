using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb10
{
    class Program
    {
        static bool Prim(int nr)
        {
            if (nr <= 1)
                return false;
            for(int i=2;i<nr;i++)
                if(nr%i==0)
                    return false;
            return true;
        }
        static void Main(string[] args)
        {
            int n;
            n = int.Parse(Console.ReadLine());
            if(Prim(n))
                Console.WriteLine($"{n} este prim");
            else
                Console.WriteLine($"{n} nu este prim");
        }
    }
}

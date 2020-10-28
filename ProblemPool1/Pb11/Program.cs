using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb11
{
    class Program
    {
        static void Main(string[] args)
        {

            int n;
            n = int.Parse(Console.ReadLine());
            while(n>0)
            {
                Console.Write(n%10+" ");
                n /= 10;
            }
        }
    }
}

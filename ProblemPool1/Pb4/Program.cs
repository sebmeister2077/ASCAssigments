using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti anul: ");
            int an = int.Parse(Console.ReadLine());
            if(an%4==0)
                Console.WriteLine("Anul {0} este bisect",an);
            else
                Console.WriteLine("Anul {0} nu este bisect", an);
        }
    }
}

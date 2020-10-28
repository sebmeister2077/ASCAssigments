using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb6
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            c = int.Parse(Console.ReadLine());
            if((a+b)>c&&(b+c)>a&&(a+c)>b)
                Console.WriteLine("Cele 3 numere pot forma un triunghi");
            else
                Console.WriteLine("Cele 3 numere nu pot forma un triunghi");


        }
    }
}

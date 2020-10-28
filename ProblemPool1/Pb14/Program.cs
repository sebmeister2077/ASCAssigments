using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb14
{
    class Program
    {
        static void Main(string[] args)
        {
            int nr;
            nr = int.Parse(Console.ReadLine());
            int aux = nr, oglindit = 0;

            while(aux>0)
            {
                oglindit = oglindit * 10 + aux % 10;
                aux /= 10;
            }
            if(oglindit==nr)
                Console.WriteLine("Este palindrom");
            else
                Console.WriteLine("Nu este palindrom");
        }
    }
}

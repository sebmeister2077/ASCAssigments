using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb1
{
    class Program
    {
        static void Main(string[] args)
        {
            string aux;
            int nr = 0;
            do
            {
                aux = Console.ReadLine();
                if (aux != "")
                    if (int.Parse(aux) % 2 == 0)
                        nr++;

            } while (aux != "");
            Console.WriteLine(nr);


        }
    }
}

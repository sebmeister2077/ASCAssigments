using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb16
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c, d, e;
            List<int> lista = new List<int>();
            a = int.Parse(Console.ReadLine());
            lista.Add(a);
            b = int.Parse(Console.ReadLine());
            lista.Add(b);
            c = int.Parse(Console.ReadLine());
            lista.Add(c);
            d = int.Parse(Console.ReadLine());
            lista.Add(d);
            e = int.Parse(Console.ReadLine());
            lista.Add(e);

            lista.Sort();
            foreach(int nr in lista)
                Console.WriteLine(nr);


        }
    }
}

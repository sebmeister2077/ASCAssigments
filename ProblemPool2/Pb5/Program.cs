using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n,count=0;
            int[] secv;
            n = int.Parse(Console.ReadLine());
            secv = new int[n];
            for (int i = 0; i < n; i++)
                if (i == secv[i])
                    count++;
            Console.WriteLine(count);

        }
    }
}

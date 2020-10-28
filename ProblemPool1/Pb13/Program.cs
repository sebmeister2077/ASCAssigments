using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb13
{
    class Program
    {
        static void Main(string[] args)
        {
            int y1, y2,result=0;
            y1 = int.Parse(Console.ReadLine());
            y2 = int.Parse(Console.ReadLine());
            for (int i = y1 + 1; i < y2; i++)
                if (i % 4 == 0)
                    result++;
            Console.WriteLine(result);

        }
    }
}

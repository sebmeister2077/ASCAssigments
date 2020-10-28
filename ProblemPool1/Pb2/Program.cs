using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb2
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;
            a = double.Parse(Console.ReadLine());
            b = double.Parse(Console.ReadLine());
            c = double.Parse(Console.ReadLine());
            if (a == 0)
            {
                Console.WriteLine("necunoscuta ecuatie de gradul 1 este {0}",(0-b)/a);
            }
            else
            {
                if (b * b - (4 * a * c) < 0)
                {
                    Console.WriteLine("Nu exista solutie in R");
                }
                else
                {
                    if (b * b - (4 * a * c) == 0)
                    {
                        Console.WriteLine("Necunoscuta este {0} ", (-b + Math.Sqrt(b * b - (4 * a * c))) / (2 * a));
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.Write("Necunoscuta este {0} ", (-b + Math.Sqrt(b * b - (4 * a * c))) / (2 * a));
                        Console.WriteLine("Si {0}", (-b - Math.Sqrt(b * b - (4 * a * c))) / (2 * a));
                    }
                }
            }

        }
    }
}

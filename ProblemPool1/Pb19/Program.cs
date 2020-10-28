using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb19
{
    class Program
    {
        static bool FormatDin2Cifre(int nr)
        {
            if (nr < 100)
                return true;
            int a = -1, b = -1;
            while(nr>0)
            {
                if(a==-1)
                {
                    a=nr % 10;
                }
                else
                {
                    if (nr % 10 != a)
                        if (b == -1)
                        {
                            b = nr % 10;
                        }
                        else
                            if (nr % 10 != b)
                            return false;

                }
                nr /= 10;
            }
            return true;

        }
        static void Main(string[] args)
        {
            int nr;
            nr = int.Parse(Console.ReadLine());
            Console.WriteLine(FormatDin2Cifre(nr));
            


        }
    }
}

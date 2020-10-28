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
            string nr;
            int aux,poz=0,neg=0,nul=0;
            do
            {
                nr = Console.ReadLine();
                if (!int.TryParse(nr, out aux))
                    break;
                else
                {
                    if (aux > 0)
                        poz++;
                    else
                        if (aux < 0)
                        neg++;
                    else
                        nul++;
                }

            } while (nr != "");
            Console.WriteLine($"Numere pozitive:{poz}\nNumere negative:{neg}\nNumere nule:{nul}");


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooresLaw
{
    class Program
    {
        static void Main(string[] args)
        {
            string consol;
            double cateOri;
            while (true)
            {
                Console.WriteLine("Introduceti un numar n pentru a se afla timpul necesar ca tranzistoarele sa devine de n-ori mai dense decat in momentul actual:");
                consol = Console.ReadLine();
                //folosim tryparse pentru a transmite o informatie in plus (daca s-a efectuat corect transformarea) if-ului
                if (double.TryParse(consol, out cateOri))
                {
                    double ani;
                    ani = 1.5*Math.Log(cateOri,2);
                    Console.WriteLine("Tranzistoarele vor fi mai dense de {0} ori in {1} ani",cateOri,ani);
                    break;
                }
                else
                {
                    Console.WriteLine("Introduceti un numar rational.");
                    Console.WriteLine("");
                    //se va repeta pana cand utilizatorul introduce un numar valabil
                }
            }
            




        }
    }
}

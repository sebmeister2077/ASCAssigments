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
            int nr = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            if(k<=0||k>=12)
                Console.WriteLine("k e negativ sau prea mare");
            else
            {    
                while(k>1)
                {
                    nr /= 10;
                    k--;
                }
                 Console.WriteLine(nr%10);
            }
        }
    }
}

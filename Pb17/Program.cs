using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb17
{
    class Program
    {
        static int CMMDC(int a,int b)
        {
            if (b == 0)
                return a;
            else
                return CMMDC(b,a%b);       
        }
        static int CMMMC(int a,int b)
        {
            if(b>a)
            {
                int aux = a;
                a = b;
                b = aux;
            }
            int P = a * b;
            int r = a % b;
            while(r!=0)
            {
                a = b;
                b = r;
                r = a % b;
            }
            return P / b;

        }
        static void Main(string[] args)
        {
            int a, b;
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());

            Console.WriteLine(CMMDC(a, b));
            Console.WriteLine(CMMMC(a,b));
        }
    }
}

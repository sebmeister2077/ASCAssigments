using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemPool2
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        static int P1()
        {
            int par = 0;
            string str = Console.ReadLine();
            while(str!="")
            {
                par += (int.Parse(str)+1) % 2;//daca e nr par va deveni impar asadar modulo 2 va incrementa pe variabila par
                str = Console.ReadLine();
            }
            return par;
        }
        static void P2()
        {
            int neg=0, zero=0, poz = 0;
            string str = Console.ReadLine();
            while(str!="")
            {
                int aux = int.Parse(str);
                neg += aux < 0 ? 1 : 0;
                zero += aux == 0 ? 1 : 0;
                poz += aux > 0 ? 1 : 0;
                str = Console.ReadLine();
            }
        }
        static void P3(int n)
        {
            Console.WriteLine("Suma:{0}",n*(n+1)/2);
            int p = 1;
            for (int i = 2; i <= n; i++)
                p *= i;
            Console.WriteLine("Produsul:{0}",p);
        }
        static int P4(int a)
        {
            int poz = -1, currentpoz = 0;
            string str = Console.ReadLine();
            while (str != "")
            {
                int aux = int.Parse(str);
                if (aux == a)
                    poz = currentpoz;
                currentpoz++;
                str = Console.ReadLine();
            }
            return poz;
        }
        static int P5()
        {
            int currentpoz=0, nr = 0;
            string str = Console.ReadLine();
            while (str != "")
            {
                int aux = int.Parse(str);
                if (aux == currentpoz++)
                    nr++;
                str = Console.ReadLine();
            }
            return nr;
        }
        static bool P6()
        {
            int previous = int.MinValue;
            string str = Console.ReadLine();
            while (str != "")
            {
                int aux = int.Parse(str);
                if (previous > aux)
                    return false;
                str = Console.ReadLine();
            }
            return true;
        }
        static void P7()
        {
            int min, max;
            string str = Console.ReadLine();
            min = max = int.Parse(str);
            str = Console.ReadLine();
            while (str != "")
            {
                int aux = int.Parse(str);
                if (aux > max)
                    max = aux;
                if (aux < min)
                    min = aux;
                str = Console.ReadLine();
            }
            Console.WriteLine($"Minimul:{min}\nMaximul:{max}");
        }
        static int P8(int n)
        {
            int a1 = 0,a2 = 1,a3=1;
            if (n == 1)
                return a1;
            if (n == 2)
                return a2;
            for(int i=3;i<=n;i++)
            {
                a3 = a1 + a2;
                a1 = a2;
                a2 = a3;
            }
            return a3;
        }
        static bool P9()
        {
            
            bool cresc=false, descr = false;
            string str = Console.ReadLine();
            int previous = int.Parse(str);
            str = Console.ReadLine();
            while (str != "")
            {
                int aux = int.Parse(str);
                if (previous > aux)
                    if (cresc == true)
                        return false;
                    else
                        descr = true;
                if (previous < aux)
                    if (descr == true)
                        return false;
                    else
                        cresc = true;
                str = Console.ReadLine();
            }
            return true;
        }
    }
}

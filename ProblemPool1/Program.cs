using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProblemPool1
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            P18(23457);
        }
        static void P1()
        {
            int a, b;
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("x={0}",-b/a);
        }
        static void P2()
        {
            int a, b,c;
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            c = int.Parse(Console.ReadLine());
            int delta = b * b - 4 * a * c;
            if(delta<0)
                Console.WriteLine("Nu avem solutie reala.");
            else
                if(delta==0)
                Console.WriteLine("Solutie:{0}",(-b+Math.Sqrt(delta))/(2*a));
            else
                Console.WriteLine("Solutii:{0} si {1}", (-b + Math.Sqrt(delta)) / (2 * a), (-b - Math.Sqrt(delta)) / (2 * a));
        }
        static bool P3(int n,int k)
        {
            return n % k==0;
        }
        static bool P4(int an)
        {
            return an % 4 == 0;
        }
        static void P5(ref int nr,int k)
        {
            if (k < 1 || k > nr.ToString().Length)
            {
                Console.WriteLine("K invalid");
                return;
            }
            int aux = nr;
            string aux2 = "";
            for(int i=0;i<k-1;i++)
            {
                aux2 = (aux % 10).ToString() + aux2; ;
                aux /= 10;
            }
            Console.WriteLine(aux%10);
            aux /= 10;
            if (aux != 0)
                aux2 = aux.ToString() + aux2;
            //inlocuim pe nr cu  nr fara a k-a cifra
            nr = int.Parse(aux2);
        }
        static bool P6(int a,int b,int c)
        {
            return a > 0 && b > 0 && c > 0 && a + b > c && b + c > a && a + c > b;
        }
        static void Swap(ref int a,ref int b)
        {
            int aux = a;
            a = b;
            b = aux;
        }
        static void P8(ref int a,ref int b)
        {
            a = a + b;
            b = a - b;//=a initial
            a = a - b;//=b initial
        }
        static void P9(int n)
        {
            for (int i = 1; i <= n / 2; i++)
                if (n % i == 0)
                    Console.Write($"{i},");
            Console.WriteLine(n);
        }
        static bool P10(int n)
        {
            if (n < 2)
                return false;
            if (n == 2)
                return true;
            for (int i = 3; i <= n / 3; i += 2)
                if (n % i == 0)
                    return false;
            return true;
        }
        static void P11(int n)
        {
            while(n>9)
            {
                Console.Write($"{n%10},");
                n /= 10;
            }
            Console.WriteLine(n);
        }
        static int P12(int a,int b,int n)
        {
            if (a > b)
                return 0;
            if ((b - a) % n == 0)
                if (a % n == 0 || b % n == 0)//daca e [6,12] (6-12)/6=1
                    return (b-a) / n + 1;
                else
                    return (b-a) / n;
            int aux = 0;
            if (b-a<n)
            {
                for (int i = a + 1; i <= b; i++)
                    if (i % n == 0)
                        return 1;
                return 0;
            }
            aux += P12(b - b % n, b, n);//facem recursiv pt intervalele mai mici(de lungime maxima n)
            aux += P12(a-1, a + (n - a % n - 1), n);
            aux = Math.Min(aux, 1);
            return (b-a) / n + aux;
        }
        static int P13(int y1,int y2,bool firststep=true)
        {
            if(firststep)
            {
                //nu se pun anii bisecti chiar la margine(zice intre)
                if (y1 % 4 == 0)
                    y1++;
                if (y2 % 4 == 0)
                    y2--;
            }
            if (y2 - y1 <= 4)
                if ((y1 % 4 >= y2 % 4&&y2!=y1)||y1%4==0||y2%4==0)//anul dinaintea anului bisect are modulo 4 cel mai mare
                    return 1;
                else
                    return 0;
            else
                return (y2 - y1) / 4 + Math.Min(1, P13(y1, y1 + (4 - y1 % 4)-1,false) + P13(y2 - y2 % 4, y2,false));
        }
        static bool P14(int n)
        {
            int aux = n,ogl=0;
            while(aux>0)
            {
                ogl = ogl * 10 + aux % 10;
                aux /= 10;
            }
            return ogl == n;
        }
        static void P15(int a,int b,int c)
        {
            Console.WriteLine(Math.Min(a,Math.Min(b,c)));
            Console.WriteLine(Math.Min(Math.Min(Math.Max(a,b),Math.Max(a,c)),Math.Max(b,c)));
            Console.WriteLine(Math.Max(a,Math.Max(b,c)));
        }
        static int FindMin(int a,int b,int c=int.MaxValue,int d=int.MaxValue,int e=int.MaxValue)
        {
            return Math.Min(Math.Min(a, b), Math.Min(c, Math.Min(d, e)));
        }
        static void P16(int a,int b,int c,int d,int e)
        {
            int min=FindMin(a, b, c, d, e);
            Console.WriteLine(min);
            a = a == min ? e : a;
            b = b == min ? e : b;
            c = c == min ? e : c;
            d = d == min ? e : d;
            min = FindMin(a, b, c, d);
            Console.WriteLine(min);
            a = a == min ? d : a;
            b = b == min ? d : b;
            c = c == min ? d : c;
            min = FindMin(a, b, c);
            Console.WriteLine(min);
            a = a == min ? c : a;
            b = b == min ? c : b;
            Console.WriteLine(Math.Min(a,b));
            Console.WriteLine(Math.Max(a,b));
        }
        static int cmmdc(int a,int b)
        {
            while (b > 0)
                if (a > b)
                    a -= b;
                else
                    b -= a;
            return a;
        }
        static void P17(int a,int b)
        {
            Console.WriteLine($"cmmdc:{cmmdc(a,b)}");
            Console.WriteLine($"cmmmc:{a*b/cmmdc(a,b)}");
        }
        static void P18(int n)
        {
            int putere = 0,lastprime=2;
            while(n>1)
            {
                for(int i=lastprime;i<=n;i++)
                    if(n%i==0)
                    {
                        if (i != lastprime && putere > 0)
                        {
                            Console.Write($"{lastprime}^{putere}x");
                            putere = 0;
                        }
                        lastprime = i;
                        putere++;
                        n /= i;
                        break;//breaks the for
                    }
            }
            Console.WriteLine($"{lastprime}^{putere}");
        }
        static bool P19(int n)
        {
            char a='-', b='-';
            foreach (char c in n.ToString())//iteram prin cifre
                if (a == '-')
                    a = c;
                else
                    if (c != a)
                    if (b == '-')
                        b = c;
                    else
                        if(c!=b)
                        return false;
            return true;
        }
        static void P20(int m,int n)
        {
            //https://github.com/sebmeister2077/ASCAssigments/blob/main/Conversii/Program.cs
            // de la linia 156 ,char[] formareDec o sa fie numarul rezultat de ex 0.033333333...
            //dupa care verifica SECVENTELE care se repeta si va insera parantezele la locul lor potrivit(cele 2 whileuri de pe linia 203 ai 209): 0.0(3); noua variabila cu perioada va fi inCaseOfProb
            //desigur precizia se putea modifica ca si in conversia din baza 10(a doua jumatate,linia 257) unde am pus sa gaseasca parioada in primele 2000 de zecimale
        }
        static void P20()
        {
            //create random nr;
            int nr = rnd.Next() % 1024 +1;
            bool reia = true;
            while(reia)
            {
                Console.WriteLine("A-Numarul este mai mare sau egal decat...?");
                Console.WriteLine("B-Numarul este divizibil cu....?");
                Console.WriteLine("R-Numarul este egal cu....?");
                string command = Console.ReadLine();
                int nrcitit = int.Parse(Console.ReadLine());
                switch(command)
                {
                    case "A":
                        Console.WriteLine(nr>=nrcitit);
                        break;
                    case "B":
                        Console.WriteLine(nr%nrcitit);
                        break;
                    case "R":
                        Console.WriteLine(nr==nrcitit);
                        reia = !(nr == nrcitit);
                        break;
                }
            }
        }
    }
}

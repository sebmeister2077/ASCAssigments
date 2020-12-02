using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigNumbers
{
    class Program
    {
        static void AdunareFct(ref Stack<string>  stfin, ref Stack<string> stack,ref Stack<string> stack2,bool doua=false)
        {
            int aux = int.Parse(stack.Pop());
            if(doua)
                aux+= int.Parse(stack2.Pop());
            if (aux > 9&&stack.Count>0)
            {
                int auxaux = int.Parse(stack.Pop());
                auxaux++;
                stack.Push(auxaux.ToString());
                aux -= 10;
            }
            stfin.Push(aux.ToString());
        }
        static string Adunare(string str1,string str2)
        {
            Stack<string> st1, st2,stfin;
            st1 = new Stack<string>();
            st2 = new Stack<string>();
            stfin = new Stack<string>();
            foreach (char c in str1)
                st1.Push(c.ToString());
            foreach (char c in str2)
                st2.Push(c.ToString());
            while(st1.Count>0||st2.Count>0)
            {
                if (st1.Count == 0 || st2.Count == 0)
                {
                    if (st1.Count > 0)
                        AdunareFct(ref stfin, ref st1, ref st1);
                    else
                        AdunareFct(ref stfin, ref st2, ref st2);
                }
                else
                    AdunareFct(ref stfin,ref st1,ref st2, true);
            }
            StringBuilder str = new StringBuilder();
            while (stfin.Count > 0)
                str.Append(stfin.Pop());
            return str.ToString();
        }
        static string Scadere(string str1, string str2)
        {
            return "";
        }
        static string Inmultire(string str1, string str2)
        {
            return "";
        }
        static string Impartire(string str1, string str2)
        {
            return "";
        }
        static string Putere(string str1, string str2)
        {
            return "";
        }
        static string RadicalPatrat(string str1,string str2)
        {
            return "";
        }
        static void Main(string[] args)
        {
            while (true)
            {
                string nr1, nr2 = "", strop;
                nr1 = Console.ReadLine();
                strop = Console.ReadLine();
                if (strop != "sqrt")
                    nr2 = Console.ReadLine();
                switch (strop)
                {
                    case "+":
                        Console.WriteLine(Adunare(nr1, nr2));
                        break;
                    case "-":
                        Console.WriteLine(Scadere(nr1, nr2));
                        break;
                    case "*":
                        Console.WriteLine(Inmultire(nr1, nr2));
                        break;
                    case "/":
                        Console.WriteLine(Impartire(nr1, nr2));
                        break;
                    case "^":
                        Console.WriteLine(Putere(nr1, nr2));
                        break;
                    case "sqrt":
                        Console.WriteLine(RadicalPatrat(nr1, nr2));
                        break;
                }
                Console.WriteLine("\n\n");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversii
{
    class Program
    {
        static void Main(string[] args)
        {

            
             
            string numar;
            char[] nrintreg=new char[20],nrdec=new char[20];
            int baza,bazaprinc;
            bool esteNegativ = false;
            Stack<int> stiva = new Stack<int>();
            Console.WriteLine("Introduceti baza principala: ");
            if (int.TryParse(Console.ReadLine(), out bazaprinc)&&bazaprinc>=2&&bazaprinc<=256)
            {
                Console.WriteLine("Va rog introduceti un numar valid: ");
                numar = Console.ReadLine();
                Console.WriteLine("Introduceti baza de convertire");
                if (int.TryParse(Console.ReadLine(), out baza) && baza >= 2 && baza <= 256)
                {
                    double nr1 = 0;
                    decimal nr2 = 0;
                    bool stg = true;
                    int x = 0, y = 0;
                    foreach (char c in numar)
                    {
                        if (c == '.')
                        { stg = false; continue; }
                        if (c == '-')
                        { esteNegativ = true; continue; }
                        if (stg)
                            nrintreg[x++] = c;
                        else
                            nrdec[y++] = c;
                    }
                    x--;
                    if (bazaprinc != 10)//conversie IN baza 10
                    {
                        foreach (char c in nrintreg)
                        {
                            if (c >= '0' && c <= '9')
                                nr1 +=(int)(c-'0')*(int)Math.Pow(bazaprinc, x);
                            else
                                nr1 += (int)(c-'A'+10)*(int)Math.Pow(bazaprinc,  x);
                            x--;
                            if (x == -1)
                                break;
                            
                        }
                        int auxy = y;

                        Console.WriteLine(y);
                        y = -1;
                        foreach (char c in nrdec)
                        {
                            if (auxy == 0)
                                break;
                            if (c >= '0' && c <= '9')
                                nr2 += (c-'0')*(decimal)Math.Pow(bazaprinc, y);
                            else
                                nr2 += (c-'A'+10)*(decimal)Math.Pow(bazaprinc, y);
                            y--;
                            Console.Write("C={0}", c);
                            if (y == -1*auxy)
                                break;
                        }
                        Console.WriteLine();
                        if(nr2>1)//daca trebuie adaugat unitati la numarul intreg
                        {
                            nr1 += (int)nr2;
                            nr2 -= (int)nr2;//se va sterge partea intreaga chiar daca nu ar conta asta
                        }
                    }

                    //Conversie DIN baza 10
                    string str = "";
                    if (baza != 10)
                    {
                        string partea2int, partea2dec;
                        if (nr1 == 0.0D && nr2 == 0.0M)
                        {
                            string s = "";
                            foreach (char c in nrintreg)
                                s += c;
                            if (baza > 10)
                                partea2int = s;
                            else
                                nr1 = Double.Parse(s);
                            s = "0.";
                            foreach (char c in nrdec)
                                s += c;
                            if (baza > 10)
                                partea2dec = s;
                            else
                                nr2 = Decimal.Parse(s);
                        }
                        if (baza < 10)//Intro baza mai mica
                        {
                            while (nr1 > 0)
                            {
                                str += nr1 % baza;
                                nr1 = (int)nr1 / baza;
                            }
                            str += ".";
                            if (nr2 == 0.0M)
                            {
                                str += "0";
                            }
                            else
                            {
                                List<int> finalDecResults = new List<int>();
                                List<decimal> pastValues = new List<decimal>();
                                bool done = false;
                                while (nr2 != 0.0M)
                                {
                                    nr2 = nr2 * baza;
                                    finalDecResults.Add((int)nr2);
                                    pastValues.Add(nr2);
                                    nr2 = nr2 - (int)nr2;
                                    if (pastValues.Count > 1 && pastValues.Contains(nr2))//s-a regasit acelasi deimpartit => exista o perioada
                                    {
                                        int i = 1, j = 1;
                                        foreach (decimal past in pastValues)
                                        {
                                            if (past == nr2)
                                                break;
                                            i++;
                                        }
                                        foreach (int result in finalDecResults)
                                        {
                                            if (i == j)
                                                str += "(";
                                            str += result.ToString();
                                            j++;
                                        }
                                        str += ")";
                                        done = true;
                                    }
                                    if (done == true)
                                        break;

                                }
                                if (!done)
                                    foreach (int result in finalDecResults)
                                    {
                                        str += result.ToString();
                                    }
                            }
                        }
                        else
                        {//intr.o baza mai mare









                        }
                    }
                    else
                        str += nr1.ToString() +"."+nr2.ToString();
                    //REZULTAT 
                    if (esteNegativ == true)
                        Console.Write("-");
                    Console.WriteLine(str);
                }
                else
                   Console.WriteLine("Ati introdus o baza invalida");
            }
            else
                Console.WriteLine("Baza numarului este invalida");
        }
    }
}

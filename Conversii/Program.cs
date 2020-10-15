using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversii
{
    class Program
    {
        private static char CautaCaracter(double x)
        {
            if (x >= 0 && x <= 9)
                return (char)('0'+x);
            if (x >= 10)
                return (char)('A' + x-10);
            return '=';
        }
        static void Main(string[] args)
        {
            string numar;
            char[] nrintreg=new char[20],nrdec=new char[20];
            int baza,bazaprinc;
            bool esteNegativ = false;
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

                    #region Conversie IN Baza 10
                    if (bazaprinc != 10)//conversie IN baza 10
                    {
   
                        foreach (char c in nrintreg)
                        {
                            if (c >= '0' && c <= '9')
                                nr1 +=(int)(c-'0'+0)*(int)Math.Pow(bazaprinc, x);
                            else
                                nr1 += (int)(c-'A'+10)*(int)Math.Pow(bazaprinc,  x);
                            Console.WriteLine("x={1},C={2}, nr1={0}",nr1,x,c.ToString());
                            x--;
                            if (x == -1)
                                break;
                            
                        }
                        int auxy = y;
                        y = -1;
                        foreach (char c in nrdec)
                        {
                            if (auxy == 0)
                                break;
                            if (c >= '0' && c <= '9')
                                nr2 += (c-'0')*(decimal)Math.Pow(bazaprinc, y);
                            else
                                nr2 += (c-'A'+10)*(decimal)Math.Pow(bazaprinc, y);
                            if (y == -auxy)
                                break;
                            y--;
                        }
                        if(nr2>1)//daca trebuie adaugat unitati la numarul intreg
                        {
                            nr1 += (int)nr2;
                            nr2 -= (int)nr2;//se va sterge partea intreaga chiar daca nu ar conta asta
                        }
                    }
                    #endregion


                    //Conversie DIN baza 10
                    string str = "";
                    #region Conversie DIN Baza 10
                    if (baza != 10)
                    {
                        if (nr1 == 0.0D && nr2 == 0.0M)
                        {
                            string s = "";
                            foreach (char c in nrintreg)
                                s += c;
                            nr1 = Double.Parse(s);
                            s = "0.";
                            foreach (char c in nrdec)
                                s += c;
                            nr2 = Decimal.Parse(s);
                        }
                        Stack<double> stiva = new Stack<double>();
                        while (nr1 > 0)
                        {
                            stiva.Push(nr1 % baza);
                            nr1 =(int)nr1/ baza;
                        }
                        while (stiva.Count > 0)
                            str += CautaCaracter(stiva.Pop()).ToString();
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
                                        str += CautaCaracter(result).ToString();
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
                                    str += CautaCaracter(result).ToString();
                        }
                    }
                    else
                    {
                        nr2 += (decimal)((int)nr1 % 10);
                        nr1 = Math.Floor(nr1 / 10);
                        str += nr1.ToString() + nr2.ToString();
                    }
                    #endregion
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

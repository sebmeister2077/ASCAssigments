using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversii
{
    class Program
    {
        private static bool Contains(decimal[] a,decimal x,int elem)
        {
            bool ok=false;
            for (int i = 1; i <= elem; i++)
                if (a[i] == x)
                    if (ok == true)
                        return true;
                    else
                        ok = true;
            return false;
        }

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
            char[] nrintreg=new char[70],nrdec=new char[70];
            int baza,bazaprinc;
            bool esteNegativ = false;
            Console.WriteLine("Introduceti baza principala: ");
            if (int.TryParse(Console.ReadLine(), out bazaprinc)&&bazaprinc>=2&&bazaprinc<=256)
            {
                Console.WriteLine("Va rog introduceti un numar valid: ");
                numar = Console.ReadLine();
                bool valid = true;
                foreach(char c in numar)
                    if (c >= CautaCaracter(bazaprinc))
                    { valid = false;break; }

                if (valid == true)
                {
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
                        Console.WriteLine();
                        #region Conversie IN Baza 10



                        if (bazaprinc != 10)//conversie IN baza 10
                        {

                            foreach (char c in nrintreg)
                            {
                                if (c >= '0' && c <= '9')
                                    nr1 += (int)(c - '0' + 0) * (int)Math.Pow(bazaprinc, x);
                                else
                                    nr1 += (int)(c - 'A' + 10) * (int)Math.Pow(bazaprinc, x);
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
                                    nr2 += (c - '0') * (decimal)Math.Pow(bazaprinc, y);
                                else
                                    nr2 += (c - 'A' + 10) * (decimal)Math.Pow(bazaprinc, y);
                                if (y == -auxy)
                                    break;
                                y--;
                            }
                            if (nr2 > 1)//daca trebuie adaugat unitati la numarul intreg
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
                            if (nr1 == 0)
                                str += "0";
                            while (nr1 > 0)
                            {
                                stiva.Push(nr1 % baza);
                                nr1 = (int)nr1 / baza;
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
                                int[] finalDecResults = new int[10000];//Am facut si cu List<decimal> si iteratori dar nu stiam ca la lista daca 2 elemente sunt egale da cv eroare habar nu am ce are dar pune acelasi index
                                decimal[] pastValues = new decimal[10000];
                                int it1=1, it2=1;
                                bool done = false;
                                int howManyLeftUntouched = 0, periodSpace = 0;
                                decimal primulNr=0;
                                pastValues[it2++] = nr2;
                                try
                                {
                                    while (nr2 != 0.0M)
                                    {

                                        nr2 = nr2 * baza;
                                        finalDecResults[it1++] = (int)nr2;
                                        nr2 = nr2 - (int)nr2;
                                        pastValues[it2++] = nr2;

                                        if (it2 > 1 && Contains(pastValues, nr2, it2 - 1) && primulNr == 0)
                                        {
                                            primulNr = nr2;
                                        }
                                        if (it2 > 14 && Contains(pastValues, nr2, it2 - 1))//s-a regasit acelasi deimpartit => exista o perioada(ft probabil) nu 100%
                                        {
                                            //aflam daca e adv
                                            int i1 = 1, i2 = 1, i3;
                                            for (; i1 < it2; i1++)
                                            {
                                                if (pastValues[i1] == primulNr)
                                                    break;
                                                howManyLeftUntouched++;
                                            }
                                            for (; i2 < it2; i2++)
                                                if (pastValues[i2] == primulNr && i2 != i1)
                                                    break;
                                            if (i2 == 1)
                                                continue; //continua while-ul
                                            i3 = i2;
                                            bool oksaunu = true;
                                            while (i1 != i3)
                                            {
                                                periodSpace++;
                                                if (pastValues[i1] != pastValues[i2])
                                                { oksaunu = false; break; }
                                                oksaunu = true;
                                                i1++;
                                                i2++;
                                            }
                                            if (oksaunu == true)
                                            {
                                                done = true;
                                                if (howManyLeftUntouched == 0)
                                                    str += "(";
                                                for (int i = 1; i < it1; i++)
                                                {
                                                    done = true;
                                                    if (howManyLeftUntouched > 0)
                                                    {
                                                        str += CautaCaracter(finalDecResults[i]).ToString(); howManyLeftUntouched--;
                                                        if (howManyLeftUntouched == 0)
                                                            str += "(";
                                                    }
                                                    else
                                                    {
                                                        if (periodSpace > 0)
                                                        {
                                                            str += CautaCaracter(finalDecResults[i]).ToString();
                                                            periodSpace--;
                                                            if (periodSpace == 0)
                                                            { str += ")"; break; }
                                                        }
                                                    }

                                                }
                                                if (done == true)//break while
                                                    break;
                                            }
                                            else
                                                periodSpace = 0;
                                        }
                                    }
                                }
                                catch
                                {
                                    //virgula e irationala sau are perioada foarte foarte foarte mare (<10 mii de cifre in perioada)
                                    Console.WriteLine("!!Virgula este irational!!");
                                    Console.Write("~=");
                                    it1 = 17;
                                }
                                if (done == false)//nu exista perioada
                                {
                                    for (int i=1;i<it1;i++)
                                    {
                                        str += CautaCaracter(finalDecResults[i]).ToString();
                                    }
                                }
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
                    Console.WriteLine("Numar invalid.");
            }
            else
                Console.WriteLine("Baza numarului este invalida");
        }
    }
}

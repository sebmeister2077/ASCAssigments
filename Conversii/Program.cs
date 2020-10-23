using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversii
{
    class Program
    {
        private static bool VerificareProblema(int i)
        {
            while(i>1)
            {
                if (i % 2 == 0)
                    i /= 2;
                else
                    if (i % 5 == 0)
                    i /= 5;
                else
                    return true;
            }
            return false;
        }
        public static decimal PutereNegativa(int x,int y)
        {
            decimal total = 1.0M;
            while(y<0)
            {
                total =total/ x;
                y++;
            }
            return total;
        }
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
        private static bool Contains(char[] a, char x, int elem)
        {
            bool ok = false;
            for (int i=0;i<=elem;i++)
            {
                if (a[i] == x)
                    if (ok == true)
                        return true;
                    else
                        ok = true;
            }
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
                        bool problemaIntalnita = false;
                        double nr1 = 0;
                        decimal nr2 = 0;
                        bool stg = true;
                        int x = 0, y = 0;
                        string str = "";
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

                        string inCaseOfProb = "";//in caz ca baza nu se divide doar la 2 si 5

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
                                    nr2 += (c - '0') * PutereNegativa(bazaprinc, y);//folosesc o functie proprie deoarece Math.Pow poate returna doar double(sau int)
                                else
                                    nr2 += (c - 'A' + 10) * PutereNegativa(bazaprinc, y);
                                if (y == -auxy)
                                    break;
                                y--;
                            }
                            if (nr2 >= 1)//daca trebuie adaugat unitati la numarul intreg
                            {
                                nr1 += (int)nr2;
                                nr2 -= (int)nr2;//se va sterge partea intreaga
                            }
                            //Pana aici am convertit parrtea intreaga
                            if(VerificareProblema(bazaprinc))//  1/bazaprinc o sa fie perioada
                            {
                                if(baza!=10)
                                {
                                    Console.WriteLine("Atentie!Convertirea nu este exacta deoarece baza intermediara are o perioada(sau e irationala) dupa virgula.");
                                }
                                else
                                {   //rezolv problema pentru ca pot sa afisez numarul cu perioada sa (string)
                                    problemaIntalnita = true;
                                    bool primul = true;
                                    char[] formareDec = new char[30];//va contine doar cifrele
                                    int cateAre = 0;
                                    foreach(char c in nr2.ToString())
                                    {
                                        if(primul==true)
                                        { primul = false;continue; }
                                        if (c == '.')
                                            continue;
                                        formareDec[cateAre++] = c;
                                    }
                                    int howManyLeftUntouched = 0, PeriodSpace = 0;
                                    bool ok=false;
                                    for(int i=0;i<cateAre;i++)
                                    {
                                        if(Contains(formareDec,formareDec[i],i))
                                        {
                                            int i1=0, i2=i;
                                            bool eBine = true;//presupunem ca e o perioaada corecta
                                            while (formareDec[i1] != formareDec[i])
                                            { i1++;howManyLeftUntouched++; }
                                            while(i1<i)
                                            {
                                                PeriodSpace++;
                                                i1++;
                                                i2++;
                                                if (formareDec[i1] != formareDec[i2])
                                                { eBine = false;break; }
                                            }
                                            if (eBine == true)
                                            { ok = true; break; }
                                            else
                                            {
                                                howManyLeftUntouched = 0; PeriodSpace = 0;
                                            }

                                        }
                                    }

                                    if (ok==false)//daa in primele 27 de cifre nu exista vreo perioada
                                    {
                                        for (int i = 0; i < cateAre; i++)
                                            inCaseOfProb += formareDec[i];
                                        Console.WriteLine("Prima convertire da numar irational(sau perioada mai mare de 15 de cifre).");
                                    }
                                    else
                                    {
                                        int i = 0;
                                        while(howManyLeftUntouched>0)
                                        {
                                            inCaseOfProb += formareDec[i++];
                                            howManyLeftUntouched--;
                                        }
                                        inCaseOfProb += "(";
                                        while(PeriodSpace>0)
                                        {
                                            inCaseOfProb += formareDec[i++];
                                            PeriodSpace--;
                                        }
                                        inCaseOfProb += ")";

                                    }
                                }
                            }
                        }
                        #endregion

                        //TODO sa rezolve problema perioadei 0.(70706060) si sa treaca mai departe in functie de HowManyLeftUntouched si periodSpace +de cautat un exemplu ce ar da un asa output

                        //Conversie DIN baza 10
                        
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
                            if (nr2 == 0.0M)//pana aici s-a convertiti doar partea intreaga
                            {
                                str += "0";
                            }
                            else
                            {
                                int[] finalDecResults = new int[20000];//Am facut si cu List<decimal> si iteratori dar nu stiam ca la lista daca 2 elemente sunt egale da cv eroare habar nu am ce are dar pune acelasi index
                                decimal[] pastValues = new decimal[20000];
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
                                        if (it2 > 14 && Contains(pastValues, nr2, it2 - 1))//s-a regasit acelasi deimpartit => exista o perioada(ft probabil) nu 100% perioada corecta
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
                                    Console.WriteLine("!!Virgula este irational!!(Nu s-a detectat nicio perioada in primele 20 mii de zecimale)");
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
                            if (problemaIntalnita == false)
                            {
                                nr2 += (decimal)((int)nr1 % 10);
                                nr1 = Math.Floor(nr1 / 10);
                                if (nr1 > 0)
                                    str += nr1.ToString() + nr2.ToString();
                                else
                                    str += nr2.ToString();
                            }
                            else
                            {
                                str += nr1.ToString() + "."+inCaseOfProb;
                            }
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

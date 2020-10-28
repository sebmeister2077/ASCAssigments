using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb20
{
    class Program
    {
        private static bool Contains(char[] a, char x, int elem)
        {
            bool ok = false;
            for (int i = 0; i <= elem; i++)
            {
                if (a[i] == x)
                    if (ok == true)
                        return true;
                    else
                        ok = true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            int m, n;
            m = int.Parse(Console.ReadLine());
            n = int.Parse(Console.ReadLine());

            if((m%2!=0||m%5!=0)||(n%2!=0||n%5!=0))//avem perioada
            {
                Console.Write(m/n);
                decimal nr = ((decimal)m / n);
                string straux = nr.ToString();
                string str = ".";
                bool ePrimul = true;
                int cateAre = 0;
                char[] formareDec = new char[30];
                foreach (char c in straux)
                {
                    if (ePrimul)
                    { ePrimul = false; continue; }
                    if (c == '.')
                        continue;
                    formareDec[cateAre++]=c;
                   
                }
                //s-a format srtingul cu zecimalele


                #region Cod din Conversii proj
                int howManyLeftUntouched = 0, PeriodSpace = 0;
                bool ok = false;
                for (int i = 0; i < cateAre; i++)
                {
                    if (Contains(formareDec, formareDec[i], i))
                    {
                        int i1 = 0, i2 = i;
                        bool eBine = true;//presupunem ca e o perioaada corecta
                        while (formareDec[i1] != formareDec[i])
                        { i1++; howManyLeftUntouched++; }
                        while (i1 < i)
                        {
                            PeriodSpace++;
                            i1++;
                            i2++;
                            if (formareDec[i1] != formareDec[i2])
                            { eBine = false; break; }
                        }
                        if (eBine == true)
                        { ok = true; break; }
                        else
                        {
                            howManyLeftUntouched = 0; PeriodSpace = 0;
                        }
                    }
                }
                if (ok == false)//daa in primele 27 de cifre nu exista vreo perioada
                {
                    for (int i = 0; i < cateAre; i++)
                        str += formareDec[i];
                }
                else
                {
                    int i = 0;
                    while (howManyLeftUntouched > 0)
                    {
                        str += formareDec[i++];
                        howManyLeftUntouched--;
                    }
                    str += "(";
                    while (PeriodSpace > 0)
                    {
                        str += formareDec[i++];
                        PeriodSpace--;
                    }
                    str += ")";

                }
                #endregion
                if(str.Length>1)
                Console.WriteLine(str);
            }
            else
                Console.WriteLine((double)m/n);

            Console.WriteLine();



        }
    }
}

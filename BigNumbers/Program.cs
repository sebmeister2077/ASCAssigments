using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BigNumbers
{
    class Program
    {
        public static void Swap(ref string s1, ref string s2)
        {
            string aux = s1;
            s1 = s2;
            s2 = aux;
        }
        public static void Remove(ref string str)
        {
            //removes 0 from the left side of the string
            int i = 0;
            while(str[i]=='0'&&i<str.Length-1)
            { i++; }
            if (str[i] == '.')//am scos prea multe zerouri
                str = "0" + str;
            str = str.Substring(i);
            if (CfDupaVirgula(str) > 0)
            {
                i = str.Length - 1;
                while (str[i] == '0' && i > 0)
                    i--;
                if (str[i] == '.')//daca e un nr 3.0 atunci sa scoata si virgula
                    i--;
                if (i != str.Length - 1)
                {
                    string result = "";
                    for (int j = 0; j <= i; j++)
                        result = result + str[j].ToString();
                    str = result;
                }
            }
        }
        public static void EqualDecCount(ref string str1,ref string str2)
        {
            if (CfDupaVirgula(str1) + CfDupaVirgula(str2) == 0)
                return;
            if (CfDupaVirgula(str1) == 0)
                str1 += ".";
            if (CfDupaVirgula(str2) == 0)
                str2 += ".";
            while (CfDupaVirgula(str1) != CfDupaVirgula(str2))
                if (CfDupaVirgula(str1) > CfDupaVirgula(str2)) 
                    str2 += "0";
                else
                    str1 += "0";

        }
        public static int CfDupaVirgula(string str)
        {
            bool virgula = false;
            int i = 0;
            foreach (var c in str)
            {
                if (virgula)
                    i++;
                if (c == '.')
                    virgula = true;
            }
            return i;
        }
        public static bool IsNumber(string str)
        {
            if (str == "")
                return false;
            bool virgula = false;
            foreach(var c in str)
            {
                if ((c < '0' || c > '9') && c != '.')
                    return false;
                else
                    if(c=='.')
                {
                    if (virgula)
                        return false;
                    virgula = true;
                }
            }
            return true;
        }
        #region Adunare
        static string Adunare(string str1, string str2)
        {
            if (str1 == "" || str2 == "")
                return str1 + str2;
            Remove(ref str1);
            Remove(ref str2);
            EqualDecCount(ref str1, ref str2);
            if (CfDupaVirgula(str1) < CfDupaVirgula(str2))//daca primul are mai putine zecimale
                Swap(ref str1, ref str2);
            else
                if (str2.Length > str1.Length)
                Swap(ref str1, ref str2);
            Stack<char> result=new Stack<char>();
            int i, j,remainder=0;
            i = str1.Length - 1;
            j = str2.Length - 1;


            while(i>=0||j>=0)
            {
                if(CfDupaVirgula(str1)-(str1.Length-i-1)>CfDupaVirgula(str2) - (str2.Length - j - 1))
                    result.Push(str1[i--]);
                else
                {//i si j sunt pe acelasi zecimal
                    if(i>0&&j>=0)
                    if(str1[i]=='.')
                    { result.Push('.');i--;j--; continue; }
                    int aux = remainder;
                    if(i>=0)
                    aux += int.Parse(str1[i--].ToString());
                    if(j>=0)
                    aux+=int.Parse(str2[j--].ToString());
                    remainder = 0;
                    if (aux > 9)
                    { remainder = 1; aux -= 10; }
                    result.Push((char)(aux+'0'));
                }
            }
            if (remainder > 0)
                result.Push((char)(remainder + '0'));
            //build the final string
            string strfin="";
            while (result.Count > 0)
                strfin = strfin + result.Pop().ToString();
            return strfin;
        }
        #endregion
        #region Scadere
        static string Scadere(string str1, string str2)
        {
            Remove(ref str1);
            Remove(ref str2);
            EqualDecCount(ref str1, ref str2);
            Stack<char> result=new Stack<char>();
            if (str1.Length-CfDupaVirgula(str1) < str2.Length-CfDupaVirgula(str2) || (str1.Length-CfDupaVirgula(str1) == str2.Length-CfDupaVirgula(str2) && str2.CompareTo(str1) == 1))
              Swap(ref str1, ref str2);
            int i, j,subtracter=0;
            i = str1.Length - 1;
            j = str2.Length - 1;
            while(i>=0||j>=0)
            {
                if(i>0&&j>0)
                    if(str1[i]=='.')
                    { i--;j--;result.Push('.'); continue; }
                int aux = subtracter;
                subtracter = 0;
                int zecimaleStr1 = CfDupaVirgula(str1) - (str1.Length - i - 1), zecimaleStr2 = CfDupaVirgula(str2) - (str2.Length - j - 1);
                if (zecimaleStr1 != zecimaleStr2 && CfDupaVirgula(str1) - (str1.Length - i - 1) > 0)//i si j inca nu sunt pe acelasi zecimal
                    if (zecimaleStr1 > zecimaleStr2)
                        aux += int.Parse(str1[i--].ToString());
                    else
                        aux -= int.Parse(str2[j--].ToString());
                else
                {
                    if (i >= 0)
                        aux += int.Parse(str1[i--].ToString());
                    if (j >= 0)
                        aux -= int.Parse(str2[j--].ToString());
                }
                if (aux < 0)
                { aux += 10; subtracter = -1; }
                result.Push((char)(aux + '0'));
            }
            string strfin = "";
            while (result.Count > 0)
                strfin = strfin + result.Pop().ToString();
            return strfin;
        }
        #endregion
        #region Inmultire
        static string Inmultire(string str1, string str2)
        {
            Remove(ref str1);
            Remove(ref str2);
            if (str1 == "0" || str2 == "0")
                return "0";
            EqualDecCount(ref str1, ref str2);
            string result = "0";
            int remainder = 0,trecutDeVirgula=0;
            int cfdpvirgula = CfDupaVirgula(str1);
            for(int i=str1.Length-1;i>=0;i--)
            {
                if (str1[i] == '.')
                { trecutDeVirgula = 1; continue; }
                string current = "";
                for(int j=str2.Length-1;j>=0;j--)
                {
                    if (str2[j] == '.')
                        continue;
                    remainder += int.Parse(str1[i].ToString()) * int.Parse(str2[j].ToString());
                    current =(remainder%10).ToString() + current;
                    remainder /= 10;
                }
                if (remainder > 0)
                    current = remainder.ToString() + current;
                remainder = 0;
                while (current.Length < 2*cfdpvirgula)
                    current = "0" + current;
                if (2 * cfdpvirgula - (str1.Length - i - 1) + trecutDeVirgula > 0)
                    current = current.Insert(current.Length - (2 * cfdpvirgula - (str1.Length - i - 1) + trecutDeVirgula), ".");
                for (int x = cfdpvirgula; x < str1.Length - i - 1; x++)
                    current = current + "0";
                    
                result = Adunare(result, current);
            }
            return result;

        }
        #endregion
        #region Impartire
        static string ImpartireFct1(string[] strr, int lungime, int index = 0)
        {
            string str = "";
            for (int i = index; i < index + lungime; i++)
                str += strr[i];
            return str;
        }
        static string ImpartireFct2(string str)//sterge primul element(se foloseste daca acesta este 0)
        {
            bool sari = true;
            string st = "";
            foreach (char c in str)
            {
                if (sari)
                {
                    sari = false;
                    continue;
                }
                st += c.ToString();
            }
            return st;
        }
        static string Impartire(string str1, string str2)
        {
            Remove(ref str1);
            Remove(ref str2);
            if (str1.Length < str2.Length||str1=="0")
                return "0";
            if (str1.Length == str2.Length && str2.CompareTo(str1) == 1)
                return "0";
            if (str2 == "0")
                return double.PositiveInfinity.ToString();
            string[] strr1 = new string[str1.Length];
            int i = 0, decateori;
            foreach (char c in str1)
                strr1[i++] = c.ToString();
            string strPartial, strfin = "";
            strPartial = ImpartireFct1(strr1, str2.Length);
            for (i = str2.Length; i <= strr1.Length; i++)
            {
                decateori = 0;
                while ((strPartial.CompareTo(str2) >= 0 && strPartial.Length == str2.Length) || strPartial.Length > str2.Length)
                {
                    strPartial = Scadere(strPartial, str2);
                    decateori++;
                    while (strPartial.CompareTo("1") == -1 && strPartial != "")
                        strPartial = ImpartireFct2(strPartial);
                }
                while (strPartial.CompareTo("1") == -1 && strPartial != "")
                    strPartial = ImpartireFct2(strPartial);
                if (strfin != "" || decateori != 0)
                    strfin += decateori.ToString();
                if (i < strr1.Length)
                    strPartial += strr1[i];
            }
            return strfin;
        }
        #endregion
        #region Putere
        static string Putere(string str1, string str2)
        {
            if (str1 == "0" || str1 == "1" || str2 == "1")
                return str1;
            if (str2 == "0")
                return "1";
            Remove(ref str1);
            Remove(ref str2);
            if (str2.Length<9?str1.Length>int.Parse(str2):false)
            {
                string strfin = "1";
                for (double i = 0; i < double.Parse(str2); i++)
                    strfin = Inmultire(strfin, str1);
                return strfin;
            }
            else
            {
                int intstr2=-1;
                if (str2.Length < 9)
                    intstr2 = int.Parse(str2);
                string result = "1";
                while ((str2.CompareTo("0") == 1&&intstr2==-1)||intstr2>0)
                {
                    if (intstr2 == -1)
                    {
                        if (int.Parse(str2[str2.Length - 1].ToString()) % 2 == 1)
                        { result = Inmultire(result, str1); str2 = Scadere(str2, "1"); }
                        if(str2!="0")
                        str1 = Inmultire(str1, str1);
                        str2 = Impartire(str2, "2");
                    }
                    else
                    {
                        if (intstr2 % 2 == 1)
                            result = Inmultire(result, str1);
                        if(intstr2!=1)
                        str1 = Inmultire(str1, str1);
                        intstr2 /= 2;
                    }
                }
                return result;
            }
        }
        #endregion
        #region Radical
        static int RadicalPatratFct(string rest, string str)
        {
            if (str != "")
                str = Inmultire(str, "2");
            int last = 0;
            for (int i = 1; i <= 9; i++)
            {
                last = i - 1;
                if (Inmultire(str + i.ToString(), i.ToString()).Length > rest.Length ||
                    (Inmultire(str + i.ToString(), i.ToString()).Length == rest.Length && Inmultire(str + i.ToString(), i.ToString()).CompareTo(rest) == 1))
                    break;
                if (i == 9)
                    last = 9;
            }
            return last;
        }
        static string RadicalPatrat(string str1)
        {
            //TODO implement logarithms so that we can make the power smaller
            Stack<int> str1_ = new Stack<int>();
            Stack<int> str = new Stack<int>();
            string strfin = "";
            foreach (char c in str1)
                str1_.Push(int.Parse(c.ToString()));
            int x = -1;
            while (str1_.Count > 0)
            {
                if (x == -1)
                    x = str1_.Pop();
                else
                {
                    x += 10 * str1_.Pop();
                    str.Push(x);
                    x = -1;
                }
            }
            if (x != -1)
                str.Push(x);
            double rest = 0;
            while (str.Count > 0)
            {
                double cifra;
                rest = rest * 100 + str.Pop();
                cifra = RadicalPatratFct(rest.ToString(), strfin);
                if (strfin == "")
                    rest = rest - cifra * cifra;
                else
                    rest = rest - ((double.Parse(strfin) * 2 * 10 + cifra) * cifra);
                strfin += cifra.ToString();
            }
            return strfin;
        }
        #endregion
        static void Main(string[] args)
        {
            while (true)
            {
                string nr1, nr2 = "", strOp;
                Console.Write("Numar 1: ");
                nr1 = Console.ReadLine();
                Console.Write("Operatie: ");
                strOp = Console.ReadLine();
                if (strOp != "sqrt")
                { Console.Write("Numar 2: "); nr2 = Console.ReadLine(); }
                if(!IsNumber(nr1)||!IsNumber(nr2))
                    Console.WriteLine("Invalid number");
                else
                switch (strOp)
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
                            DateTime tstart, tstop;
                            tstart = DateTime.Now;
                            Console.WriteLine(Putere(nr1, nr2));
                            tstop = DateTime.Now;
                            Console.WriteLine("Time elapsed:{0} miliseconds",tstop.Millisecond-tstart.Millisecond+1000*(tstop.Second-tstart.Second)+1000*60*(tstop.Minute-tstart.Minute));
                            break;
                    case "sqrt":
                        Console.WriteLine(RadicalPatrat(nr1));
                        break;
                }
                Console.WriteLine("\n\n");
            }
        }
    }
}
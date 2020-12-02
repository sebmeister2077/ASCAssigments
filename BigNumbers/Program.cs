using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigNumbers
{
    class Program
    {

        public static void Swap(ref string s1,ref string s2)
        {
            string aux = s1;
            s1 = s2;
            s2 = aux;
        }
        #region Adunare
        static void AdunareFct(ref Stack<string>  stfin, ref Stack<string> stackPrinc,ref Stack<string> stackAux,bool doua=false)
        {
            int aux = int.Parse(stackPrinc.Pop());
            if(doua)
                aux+= int.Parse(stackAux.Pop());
            if (aux > 9&& stackPrinc.Count>0)
            {
                int auxaux = int.Parse(stackPrinc.Pop());
                auxaux++;
                stackPrinc.Push(auxaux.ToString());
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
        #endregion
        #region Scadere
        static void ScadereFct(ref Stack<string> stfin, ref Stack<string> stackPrinc, ref Stack<string> stackAux, bool doua = false)
        {
            int aux = int.Parse(stackPrinc.Pop());
            if (doua)
                aux -= int.Parse(stackAux.Pop());
            if (aux < 0 && stackPrinc.Count > 0)
            {
                int auxaux = int.Parse(stackPrinc.Pop());
                auxaux--;
                stackPrinc.Push(auxaux.ToString());
                aux += 10;
            }
            stfin.Push(aux.ToString());
        }
        static string Scadere(string str1, string str2)
        {
            bool negativ = false;
            Stack<string> st1, st2, stfin;
            if (str1.Length < str2.Length)
            { Swap(ref str1, ref str2);negativ = true; }
            if(str1.Length==str2.Length&& str2.CompareTo(str1) == 1)//al doilea este mai mare lexicografic
            { Swap(ref str1, ref str2); negativ = true; }
            st1 = new Stack<string>();
            st2 = new Stack<string>();
            stfin = new Stack<string>();
            foreach (char c in str1)
                st1.Push(c.ToString());
            foreach (char c in str2)
                st2.Push(c.ToString());
            while (st1.Count > 0 || st2.Count > 0)
            {
                if (st1.Count == 0 || st2.Count == 0)
                    ScadereFct(ref stfin, ref st1, ref st1);
                else
                    ScadereFct(ref stfin, ref st1, ref st2, true);
            }
            StringBuilder str = new StringBuilder();
            if (negativ)
                str.Append("-");
            while (stfin.Count > 0)
                str.Append(stfin.Pop());
            return str.ToString();
        }
        #endregion
        #region Inmultire
        static string Inmultire(string str1, string str2)
        {
            int nivel = 0, trecere = 0;
            string strfin = "";
            Stack<string> st1, st2;
            st1 = new Stack<string>();
            st2 = new Stack<string>();
            foreach (char c in str1)
                st1.Push(c.ToString());
            foreach (char c in str2)
                st2.Push(c.ToString());
            while(st1.Count>0)
            {
                int aux = int.Parse(st1.Pop());
                Stack<string> st = new Stack<string>();
                Stack<string> staux = new Stack<string>();
                for (int i = 0; i < nivel; i++)
                    st.Push("0");
                while(st2.Count()>0)
                {
                    staux.Push(st2.Pop());
                    int aux2 = int.Parse(staux.Peek());
                    aux2 = aux * aux2 + trecere;
                    trecere = aux2 / 10;
                    aux2 = aux2 % 10;
                    st.Push(aux2.ToString());
                }
                while (staux.Count > 0)
                    st2.Push(staux.Pop());
                string strCurent = "";
                while (st.Count > 0)
                    strCurent = strCurent + st.Pop();
                strfin = Adunare(strfin, strCurent);
                nivel++;
            }
            if (trecere > 0)
                strfin = trecere.ToString() + strfin;
            return strfin;
        }
        #endregion
        #region Impartire
        static string ImpartireFct1(string[] strr,int lungime, int index=0)
        {
            string str="";
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
                if(sari)
                {
                    sari=false;
                    continue;
                }
                st += c.ToString(); 
            }
            return st;
        }
        static string Impartire(string str1, string str2)
        {
            if (str1.Length < str2.Length)
                return "0";
            if (str1.Length == str2.Length && str2.CompareTo(str1) == 1)
                return "0";
            if (str2 == "0")
                return double.PositiveInfinity.ToString();
            string[] strr1 = new string[str1.Length];
            int i = 0,decateori;
            foreach (char c in str1)
                strr1[i++] = c.ToString();
            string strPartial,strfin="";
            strPartial = ImpartireFct1(strr1, str2.Length);
            for( i=str2.Length;i<=strr1.Length;i++)
            {
                decateori = 0;
                while(strPartial.CompareTo(str2) >=0||strPartial.Length>str2.Length)
                {
                    strPartial = Scadere(strPartial, str2);
                    decateori++;
                    while (strPartial.CompareTo("1") == -1 && strPartial != "")
                        strPartial = ImpartireFct2(strPartial);
                }
                while (strPartial.CompareTo("1") == -1&&strPartial!="")
                    strPartial = ImpartireFct2(strPartial);
                if(strfin!=""||decateori!=0)
                strfin += decateori.ToString();
                if(i< strr1.Length)
                strPartial += strr1[i];
            }
            return strfin;
        }
        #endregion
        #region Putere
        static string Putere(string str1, string str2)
        {
            string strfin="1";
            if (str2 == "0")
                return "1";
            for (int i = 0; i < int.Parse(str2); i++)
                strfin = Inmultire(strfin, str1);
            return strfin;
        }
        #endregion
        #region Radical
        static string RadicalPatrat(string str1,string str2)
        {
            return "";
        }
        #endregion
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

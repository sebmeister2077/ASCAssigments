using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asamblor
{
    class Program
    {
        static Dictionary<string, string> dictionar;
        static void Main(string[] args)
        {
            string pathOut = "C:/MachineCode.txt";
            using (StreamWriter sw = File.CreateText(pathOut))
            { dictionar = new Dictionary<string, string>();
                InitializareDictionar(ref dictionar);
                string path = @"C:/Users/Sebas/Source/Repos/sebmeister2077/ASCAssigments/Asamblor/SampleCOde.txt";
                Console.WriteLine("Please modify(in code) or enter full file path:(type OK if its modified in code)");
                Console.WriteLine("Note: if the program starts at line 5 please write .org 4(as in the sample code)");
                string str = Console.ReadLine();
                if (str != "OK")
                    path = @str;
                string[] lines = File.ReadAllLines(path);
                int beginingLine = FindPseudoCommands(lines, ".begin"), lastLine = FindPseudoCommands(lines, ".end");//acestea vor depinde de .begin si .end
                int startingAdress = ExtractAdress(lines[FindPseudoCommands(lines, ".org")]);//extracts the adress located after the org pseudo-OP
                List<Eticheta> listaEtichete = new List<Eticheta>();
                //initializam toate etichetele (deoarece pe prima linie e pposibil sa fie ceruta valoarea/salt la adresa ultimei etichete
                for (int i = beginingLine; i < lastLine; i++)
                {
                    if (lines[i].Contains(":"))
                    {
                        string[] twohalves = new string[2];
                        twohalves = lines[i].Split(':');
                        twohalves[0].Trim(' ');
                        lines[i] = twohalves[1];//am sters eticheta deoarece o avem salvata intr o lista
                        listaEtichete.Add(new Eticheta(twohalves[0], startingAdress + 1 + i - beginingLine));
                    }
                    if (lines.Contains("!"))//stergem comentariul (pt noi)
                    {
                        string[] twohalves = new string[2];
                        twohalves = lines[i].Split('!');
                        lines[i] = twohalves[0];
                    }
                }
                for (int i = startingAdress; i < lastLine; i++)//beginning translation
                {
                    lines[i] = lines[i].Trim(' ');
                    int index = 0;
                    string comm = "";
                    while (!dictionar.ContainsKey(comm) && comm.Length < 6)//cea mai lunga instructiune are 5 litere
                        comm = comm + lines[i][index++].ToString();//tot adauga cate o litera
                    if (comm.Length == 6)//nu a gasit nicio instructiune( ori spatiu gol ori un comentariu
                        continue;
                    StringBuilder strb = new StringBuilder();
                    string value;
                    if (dictionar.TryGetValue(FindMnemonicCategory(comm), out value))//cauta codul binar al categoriei comenzii
                    #region Translation Into Machine language
                    {
                        strb.Append(value);
                        switch (FindMnemonicCategory(comm))//cele 5 formate de instructiuni
                        {
                            case "sethi":
                                
                                break;
                            case "branch":
                                strb.Append("0");
                                dictionar.TryGetValue(comm, out value);
                                strb.Append(value);
                                dictionar.TryGetValue("branch", out value);
                                strb.Append(value);
                                break;
                            case "call":

                                break;
                            case "memory":
                                
                                break;
                            case "arithmetic":
                                
                                break;
                        }
                        #endregion
                    }
                }
            }
        }

        static int FindPseudoCommands(string[] lines, string keyword)
        {
            for (int i = 0; i < lines.Length; i++)
                if (lines[i].Contains(keyword))
                    return i;
            return -1;
        }
        static string FindMnemonicCategory(string keyword)
        {
            if (keyword == "ld" || keyword == "st")
                return "memory";
            if (keyword[0] == 'b')
                return "branch";
            if (keyword == "addcc" || keyword == "jumpl"||keyword=="andcc" || keyword == "orcc" || keyword == "orncc" || keyword == "srl")
                return "arithmetic";
            if (keyword == "call")
                return "call";
            return "sethi";

        }
        static int ExtractAdress(string line)
        {
            line = RemoveSpaces(line);
            string str="";
            for (int i = 4; i < line.Length; i++)//if all " " on the left are removed then the adress should be located at index 4
                if (line[i] < '0' || line[i] > '9')//after org should come
                    break;
                else
                    str = str + line[i].ToString();
            return int.Parse(str);
        }

        static string RemoveSpaces(string line)
        {
            StringBuilder strb=new StringBuilder();
            foreach(char c in line)
            {
                if (c != ' ')
                    strb.Append(c.ToString());
            }
            return strb.ToString();
        }
        static string ReturnBinary(int nr)
        {
            string str = "";
            while(nr>0)
            {
                str = (nr % 2).ToString() + str;
                nr /= 2;
            }
            while (str.Length != 5)//2^5 registre
                str = "0"+str;
            return str;
        }
        static void InitializareDictionar(ref Dictionary<string, string> dictionar)
        {
            dictionar.Add("sethi/branch","00");
            dictionar.Add("call", "01");
            dictionar.Add("arithmetic", "10");
            dictionar.Add("memory", "11");
            dictionar.Add("branch", "010");
            dictionar.Add("sethi", "100");
            dictionar.Add("addcc", "010000");
            dictionar.Add("andcc", "010001");
            dictionar.Add("orcc", "010010");
            dictionar.Add("orncc", "010110");
            dictionar.Add("srl", "100110");
            dictionar.Add("jumpl", "111000");
            dictionar.Add("ld", "000000");
            dictionar.Add("st", "000100");
            dictionar.Add("be", "0001");
            dictionar.Add("bcs", "0101");
            dictionar.Add("bneg", "0110");
            dictionar.Add("bvs", "0111");
            dictionar.Add("ba", "1000");
            
        }
    }
    class Eticheta
    {
        public string Name;
        public int adress;
        public Eticheta(string nm,int ad)
        {
            Name = nm;
            adress = ad;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb18
{
    class Program
    {
        struct nrPrim
        {
            public int value, putere;
        }
        static void Main(string[] args)
        {
            int n;
            n = int.Parse(Console.ReadLine());
            List<nrPrim> lista = new List<nrPrim>();
            if (n == 1)
                Console.WriteLine(1);
            else
            {
                while (n > 1)
                {
                    for(int i=2;i<=n;i++)
                        if(n%i==0)
                        {

                            nrPrim nr = new nrPrim();
                            nr.value = i;
                            if (lista.Exists(x=>x.value==i))
                            {
                                nrPrim aux = new nrPrim();
                                aux = lista.Find(x => x.value == i);
                                aux.putere++;
                                int index= lista.FindIndex(x => x.value == i);
                                lista.RemoveAt(index);
                                lista.Insert(index,aux);
                                
                            }
                            else
                            {
                                nr.putere=1;
                                lista.Add(nr); 
                            }
                            n /= i;
                            break;
                        }
                }
                foreach(nrPrim item in lista)
                {
                    Console.Write($"{item.value}^{item.putere}x");
                }
                Console.WriteLine();

             }
        }
    }
}

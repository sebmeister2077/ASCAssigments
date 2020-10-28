using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n,a,i;
            n = int.Parse(Console.ReadLine());
            int[] vec; 
            vec= new int[n];
            for (i = 0; i < n; i++)
                vec[i] = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti a=");
            a = int.Parse(Console.ReadLine());
            for(i=0;i<n;i++)
                if(vec[i]==a)
                { Console.WriteLine(i); break; }
            if(i==n)
                Console.WriteLine("-1");
        }
    }
}

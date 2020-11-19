using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatDeVanzari_DefaultCoinsOnly_
{
    class Program
    {
        static void Main(string[] args)
        {
            float money = 0;
            void PurchaseAndGetSomeChange(bool b1,bool b2,bool b3)
            {
                Console.WriteLine("Item purchased.\n");
                money -= 0.2f;
                Console.Write("Coins returned:");
                if (b2==false&&b3==false)
                    Console.WriteLine("None.");
                if (b2 == true)
                { Console.Write("Dime"); money -= 0.1f; }
                if (b3 == true)
                { Console.WriteLine(" Nickel"); money -= 0.05f; }
                Sleep(400);
            }
            void Sleep(int value=0)
            {
                System.Threading.Thread.Sleep(1000+value);
            }
            
            while(true)
            {
                Console.WriteLine("N-Nickel,D-Dime,Q-Quarter\n\n");
                Console.WriteLine($"money:{money}\n");
                string c = Console.ReadLine();
                c=c.ToUpper();
                bool continue_ = false;
                switch(c)
                {
                    case "N":
                        money += 0.05f;
                        break;
                    case "D":
                        money += 0.1f;
                        break;
                    case "Q":
                        money += 0.25f;
                        break;
                    default:
                        Console.WriteLine("Introduceti o moneda valida");
                        Sleep();
                        continue_ = true;
                        break;
                }
                if (continue_)
                    continue;
                if (money >= 0.2f)
                    PurchaseAndGetSomeChange(true, money - 0.2f >= 0.1f, money - 0.2f - 0.1f >= 0.05f?true:money-0.2f>=0.5f);
                Sleep();
                Console.Clear();
            }

        }
    }
}

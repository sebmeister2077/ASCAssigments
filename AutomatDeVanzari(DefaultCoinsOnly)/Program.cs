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
            decimal money = 0;
            void PurchaseAndGetSomeChangeTermsAndConditionsMayApply(bool b1,bool b2,bool b3)
            {
                if (b1 == true)
                {
                    Console.WriteLine("Item purchased.\n");
                    money -= 0.2m;
                    Console.Write("Coins returned:");
                    if (b2 == false && b3 == false)
                        Console.WriteLine("None.");
                    if (b2 == true)
                    { Console.Write("Dime"); money -= 0.1m; }
                    if (b3 == true)
                    { Console.WriteLine(" Nickel"); money -= 0.05m; }
                    Sleep(400);
                }
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
                        money += 0.05m;
                        break;
                    case "D":
                        money += 0.1m;
                        break;
                    case "Q":
                        money += 0.25m;
                        break;
                    default:
                        Console.WriteLine("Introduceti o moneda valida");
                        Sleep();
                        continue_ = true;
                        break;
                }
                if (continue_)
                    continue;
                PurchaseAndGetSomeChangeTermsAndConditionsMayApply(money >= 0.2m, money - 0.2m >= 0.1m, money - 0.2m - 0.1m >= 0.05m?true:money-0.2m>=0.05m);
                Sleep();
                Console.Clear();
            }

        }
    }
}

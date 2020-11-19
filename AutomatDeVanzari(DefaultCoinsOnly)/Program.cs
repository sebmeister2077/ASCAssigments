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
            void Sleep(int value=0)
            {
                System.Threading.Thread.Sleep(1800+value);
            }
            float money = 0;
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
                {
                    Console.WriteLine("Item purchased.\n");
                    money -= 0.2f;
                    Console.Write("Coins returned:");
                    if (money == 0)
                        Console.WriteLine("None.");
                    if (money >= 0.1f)
                    {
                        Console.Write("D ");
                        money -= 0.1f;
                    }
                    if (money >= 0.05f)
                    {
                        Console.Write("N ");
                        money -= 0.05f;
                    }
                    Sleep(400);
                }
                Console.Clear();
            }

        }
    }
}

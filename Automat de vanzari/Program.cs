using System;
using ListManipulation;


namespace Automat_de_vanzari
{
    class Program
    {
        public static float DouaZecimale(float nr)
        {
            nr *= 100;
            nr = (int)nr;
            return nr / 100;
        }
        static void Main(string[] args)
        {
            
            bool products = true, money = false, shortcuts = true;
            float moneyInserted = 0;
            //added default products
            Operations.AddProduct("CandyBar", 0.50f);
            Operations.AddProduct("Snack", 1.66f);
            Operations.AddProduct("PackedSandwich", 3.89f);
            Operations.AddProduct("SodaCan", 2f);
            Operations.AddProduct("Popsicle", 0.49f);
            
            //added default coins
            Operations.AddCoinOrBill(10,false);
            Operations.AddCoinOrBill(5,false);
            Operations.AddCoinOrBill(1,false);
            Operations.AddCoinOrBill(0.5f,false);
            Operations.AddCoinOrBill(0.1f,false);
            Operations.AddCoinOrBill(0.05f,false);
            Operations.AddCoinOrBill(0.01f,false);
            Console.WriteLine("asdsd");

            while (true)
            {
                bool sleepsomemore = false;
                Console.Clear();
                if (shortcuts == false)
                    Console.WriteLine("Press H to see all shortcuts.");
                else
                {
                    Console.WriteLine("Press H to hide all shortcuts.");
                    Console.WriteLine("shortcuts: A-add product, M-modify product, D-delete product, SHP-show or hide products, SHM-show or hide money vault ");
                    Console.WriteLine("ACOB-add new coin or bill, DCOB-delete coin or bill, E-exit program\n\nI-input money, (int)-buy a specific product, R-retract money left\n");
                }
                Console.WriteLine();
                if (money == true)
                    Operations.ShowCoinsAndBills();
                Console.WriteLine();
                Console.WriteLine($"Money inserted:{moneyInserted}");
                Console.WriteLine();
                if(products==true)
                    Operations.ShowProducts();
                string s = Console.ReadLine();
                s=s.ToUpper();
                switch(s)
                {
                    case "H": shortcuts = !shortcuts;break;
                    case "SHM": money = !money; break;
                    case "SHP": products = !products; break;
                    case "I": 
                        float nr;
                        if (!float.TryParse(Console.ReadLine(), out nr)||nr<=0)
                        { Console.WriteLine("Invalid number."); sleepsomemore = true; }
                        else
                            if (Operations.DoesThisCoinOrBillExist(nr))
                            {
                            moneyInserted += DouaZecimale(nr);
                            Operations.MoneyInserted(DouaZecimale(nr));
                            }
                        else
                        { string str;if (nr < 1) str = "coin"; else str = "bill"; Console.WriteLine($"This {str} does not exist in Vault database."); sleepsomemore = true; }
                            break;
                    case "A": 
                        string pname;
                        float price;
                        Console.WriteLine("newProduct name:");
                        pname = Console.ReadLine();
                        Console.WriteLine("newProduct price:");
                        if (!float.TryParse(Console.ReadLine(), out price)||price<0)
                        { Console.WriteLine("Invalid number."); sleepsomemore = true; }
                        else
                            Operations.AddProduct(pname, price);
                        break;
                    case "M":
                        Console.WriteLine("Product name:");
                        Operations.ModifyProduct(Console.ReadLine());
                        break;
                    case "D":
                        Console.WriteLine("Product name:");
                        Operations.DeleteProduct(Console.ReadLine());
                        break;
                    case "ACOB":
                        float cob;
                        Console.WriteLine("Add new Coin/Bill (float/int):");
                        if (!float.TryParse(Console.ReadLine(), out cob)||cob<=0)
                        { Console.WriteLine("Invalid number"); sleepsomemore = true; }
                        else
                            Operations.AddCoinOrBill(cob);
                        break;
                    case "DCOB":
                        float Cob;
                        Console.WriteLine("Delete coin/bill");
                        if (!float.TryParse(Console.ReadLine(), out Cob)||Cob<=0)
                        { Console.WriteLine("Invalid number"); sleepsomemore = true; }
                        else
                            Operations.DeleteCoinOrBill(Cob);
                        break;
                    case "R":
                        sleepsomemore = true;
                        Operations.RetractMoney(moneyInserted);
                        moneyInserted = 0;
                        break;
                    case "E":
                        Environment.Exit(0);
                        break;
                }
                int code;
                if(int.TryParse(s,out code))// este un cod
                {
                    Operations.BuyProductByCode(code,ref moneyInserted);
                    sleepsomemore = true;
                }
                if(sleepsomemore)
                    System.Threading.Thread.Sleep(1400);
                System.Threading.Thread.Sleep(300);
            }
        }
    }
}

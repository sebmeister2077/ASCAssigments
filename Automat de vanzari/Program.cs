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
            
            Operations objControlledByUser = new Operations();
            bool products = true, money = false, shortcuts = true;
            float moneyInserted = 0;
            while (true)
            {
                bool sleepsomemore = false;
                Console.Clear();
                if (shortcuts == false)
                    Console.WriteLine("Press H to see all shortcuts.");
                else
                {
                    Console.WriteLine("Press H to hide all shortcuts.");
                    Console.WriteLine("shortcuts: A-add product, M-modify product, D-delete product, SHP-show or hide products, SHM-show or hide money ");
                    Console.WriteLine("ACOB-add new coin or bill, DCOB-delete coin or bill, E-exit program\n\nI-input money, (int)-buy a specific product, R-retract money left\n");
                }
                Console.WriteLine();
                if (money == true)
                    objControlledByUser.ShowCoinsAndBills();
                Console.WriteLine();
                Console.WriteLine($"Money inserted:{moneyInserted}");
                Console.WriteLine();
                if(products==true)
                    objControlledByUser.ShowProducts();
                string s = Console.ReadLine();
                s=s.ToUpper();
                switch(s)
                {
                    case "H": shortcuts = !shortcuts;break;
                    case "SHM": money = !money; break;
                    case "SHP": products = !products; break;
                    case "I": 
                        float nr;
                        if (!float.TryParse(Console.ReadLine(), out nr))
                        { Console.WriteLine("Invalid number."); sleepsomemore = true; }
                        else
                            if (objControlledByUser.DoesThisCoinOrBillExist(nr))
                            moneyInserted += DouaZecimale(nr);
                        else
                        { Console.WriteLine("This bill or coin does not exist."); sleepsomemore = true; }
                            break;
                    case "A": 
                        string pname;
                        float price;
                        Console.WriteLine("newProduct name:");
                        pname = Console.ReadLine();
                        Console.WriteLine("newProduct price:");
                        if (!float.TryParse(Console.ReadLine(), out price))
                        { Console.WriteLine("Invalid number."); sleepsomemore = true; }
                        else
                            objControlledByUser.AddProduct(pname, price);
                        break;
                    case "M":
                        Console.WriteLine("Product name:");
                        objControlledByUser.ModifyProduct(Console.ReadLine());
                        break;
                    case "D":
                        Console.WriteLine("Product name:");
                        objControlledByUser.DeleteProduct(Console.ReadLine());
                        break;
                    case "ACOB":
                        float cob;
                        Console.WriteLine("Add new Coin/Bill (float/int):");
                        if (!float.TryParse(Console.ReadLine(), out cob))
                        { Console.WriteLine("Invalid number"); sleepsomemore = true; }
                        else
                            objControlledByUser.AddCoinOrBill(cob);
                        break;
                    case "DCOB":
                        float Cob;
                        Console.WriteLine("Delete coin/bill");
                        if (!float.TryParse(Console.ReadLine(), out Cob))
                        { Console.WriteLine("Invalid number"); sleepsomemore = true; }
                        else
                            objControlledByUser.DeleteCoinOrBill(Cob);
                        break;
                    case "R":
                        sleepsomemore = true;
                        objControlledByUser.RetractMoney(moneyInserted);
                        break;
                    case "E":
                        Environment.Exit(0);
                        break;
                }
                int code;
                if(int.TryParse(s,out code))// este un cod
                {
                    objControlledByUser.BuyProductByCode(code,ref moneyInserted);
                    sleepsomemore = true;
                }
                if(sleepsomemore)
                    System.Threading.Thread.Sleep(1000);
                System.Threading.Thread.Sleep(800);
            }
        }
    }
}

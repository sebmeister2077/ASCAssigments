using System;
using System.Collections.Generic;

namespace ListManipulation
{
    public class Operations
    {
        private Dictionary<string, float> lista; 
        private static List<float> coinsAndBills;

        private void Sleep()
        {
            //sleep some more after error message so that user has time to read
            System.Threading.Thread.Sleep(1400);
        }
        private int CateCifreInt(float nr)
        {
            if (nr <10)
                return 1;
            int x = 1;//pt ca e deja >=10
            while(nr>9)
            {
                x++;
                nr /= 10;
            }
            return x;
        }
        private int CateCifreZec(float nr)
        {
            int x = 0;
            bool trecutdevirgula = false;
            string str = nr.ToString();
            foreach(char c in str)
                if (trecutdevirgula == true)
                x++;
            else
                if (c == '.')
                trecutdevirgula = true;
            return x+1;//si virgula ocupa loc pe ecran
        }
        public Operations()
        {
            lista = new Dictionary<string, float>();
            coinsAndBills = new List<float>();
            //added default products
            lista.Add("CandyBar", 0.50f);
            lista.Add("Snack", 1.6f);
            lista.Add("PackedSandwich", 14.99f);
            lista.Add("SodaCan", 20f);
            lista.Add("Popsicle", 1.05f);
            //added default coins
            coinsAndBills.Add(10f);
            coinsAndBills.Add(5f);
            coinsAndBills.Add(1f);
            coinsAndBills.Add(0.5f);
            coinsAndBills.Add(0.1f);
            coinsAndBills.Add(0.05f);
            coinsAndBills.Add(0.01f);
        }
        public void ShowProducts()
        {
            if(lista.Count>0)
            Console.WriteLine("Current products available:");
            else
            { Console.WriteLine("No purchaseable products"); Sleep(); }
            int i = 1;
            foreach (var product in lista)
            {
                Console.Write($"{product.Value}");
                for (int j=1;j<8-(CateCifreInt(product.Value)+CateCifreZec(product.Value));j++)
                    Console.Write(" ");
                if((int)product.Value==product.Value)
                    Console.Write(" ");
                /*if (product.Value < 1) //in caz ca vreti sa scrieti in romana cu lei si bani
                    Console.Write("Coins");
                else
                    Console.Write("Bills");
                    */
                Console.Write($"$        {product.Key} ");
                for (int j = 1; j < 25 - product.Key.Length; j++)
                    Console.Write(" ");
                Console.WriteLine($"  Code:{i++}");
            }
            Console.WriteLine();
        }
        public void ShowCoinsAndBills()
        {
            Console.WriteLine("Acceptable money input:");
            foreach (var cob in coinsAndBills)
            {
                Console.Write(cob);
                for (int j = 1; j < 8 - (CateCifreInt(cob) + CateCifreZec(cob)); j++)
                    Console.Write(" ");
                if ((int)cob == cob)
                    Console.Write(" ");
                if (cob < 1)
                    Console.WriteLine("Coin");
                else
                    Console.WriteLine("Bill");
            }
            Console.WriteLine();
        }
        public void AddProduct(string productName,float price)
        {
            if (lista.ContainsKey(productName))
            { Console.WriteLine("This PRODUCT ALREADY EXISTS!It must be deleted or modified by pressing D or M."); Sleep(); }
            else
            {
                lista.Add(productName, price);
            }
        }
        public void ModifyProduct(string productName)
        {
            if(!lista.ContainsKey(productName))
            { Console.WriteLine("THIS PRODUCT DOESN'T EXIST!It must be added first by pressing A."); Sleep(); }
            else
            {
                float newprice;
                Console.WriteLine("Set new price:");
                if(!float.TryParse(Console.ReadLine(),out newprice))
                { Console.WriteLine("Invalid number inputed."); Sleep(); }
                else
                {
                    newprice = newprice * 100;
                    newprice = (int)newprice;//se sterg toate zecimalele in plus
                    newprice = newprice / 100;
                    lista.Remove(productName);
                    lista.Add(productName, newprice);
                }
            }
        }
        public void DeleteProduct(string productName)
        {
            if (!lista.ContainsKey(productName))
            { Console.WriteLine("THIS PRODUCT DOES NOT EXIST!");Sleep(); }
            else
                lista.Remove(productName);
        }
        public void AddCoinOrBill(float bill)
        {
            if (coinsAndBills.Contains(bill))
            { Console.WriteLine("This coin/bill already exists."); Sleep(); }
            else
                if (bill >= 1 && bill != (int)bill)//nu exista bancnota de 4.99 lei sau 4.55 lei in afara daca clientul asa vrea el sa fie posibil
            { Console.WriteLine("Input a single monetary unit type:bill(an integer>=1) / coin(float<1)"); Sleep(); }
            else
            {
                coinsAndBills.Add(bill);
                coinsAndBills.Sort();
                coinsAndBills.Reverse();//cea mai mare bancnota/moneda sa fie prima
            }
        }
        public void DeleteCoinOrBill(float nr)
        {
            nr = nr * 100;
            nr = (int)nr;
            nr = nr / 100;
            if(coinsAndBills.Contains(nr))
            coinsAndBills.Remove(nr);
            else
            { Console.WriteLine("Can't be removed as it is non-existent."); Sleep(); }
        }
        public void RetractMoney(float money)
        {
            Console.WriteLine();
            Console.WriteLine("Your Change:");
            foreach(var item in coinsAndBills)
            {
                int x = 0;
                while(money>=item)
                {
                    money -= item;
                    x++;
                }
                if (x == 0)
                    continue;
                Console.Write(x);
                while(x<=100)
                {
                    Console.Write(" ");
                    x *= 10;
                }
                Console.WriteLine($"x  {item}");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public bool DoesThisCoinOrBillExist(float nr)
        {
            return coinsAndBills.Contains(nr);
        }
        public void BuyProductByCode(int code,ref float money)
        {
            if(code>lista.Count||code<=0)
            { Console.WriteLine("Invalid Product Code.");Sleep(); }
            else
            {
                foreach(var item in lista)
                {
                    if(code==1)
                    {
                        if (money < item.Value)
                        { Console.WriteLine("You need to insert more  money"); Sleep(); }
                        else
                        {
                            Console.WriteLine($"You bought a {item.Key}");
                            money -= item.Value;
                            break;
                        }
                    }
                    code--;
                }
            }
        }
    }
}

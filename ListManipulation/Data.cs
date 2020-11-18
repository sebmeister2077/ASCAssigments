using System;
using System.Collections.Generic;

namespace ListManipulation
{
    
    public static class Operations
    {
        private class Product
        {
            internal string productName;
            internal float productPrice;
            public Product(string pname, float pprice)
            {
                productName = pname;
                productPrice = pprice;
            }
        }
        private class Vault
        {
            internal float coinorbill;
            internal uint amount;
            public Vault(float cob, uint _amount)
            {
                coinorbill = cob;
                amount = _amount;
            }
        }
        private static List<Product> lista=new List<Product>();
        private static  List<Vault> coinsAndBills=new List<Vault>();

        private static void Sleep()
        {
            //sleep some more after error message so that user has time to read
            System.Threading.Thread.Sleep(1400);
        }
        private static int CateCifreInt(float nr)
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
        private static int CateCifreZec(float nr)
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
        
        public static void ShowProducts()
        {
            if(lista.Count>0)
            Console.WriteLine("Current products available:");
            else
            { Console.WriteLine("No purchaseable products"); Sleep(); }
            int i = 1;
            foreach (var product in lista)
            {
                if (product.productPrice == 0)
                Console.Write("Free");
                else
                Console.Write($"{product.productPrice}");
                if (product.productPrice == 0)
                    Console.Write("  ");
                else
                for (int j=1;j<8-(CateCifreInt(product.productPrice)+CateCifreZec(product.productPrice));j++)
                    Console.Write(" ");
                if((int)product.productPrice==product.productPrice)
                    Console.Write(" ");
                /*if (product.Value < 1) //in caz ca vreti sa scrieti in romana cu lei si bani
                    Console.Write("Coins");
                else
                    Console.Write("Bills");
                    */
                Console.Write($"$        {product.productName} ");
                for (int j = 1; j < 25 - product.productName.Length; j++)
                    Console.Write(" ");
                Console.WriteLine($"  Code:{i++}");
            }
            Console.WriteLine();
        }
        public static void MoneyInserted(float value)
        {
            coinsAndBills.Find(x => x.coinorbill == value).amount++;
        }
        public static void ShowCoinsAndBills()
        {
            Console.WriteLine("Acceptable money input:");
            foreach (var cob in coinsAndBills)
            {
                Console.Write(cob.coinorbill);
                for (int j = 1; j < 8 - (CateCifreInt(cob.coinorbill) + CateCifreZec(cob.coinorbill)); j++)
                    Console.Write(" ");
                if ((int)cob.coinorbill == cob.coinorbill)
                    Console.Write(" ");
                if (cob.coinorbill < 1)
                    Console.Write("Coin");
                else
                    Console.Write("Bill");
                Console.WriteLine($"  \tAmount In Vault: {cob.amount}");
            }
            Console.WriteLine();
        }
        public static void AddProduct(string productName,float price)
        {
            if (lista.Exists(x=>x.productName==productName))
            { Console.WriteLine("This PRODUCT ALREADY EXISTS!It must be deleted or modified by pressing D or M."); Sleep(); }
            else
            {
                lista.Add(new Product(productName, price));
            }
        }
        public static void ModifyProduct(string productName)
        {
            if(!lista.Exists(x=>x.productName==productName))
            { Console.WriteLine("THIS PRODUCT DOESN'T EXIST!It must be added first by pressing A."); Sleep(); }
            else
            {
                float newprice;
                Console.WriteLine("Set new price:");
                if(!float.TryParse(Console.ReadLine(),out newprice)||newprice<=0)
                { Console.WriteLine("Invalid number inputed."); Sleep(); }
                else
                {
                    newprice = newprice * 100;
                    newprice = (int)newprice;//se sterg toate zecimalele in plus
                    newprice = newprice / 100;
                    lista.Remove(lista.Find(x=>x.productName==productName));
                    lista.Add(new Product(productName, newprice));
                }
            }
        }
        public static void DeleteProduct(string productName)
        {
            if (!lista.Exists(x=>x.productName==productName))
            { Console.WriteLine("THIS PRODUCT DOES NOT EXIST!");Sleep(); }
            else
                lista.Remove(lista.Find(x=>x.productName==productName));
        }
        public static void AddCoinOrBill(float bill,bool userinputted=true)
        {
            if (coinsAndBills.Exists(x=>x.coinorbill==bill))
            { Console.WriteLine("This coin/bill already exists."); Sleep(); }
            else
                if (bill >= 1 && bill != (int)bill)//nu exista bancnota de 4.99 lei sau 4.55 lei in afara daca clientul asa vrea el sa fie posibil
            { Console.WriteLine("Input a single monetary unit type:bill(an integer>=1) / coin(float<1)"); Sleep(); }
            else
            {
                
                uint amount=1;
                if(userinputted)
                Console.WriteLine("Input amount:");
                if (userinputted==true&&!uint.TryParse(Console.ReadLine(), out amount))
                { Console.WriteLine("Invalid amount."); Sleep(); }
                else
                {
                    coinsAndBills.Add(new Vault(bill, amount));
                    coinsAndBills.Sort(delegate(Vault x,Vault y)
                    {
                        return x.coinorbill.CompareTo(y.coinorbill);

                    });
                    coinsAndBills.Reverse();//cea mai mare bancnota/moneda sa fie prima
                }
            }
        }
        public static void DeleteCoinOrBill(float nr)
        {
            nr = nr * 100;
            nr = (int)nr;
            nr = nr / 100;
            if(coinsAndBills.Exists(x=>x.coinorbill==nr))
            coinsAndBills.Remove(coinsAndBills.Find(x=>x.coinorbill==nr));
            else
            { Console.WriteLine("Can't be removed as it is non-existent."); Sleep(); }
        }
        public static void RetractMoney(float money)
        {
            Console.WriteLine();
            Console.WriteLine("Your Change:");
            foreach(var item in coinsAndBills)
            {
                int x = 0;
                while(money>=item.coinorbill&&item.amount>0)
                {
                    money -= item.coinorbill;
                    item.amount--;
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
                Console.WriteLine($"x  {item.coinorbill}");
            }
            if(money>0)
            Console.WriteLine("Please notify the owner that the vault needs refilling.");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public static bool DoesThisCoinOrBillExist(float nr)
        {
            return coinsAndBills.Exists(x=>x.coinorbill==nr);
        }
        public static void BuyProductByCode(int code,ref float money)
        {
            if(code>lista.Count||code<=0)
            { Console.WriteLine("Invalid Product Code.");Sleep(); }
            else
            {
                foreach(var item in lista)
                {
                    if(code==1)
                    {
                        if (money < item.productPrice)
                        { Console.WriteLine("You need to insert more  money"); Sleep(); }
                        else
                        {
                            Console.WriteLine($"You bought a {item.productName}");
                            money -= item.productPrice;
                            //nu stiu de ce dar aparent daca scazi 5-3.89 iti da 1.109999
                            money *= 100;
                            money = (float)Math.Ceiling((decimal)money);
                            money /= 100;
                            break;
                        }
                    }
                    code--;
                }
            }
        }
    }
}

using System;

namespace MyLibrary
{
    public class Mate
    {
        public static int PutereIntreg(int a,int b)
        {
            int result = 1;
            while(b>0)
            {
                result *= a;
                b--;
            }
            return result;
        }

        public static decimal PutereDecimal(int a,int b)
        {
            decimal result = 1;
            while(b<0)
            {
                result /= a;
                b++;
            }
            return result;

        }


    }
}

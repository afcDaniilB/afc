using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    public class Shop
    {
        public money shopB;
        public money cashb;
        public List<Tangerine> tangerine;
        public List<Apple> apple;
        public List<Orange> orange;
        public int tangerineCost;
        public int appleCost;
        public int orangeCost;


        public Shop(money shopb, money cash, List<Tangerine> tangerines, List<Apple> apples, List<Orange> oranges, int tangerinesCost, int applesCost, int orangesCost)
        {
            shopB = shopb;
            cashb = cash;
            tangerine = tangerines;
            apple = apples;
            orange = oranges;
            appleCost = applesCost;
            tangerineCost = tangerinesCost;
            orangeCost = orangesCost;
        }

  
        public void Buy(int choice, money cashb, money shopB, int tangerineCost, int appleCost, int orangeCost, int amount)
        {
            if (choice > 3 || choice < 1)
            {

                return;
            }

            if (choice == 1)
            {
                for(int n = 0; n < amount; n++)
                {
                    tangerine.Remove(tangerine[0]);
                }
                
                cashb.Money = cashb.Money - tangerineCost*amount;

            }

            if (choice == 2)
            {
                for (int n = 0; n < amount; n++)
                {
                    apple.Remove(apple[0]);
                }

                cashb.Money = cashb.Money - appleCost*amount;

            }

            if (choice == 3)
            {
                for (int n = 0; n < amount; n++)
                {
                    orange.Remove(orange[0]);
                }
                cashb.Money = cashb.Money - orangeCost*amount;

            }
            if (tangerine.Count <= 0 || apple.Count <= 0 || orange.Count <= 0)
            {
                Console.WriteLine("Товар закончился!");
            }
        }
    }
}

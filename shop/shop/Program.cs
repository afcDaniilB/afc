using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задайте начальное количество мандаринов (макс. 20)");
            int tangerinesCount = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Задайте цену мандаринов за 1 шт.");
            int tangerinesCost = Int32.Parse(Console.ReadLine());
            AddProductTangerine(tangerinesCost, tangerinesCount);

            Console.WriteLine("Задайте начальное количество яблок(макс. 20)");
            int applesCount = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Задайте цену яблок за 1 шт.");
            int applesCost = Int32.Parse(Console.ReadLine());
            AddProductApple(applesCost, applesCount);


            Console.WriteLine("Задайте начальное количество апельсинов(макс. 20)");
            int orangesCount = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Задайте цену апельсинов за 1 шт.");
            int orangesCost = Int32.Parse(Console.ReadLine());
            AddProductOrange(orangesCost, orangesCount);




            Console.WriteLine($"Приветствуем Вас в магазине Листок!");
            Console.WriteLine($"Количество мандаринов составляет: {tangerinesCount}");
            Console.WriteLine($"Количество яблок составляет: {applesCount}");
            Console.WriteLine($"Количество апельсинов составляет: {orangesCount}");

            Console.WriteLine("Задайте количество денег на счету магазина");
            money shopB = new money(Int32.Parse(Console.ReadLine()));

            Console.WriteLine("Задайте количество денег, имеющееся у вас");
            money cashb = new money(Int32.Parse(Console.ReadLine()));

            Shop listok = new Shop(shopB, cashb, AddProductTangerine(tangerinesCost, tangerinesCount), AddProductApple(applesCost, applesCount), AddProductOrange(orangesCost, orangesCount), tangerinesCost, applesCost, orangesCost);

            

            Console.WriteLine("Выберите товар: \n 1 - мандарины \n 2 - яблоки \n 3 - апельсины");
            int choice = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество товара");
            int amount = Int32.Parse(Console.ReadLine());

            listok.Buy(choice, cashb, shopB, tangerinesCost, applesCost, orangesCost, amount);

        }

        static List<Tangerine> AddProductTangerine(int tangerinesCost, int tangerineCount)
        {
            List<Tangerine> tangerines = new List<Tangerine>(20);
            for (int i = 0; i < tangerineCount; i++)
            {
                tangerines.Add(new Tangerine(tangerinesCost));
            }
            return tangerines;

        }
        static List<Apple> AddProductApple(int applesCost, int applesCount)
        {
            List<Apple> apples = new List<Apple>(20);
            for (int i = 0; i < applesCount; i++)
            {
                apples.Add(new Apple(applesCost));
            }
            return apples;

        }
        static List<Orange> AddProductOrange(int orangesCost, int orangesCount)
        {
            List<Orange> oranges = new List<Orange>(20);
            for (int i = 0; i < orangesCount; i++)
            {
                oranges.Add(new Orange(orangesCost));
            }
            return oranges;

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Control_4;

namespace Control_4
{
    class Program
    {
        // Делегат для события максимальных показателей
        delegate void MaxLevelReachedEventHandler(string catName);

        // Событие максимальных показателей
        static event MaxLevelReachedEventHandler MaxLevelReached;

        static void Main(string[] args)
        {
            CatManager catManager = new CatManager();

            // Загрузка данных о котах из файла (если файл существует)
            catManager.LoadCatsFromFile("cats.json");

            // Подписка на событие максимальных показателей
            MaxLevelReached += CatManager_MaxLevelReached;

            while (true)
            {
                Console.WriteLine("1. Добавить кота");
                Console.WriteLine("2. Кормить кошку");
                Console.WriteLine("3. Играй с котом");
                Console.WriteLine("4. Исцелить кошку");
                Console.WriteLine("5. Показать кошек");
                Console.WriteLine("6. Выход");
                Console.Write("Введите свой выбор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите имя кота: ");
                        string name = Console.ReadLine();
                        Console.Write("Введите возраст кошки: ");
                        int age = int.Parse(Console.ReadLine());
                        catManager.AddCat(name, age);
                        catManager.SetLevelStrategy(age);
                        break;
                    case "2":
                        Console.Write("Введите индекс кошки, которую нужно кормить: ");
                        int feedIndex = int.Parse(Console.ReadLine());
                        catManager.FeedCat(feedIndex);
                        break;
                    case "3":
                        Console.Write("Введите индекс кота, с которым будете играть: ");
                        int playIndex = int.Parse(Console.ReadLine());
                        catManager.PlayWithCat(playIndex);
                        break;
                    case "4":
                        Console.Write("Введите индекс кота для исцеления: ");
                        int healIndex = int.Parse(Console.ReadLine());
                        catManager.HealCat(healIndex);
                        break;
                    case "5":
                        catManager.DisplayCats();
                        break;
                    case "6":
                        // Сохранение данных о котах в файл перед выходом
                        catManager.SaveCatsToFile("cats.json");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте еще раз.");
                        break;
                }

                // Обработка случайных событий после каждого действия пользователя
                catManager.HandleRandomEvent();

                // Сортировка котов по среднему уровню жизни
                catManager.Cats.Sort(new CatComparer());

                // Проверка на достижение максимальных показателей
                foreach (Cat cat in catManager.Cats)
                {
                    if (cat.HungerLevel >= 100 && cat.MoodLevel >= 100 && cat.HealthLevel >= 100)
                    {
                        MaxLevelReached?.Invoke(cat.Name);
                    }
                }
            }
        }

        // Обработчик события максимальных показателей
        static void CatManager_MaxLevelReached(string catName)
        {
            Console.WriteLine($"Кот {catName} достиг максимального уровня!");
        }
    }
}




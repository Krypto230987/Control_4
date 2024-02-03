using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_4
{
    // Класс, управляющий котами
    class CatManager
    {
        private List<Cat> cats;
        private ILevelStrategy levelStrategy;
        public List<Cat> Cats
        {
            get { return cats; }
        }
        public CatManager()
        {
            cats = new List<Cat>();
            levelStrategy = new Age0To5LevelStrategy();
        }
        // Метод для добавления нового кота
        public void AddCat(string name, int age)
        {
            Cat cat = new Cat(name, age);
            cats.Add(cat);
        }
        // Метод для отображения таблицы с котами
        public void DisplayCats()
        {
            Console.WriteLine("Cats:");
            Console.WriteLine("Name\tAge\tHunger\tMood\tHealth\tLife Level");
            Console.WriteLine("---------------------------------------------");
            foreach (Cat cat in cats)
            {
                Console.WriteLine($"{cat.Name}\t{cat.Age}\t{cat.HungerLevel}\t{cat.MoodLevel}\t{cat.HealthLevel}\t{cat.CalculateLifeLevel()}");
            }
        }
        // Метод для покормления кота
        public void FeedCat(int index = -1)
        {
            if (index >= 0 && index < cats.Count)
            {
                Cat cat = cats[index];
                int increaseAmount = levelStrategy.CalculateIncreaseAmount(cat.Age);
                cat.HungerLevel += increaseAmount;
                cat.MoodLevel += increaseAmount;
            }
            else Console.WriteLine("Ошибка. Нет кота или вы ошиблись. Написали нетот индекс. Подсказка индекс начинается с 0");
        }
        // Метод для игры с котом
        public void PlayWithCat(int index =-1)
        {
            if (index >= 0 && index < cats.Count)
            {
                Cat cat = cats[index];
                int increaseAmount = levelStrategy.CalculateIncreaseAmount(cat.Age);
                cat.MoodLevel += increaseAmount;
            }
            else Console.WriteLine("Ошибка. Нет кота или вы ошиблись. Написали нетот индекс. Подсказка индекс начинается с 0 ");
        }
        // Метод для лечения кота
        public void HealCat(int index = -1)
        {
            if (index >= 0 && index < cats.Count)
            {
                Cat cat = cats[index];
                int increaseAmount = levelStrategy.CalculateIncreaseAmount(cat.Age);
                increaseAmount++;
                cat.HealthLevel += increaseAmount;
            }
            else Console.WriteLine("Ошибка. Нет кота или вы ошиблись. Написали нетот индекс. Подсказка индекс начинается с 0 ");
        }
        // Метод для изменения стратегии уровней в зависимости от возраста
        public void SetLevelStrategy(int age)
        {
            if (age >= 0 && age <= 5)
                levelStrategy = new Age0To5LevelStrategy();
            else if (age >= 6 && age <= 10)
                levelStrategy = new Age6To10LevelStrategy();
            else
                levelStrategy = new Age10PlusLevelStrategy();
        }
        // Метод для обработки случайного события
        public void HandleRandomEvent()
        {
            if (cats.Count == 0)
            {
                return;
            }
            Random random = new Random();
            // Случайное событие 1: Отравление кота
            if (random.Next(100) < 10) // 10% вероятность отравления
            {
                int index = random.Next(cats.Count);
                Cat cat = cats[index];
                cat.HungerLevel += 2; // Попытка покормить кота
                cat.MoodLevel -= 5;
                cat.HealthLevel -= 5;
                if (cat.HungerLevel <= 0 || cat.MoodLevel <= 0 || cat.HealthLevel <= 0)
                {
                    Console.WriteLine($"Cat {cat.Name} умер.");
                    cats.RemoveAt(index);
                }
            }
            // Случайное событие 2: Травма кота
            if (random.Next(100) < 5) // 5% вероятность травмы
            {
                int index = random.Next(cats.Count);
                Cat cat = cats[index];

                cat.MoodLevel -= 5;
                cat.HealthLevel -= 5;

                if (cat.MoodLevel <= 0 || cat.HealthLevel <= 0)
                {
                    Console.WriteLine($"Cat {cat.Name} получил ранения.");
                    cats.RemoveAt(index);
                }
            }
        }
        // Метод для сохранения данных о котах в JSON-файл
        public void SaveCatsToFile(string filename)
        {
            string json = JsonConvert.SerializeObject(cats);
            File.WriteAllText(filename, json);
        }
        // Метод для загрузки данных о котах из JSON-файла
        public void LoadCatsFromFile(string filename)
        {
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                cats = JsonConvert.DeserializeObject<List<Cat>>(json);
            }
        }
    }
}

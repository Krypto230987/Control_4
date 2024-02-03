using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_4
{
    class Cat
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int HungerLevel { get; set; }
        public int MoodLevel { get; set; }
        public int HealthLevel { get; set; }

        public Cat(string name, int age)
        {
            Name = name;
            Age = age;
            HungerLevel = 10;
            MoodLevel = 10;
            HealthLevel = 10;
        }

        // Метод для расчета среднего уровня жизни кота
        public double CalculateLifeLevel()
        {
            return (HungerLevel + MoodLevel + HealthLevel) / 3.0;
        }
    }
}

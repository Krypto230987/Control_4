using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_4
{
    // Конкретная реализация стратегии для возраста от 0 до 5
    class Age0To5LevelStrategy : ILevelStrategy
    {
        public int CalculateIncreaseAmount(int age)
        {
            return 10;
        }

        public int CalculateDecreaseAmount(int age)
        {
            return 2;
        }
    }
}

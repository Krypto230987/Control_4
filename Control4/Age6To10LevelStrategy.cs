using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_4
{
    // Конкретная реализация стратегии для возраста от 6 до 10
    class Age6To10LevelStrategy : ILevelStrategy
    {
        public int CalculateIncreaseAmount(int age)
        {
            return 5;
        }

        public int CalculateDecreaseAmount(int age)
        {
            return 5;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_4
{
    // Конкретная реализация стратегии для возраста от 10 и выше
    class Age10PlusLevelStrategy : ILevelStrategy
    {
        public int CalculateIncreaseAmount(int age)
        {
            return 2;
        }

        public int CalculateDecreaseAmount(int age)
        {
            return 10;
        }
    }
}

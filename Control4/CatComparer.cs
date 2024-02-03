using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_4
{
    // Класс, реализующий интерфейс IComparer для сортировки котов по среднему уровню жизни
    class CatComparer : IComparer<Cat>
    {
        public int Compare(Cat x, Cat y)
        {
            double lifeLevelX = x.CalculateLifeLevel();
            double lifeLevelY = y.CalculateLifeLevel();

            if (lifeLevelX < lifeLevelY)
                return -1;
            else if (lifeLevelX > lifeLevelY)
                return 1;
            else
                return 0;
        }
    }

    // Интерфейс для стратегии изменения уровней кота
    interface ILevelStrategy
    {
        int CalculateIncreaseAmount(int age);
        int CalculateDecreaseAmount(int age);
    }
}

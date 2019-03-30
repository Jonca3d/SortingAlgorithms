using System;

namespace SortingAlgorithms.Algorithms
{
    class Exit : ISortAlgorithm
    {
        public string Name { get; set; }

        public void Sort()
        {
            // TODO: Написать небольшую анимацию закрытия приложения

            Environment.Exit(0);
        }
    }
}

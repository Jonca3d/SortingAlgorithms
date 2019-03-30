using System;
using System.Threading;

namespace SortingAlgorithms.Algorithms
{
    /// <summary>
    /// Сортировка вставками.
    /// </summary>
    class InsertionSort : ISortAlgorithm
    {
        Random rnd = new Random();
        public string Name { get; set; }
        /// <summary>
        /// Массив чисел для сортировки
        /// </summary>
        private string[] arrayMain;

        /// <summary>
        /// Вспомогательный масси для реализации анимации обмена элементов массива
        /// </summary>
        private string[] arrayForAnimation;

        /// <summary>
        /// Величина задержки в анимации м милисекундах
        /// </summary>
        private int pauseDuration_ms;



        /// <summary>
        /// Сортировка вставками. 
        /// </summary>
        /// <param name="arrayLength"> Длинна массива чисел для сортировки. </param>
        /// <param name="pauseDuration"> Величина задержки в анимации м милисекундах. </param>
        public InsertionSort(int arrayLength, int pauseDuration)
        {
            arrayMain = new string[arrayLength];
            arrayForAnimation = new string[arrayLength];
            pauseDuration_ms = pauseDuration;

            
        }// contructor BubbleSort()

        /// <summary>
        /// При вызове этого метода будет реализован и выведен, в виде анимации, процесс сортировки
        /// </summary>
        public void Sort()
        {
            for (int i = 0; i < arrayMain.Length; i++)
            {
                arrayMain[i] = rnd.Next(1, 100).ToString();
                arrayForAnimation[i] = " ";
            }
            for (int j = 1; j < arrayMain.Length; j++)
            {
                AnimationSort(j, pauseDuration_ms);
            }
        }// Sort()

        /// <summary>
        /// Метод выводит переданные в него массивы друг под другом в заданных координатах и с подсветкой проверяемых элементов.
        /// Один массив - это основной сортируемый массив, другой - вспомогательный для реализации анимации
        /// </summary>
        /// <param name="arr1"> Массив основной </param>
        /// <param name="arr2"> Мфссив вспомогоательный </param>
        /// <param name="position">  </param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="pause"></param>
        private void WriteArray(string[] arr1, string[] arr2, int position, int x, int y, int pause)
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (i == position || i == position - 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write($"{arr1[i].ToString(),3}");
            }

            Console.SetCursorPosition(x, y + 1);
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (i == position || i == position - 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write($"{arr2[i].ToString(),3}");
            }

            Thread.Sleep(pause);
        }

        /// <summary>
        /// Если необходимо, метод реализует замену элементов массива и анимацию их замены
        /// </summary>
        /// <param name="position"> позиция проверяемого элемента </param>
        /// <param name="pauseDuration"> Величина задержки, при отрисовке изменения массивов, в милисекундах </param>
        /// <returns></returns>
        private void AnimationSort(int position, int pauseDuration)
        {
            int x = 25;
            int y = 13;

            WriteArray(arrayForAnimation, arrayMain, position, x, y, pauseDuration);

            while (position > 0)
            {
                // Если элементы массива необходимо поменять, то выполняется условие и  замена, паралельно выводится процесс замены в виде "анимации" на консоль
                if (Int32.Parse(arrayMain[position]) < Int32.Parse(arrayMain[position - 1]))
                {
                    arrayForAnimation[position] = arrayMain[position];
                    arrayMain[position] = " ";
                    WriteArray(arrayForAnimation, arrayMain, position, x, y, pauseDuration);

                    arrayForAnimation[position - 1] = arrayForAnimation[position];
                    arrayForAnimation[position] = " ";
                    WriteArray(arrayForAnimation, arrayMain, position, x, y, pauseDuration);

                    arrayMain[position] = arrayMain[position - 1];
                    arrayMain[position - 1] = " ";
                    WriteArray(arrayForAnimation, arrayMain, position, x, y, pauseDuration);

                    arrayMain[position - 1] = arrayForAnimation[position - 1];
                    arrayForAnimation[position - 1] = " ";
                    WriteArray(arrayForAnimation, arrayMain, position, x, y, pauseDuration);
                }

                position -= 1;
            }          
                      

       
        }

    }
}

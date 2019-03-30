using System;
using System.Threading;
using SortingAlgorithms.View;

namespace SortingAlgorithms.Algorithms
{
    /// <summary>
    /// Сортировка пузырьком.
    /// </summary>
    class BubbleSort : ISortAlgorithm
    {
        Random rnd = new Random();
        public string Name { get; set; }
        public int ArrayLength { get; }

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
        /// Сортировка пузырьком. 
        /// </summary>
        /// <param name="arrayLength"> Длинна массива чисел для сортировки. </param>
        /// <param name="pauseDuration"> Величина задержки в анимации м милисекундах. </param>
        public BubbleSort(int arrayLength, int pauseDuration)
        {
            arrayMain = new string[arrayLength];
            arrayForAnimation = new string[arrayLength];
            ArrayLength = arrayLength;
            pauseDuration_ms = pauseDuration;

                       
        }// contructor BubbleSort()

        /// <summary>
        /// При вызове этого метода будет реализован и выведен, в виде анимации, процесс сортировки
        /// </summary>
        public void Sort()
        {
            int lastUnsortingElement = arrayMain.Length - 1;
            int numberOfSteps = 0;

            for (int i = 0; i < ArrayLength; i++)
            {
                arrayMain[i] = rnd.Next(1, 100).ToString();
                arrayForAnimation[i] = " ";
            }

            

            while (true)
            {
                var flag = false; // Если в методе  AnimationSort не произошло не одной замены в массиве, то значение flag останется false и цикл прервется
                for (int j = 0; j < lastUnsortingElement; j++ )
                {
                    InformAboutAlgorithm.NumberOfSteps(28, 17, numberOfSteps);
                    InformAboutAlgorithm.AlgorithmName(50, 3, "BUBBLE SORT");
                    InformAboutAlgorithm.Border(23, 11, 87, 15, '*');
                    numberOfSteps += 1;
                    if(AnimationSort(j, pauseDuration_ms, lastUnsortingElement))
                    {
                        flag = true;
                        numberOfSteps += 3;
                    }
                        
                }
                if (flag == false)
                    break;
                lastUnsortingElement--;
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
        private void WriteArray(string[] arr1, string[] arr2, int position, int lastUnsortingElement ,int x, int y, int pause)
        {
            Console.SetCursorPosition(x, y);

            for (int i = 0; i < arr1.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{arr1[i].ToString(),3}");
            }

            Console.SetCursorPosition(x, y + 1);
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (i == position || i == position + 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if(i > lastUnsortingElement)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
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
        private bool AnimationSort(int position, int pauseDuration, int lastUnsortingElement)
        {
            int x = 25;
            int y = 12;
 
            WriteArray(arrayForAnimation, arrayMain, position, lastUnsortingElement,x, y, pauseDuration);
          
            // Если элементы массива необходимо поменять, то выполняется условие и  замена, паралельно выводится процесс замены в виде "анимации" на консоль
            if ( Int32.Parse(arrayMain[position+1]) < Int32.Parse(arrayMain[position]))
            {
                arrayForAnimation[position + 1] = arrayMain[position + 1];
                arrayMain[position + 1] = " ";
                WriteArray(arrayForAnimation, arrayMain, position, lastUnsortingElement, x, y, pauseDuration);

                arrayForAnimation[position] = arrayForAnimation[position + 1];
                arrayForAnimation[position + 1] = " ";
                WriteArray(arrayForAnimation, arrayMain, position, lastUnsortingElement, x, y, pauseDuration);

                arrayMain[position + 1] = arrayMain[position];
                arrayMain[position] = " ";
                WriteArray(arrayForAnimation, arrayMain, position, lastUnsortingElement, x, y, pauseDuration);

                arrayMain[position] = arrayForAnimation[position];
                arrayForAnimation[position] = " ";
                WriteArray(arrayForAnimation, arrayMain, position, lastUnsortingElement, x, y, pauseDuration);

                return true;
            }

            return false;
        }
       
    }
}

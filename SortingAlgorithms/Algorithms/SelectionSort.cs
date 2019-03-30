using System;
using System.Threading;

namespace SortingAlgorithms.Algorithms
{
    /// <summary>
    /// Сортировка Выбором.
    /// </summary>
    class SelectionSort : ISortAlgorithm
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
        private string[] arrayForAnimation2;

        /// <summary>
        /// Величина задержки в анимации м милисекундах
        /// </summary>
        private int pauseDuration_ms;



        /// <summary>
        /// Сортировка выбором. 
        /// </summary>
        /// <param name="arrayLength"> Длинна массива чисел для сортировки. </param>
        /// <param name="pauseDuration"> Величина задержки в анимации м милисекундах. </param>
        public SelectionSort(int arrayLength, int pauseDuration)
        {
            arrayMain = new string[arrayLength];
            arrayForAnimation = new string[arrayLength];
            arrayForAnimation2 = new string[arrayLength];
            this.pauseDuration_ms = pauseDuration;

            for (int i = 0; i < arrayLength; i++)
            {
                arrayMain[i] = rnd.Next(1, 100).ToString();
                arrayForAnimation[i] = " ";
                arrayForAnimation2[i] = " ";
            }
        }// contructor BubbleSort()

        /// <summary>
        /// При вызове этого метода будет реализован и выведен, в виде анимации, процесс сортировки
        /// </summary>
        public void Sort()
        {
            for (int j = 0; j < arrayMain.Length - 1; j++)
            {
                AnimationSort(j, pauseDuration_ms);
            }
        }// Sort()

        /// <summary>
        /// Метод выводит переданные в него массивы друг под другом в заданных координатах и с подсветкой проверяемых элементов.
        /// Один массив - это основной сортируемый массив, другой - вспомогательный для реализации анимации
        /// </summary>
        /// <param name="arr"> Массив основной </param>
        /// <param name="arr2"> Мфссив вспомогоательный </param>
        /// <param name="position">  </param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="pause"></param>
        private void WriteArray(string[] arr, int position, int pointer, int min, int x, int y, int pause)
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (i == position || i == pointer || i == min) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                } else if (i < min)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write($"{arr[i].ToString(),3}");
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
            int indexMinElemen = position;
            string valueMinElement;

            for (int i = position; i < arrayMain.Length; i++)
            {
                if (Int32.Parse(arrayMain[i]) < Int32.Parse(arrayMain[indexMinElemen]))
                {
                    indexMinElemen = i;
                    valueMinElement = arrayMain[i];
                }
                WriteArray(arrayMain, i, indexMinElemen, position,x, y, pauseDuration);
                Thread.Sleep(100);
            }

            if(position != indexMinElemen)
            {
                var numberOfSteps = indexMinElemen - position + 1;

                arrayForAnimation2[position] = arrayMain[position];
                arrayMain[position] = " ";
                arrayForAnimation[indexMinElemen] = arrayMain[indexMinElemen];
                arrayMain[indexMinElemen] = " ";

                var minIndexMove = indexMinElemen;
                var indexPosition = position;

                while (numberOfSteps != 1)
                {

                   
                    minIndexMove -= 1;
                    
                    indexPosition += 1;
                    numberOfSteps -= 1;

                    arrayForAnimation2[indexPosition] = arrayForAnimation2[indexPosition - 1];
                    arrayForAnimation2[indexPosition - 1] = " ";

                    arrayForAnimation[minIndexMove] = arrayForAnimation[minIndexMove + 1];
                    arrayForAnimation[minIndexMove + 1] = " ";

                    WriteArray(arrayForAnimation, indexPosition, minIndexMove,-1 ,x, y - 1, 20);
                    WriteArray(arrayMain, -1, -1, position,x, y, 0);
                    WriteArray(arrayForAnimation2, indexPosition, minIndexMove,-1 ,x, y + 1, 20);                    
                }

                arrayMain[position] = arrayForAnimation[minIndexMove];
                arrayForAnimation[minIndexMove] = " ";
                arrayMain[indexMinElemen] = arrayForAnimation2[indexPosition];
                arrayForAnimation2[indexPosition] = " ";

                WriteArray(arrayForAnimation, indexPosition, minIndexMove,-1 ,x, y - 1, pauseDuration);
                WriteArray(arrayMain, indexPosition, minIndexMove, position, x, y, pauseDuration);
                WriteArray(arrayForAnimation2, indexPosition, minIndexMove, -1, x, y + 1, pauseDuration);
            }    
        }
    }
}

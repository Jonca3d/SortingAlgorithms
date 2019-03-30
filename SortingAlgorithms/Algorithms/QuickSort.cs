using System;
using System.Threading;
using SortingAlgorithms.Service;

namespace SortingAlgorithms.Algorithms
{
    class QuickSort : ISortAlgorithm
    {
        public string Name { get; set; }
        public int[] Array { get; set; }
        public int Number { get; set; }
     

        public QuickSort(string name, int[] array)
        {
            Name = name;
            Array = array;
            Number = 0;           
        }

        public void Sort()
        {
            Sort(Array, 0, Array.Length - 1);
        }

        private void Sort(int[] input, int start, int end)
        {
            
            
            if (start < end)
            {
                int q = Partition(input, start, end);
                Sort(input, start, q - 1);
                Sort(input, q + 1, end);
            }

        }// private int[] Sort(int[] input, int start, int end)

        private int Partition(int[] input, int start, int end)
        {
            int pivot = input[end];
            int i = start;

            for(int j = start; j< end; j++)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(15, 20);
                Console.Write("PIVOT: {0}", pivot);
                Console.SetCursorPosition(15, 21);
                Console.Write("START: {0}", start);
                Console.SetCursorPosition(15, 22);
                Console.Write("J: {0}", j);
                Console.SetCursorPosition(15, 23);
                Console.Write("END: {0}", end);
                Console.SetCursorPosition(15, 24);
                Console.Write("I: {0}", i);

                Console.SetCursorPosition(15, 15);
                for (int k = 0; k < Array.Length; k++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    if (k == end)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (k == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (k == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write("{0,4}", Array[k]);
                }
                Thread.Sleep(100);
                if (input[j] <= pivot)
                {
                    int temp = input[j];
                    input[j] = input[i];
                    input[i] = temp;
                    i++;
                }
                
                Number++;
            }

            int anotherTemp = input[i];
            input[i] = input[end];
            input[end] = anotherTemp;
            return i;
        }
    }
}

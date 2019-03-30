using System;
using SortingAlgorithms.Algorithms;
using SortingAlgorithms.View;

namespace SortingAlgorithms
{
   
    class Program
    {
        
        static void Main(string[] args)
        {
            int windowWidth = 121;
            int windowHeight = 31;
            

            Console.SetBufferSize(windowWidth, windowHeight);
            Console.SetWindowSize(windowWidth, windowHeight);
            Console.CursorVisible = false;
            InsertionSort insertionSort = new InsertionSort(20, 50);
            insertionSort.Name = "INSERTION SORT";

            SelectionSort selectionSort = new SelectionSort(20, 50);
            selectionSort.Name = "SELECTION SORT";

            BubbleSort bubbleSort = new BubbleSort(20, 50);
            bubbleSort.Name = "BUBBLE SORT";

            QuickSort quickSort = new QuickSort("QUICK SORT", ArrayGenerator.Generate(20, 1, 100));

            MergeSortAl mergeSort = new MergeSortAl("MERGE SORT");

            Exit exit = new Exit();
            exit.Name = "EXIT";

            Menu menu;


            ISortAlgorithm[] arraySortAl = new ISortAlgorithm[] { bubbleSort, insertionSort, selectionSort, mergeSort, quickSort, exit };
            menu = new Menu(arraySortAl, windowWidth, windowHeight);
            menu.Show();






            Console.ReadLine();
        }
    }
}

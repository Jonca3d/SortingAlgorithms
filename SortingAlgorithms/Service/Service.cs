using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingAlgorithms.Service
{
    public static class Service
    {
        public static void ValueExchangeAnimation(ref int arg_one, ref int arg_two)
        {
            int temp = arg_one;
            arg_one = arg_two;
            arg_two = temp;
        }

        public static void WriteArray<T>(T[] arr, int x, int y, int pause, int argument_1, int argument_2, int argument_3 = -1, int argument_4 = -1)
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (i == argument_1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (i == argument_3)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if(i == argument_3)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (i == argument_4)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.Write($"{arr[i].ToString(),3}");
            }

            Thread.Sleep(pause);
        }
    }
}

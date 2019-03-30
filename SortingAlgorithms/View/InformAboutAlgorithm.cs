using System;

namespace SortingAlgorithms.View
{
    /// <summary>
    /// Клас содержащий методы для отображения информации об алгоритме на консоли
    /// </summary>
    public static class InformAboutAlgorithm
    {
        public static void NumberOfSteps(int cursorPositionX, int cursorPositionY, int numOfSteps)
        {
            Console.SetCursorPosition(cursorPositionX, cursorPositionY);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("NUMBER OF STEPS: {0}", numOfSteps);
        }

        public static void AlgorithmName(int cursorPositionX, int cursorPositionY, string name)
        {
            Console.SetCursorPosition(cursorPositionX, cursorPositionY);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{name}");
        }

        public static void Border(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY, char border)
        {
            for (int j = topLeftX; j <= bottomRightX; j++)
            {
                Console.SetCursorPosition(j, topLeftY);
                Console.Write(border);
                Console.SetCursorPosition(j, bottomRightY);
                Console.Write(border);
            }
        }
    }
}

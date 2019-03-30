using System;
using SortingAlgorithms.Algorithms;

namespace SortingAlgorithms.View
{
    public class Menu
    {
        private ISortAlgorithm[] ElementsMenu { get; }
        private int WindowSizeX { get; }
        private int WindowSiseY { get; }
        private int focusPosition = 0;

        public Menu(ISortAlgorithm[] elementsMenu, int windowSizeX, int windowSizeY)
        {
            ElementsMenu = elementsMenu;
            WindowSizeX = windowSizeX;
            WindowSiseY = windowSizeY;
        }

        public void Show()
        {       
            while(true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                CreateMenu(focusPosition);
                
                if (menuNavigation() == 1)
                {
                    Console.Clear();
                    ElementsMenu[focusPosition].Sort();
                    Console.ReadLine();
                }
                Console.Clear();

            }
        }

        void CreateMenu(int focusPosition)
        {
            int menuY = (WindowSiseY / 2) - (ElementsMenu.Length / 2);
            int menuX;
            int i = 0;
            
            foreach (var v in ElementsMenu)
            {
                menuX = (WindowSizeX / 2) - (v.Name.Length / 2);
                Console.SetCursorPosition(menuX, menuY + i);
                if(focusPosition == i)
                {
                    Console.SetCursorPosition(menuX - 4, menuY + i);
                    Console.Write("-=[ {0} ]=-", v.Name);
                }
                else
                {
                    Console.Write(v.Name);
                }
                i++;
            }
        }

        int menuNavigation()
        {
            while (true)
            {
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (focusPosition > 0)
                            focusPosition -= 1;
                        return 0;
                    case ConsoleKey.DownArrow:
                        if (focusPosition < ElementsMenu.Length - 1)
                            focusPosition += 1;
                        return 0;
                    case ConsoleKey.Enter:
                        return 1;

                    default:
                        break;
                }
            }              
        }
    }
}

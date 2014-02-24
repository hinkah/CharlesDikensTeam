using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightersCon
{
    public static class Menu
    {
        public static string[] Menu;
        public static int index = 0;

        public static void MainMenu()
        {
            Initialize();
            DrawMenu();

            while (true)
            {
                GetKeyboardState();
                DrawMenu();
            }
        }

        public static void Initialize()
        {
            Menu = new string[] { "1. Attack", "2. Escape", "3. Buy LIFE", "4. Buy ARMOUR", "5. Buy AMMUNITION", "6. Buy ATTACK", "7. Exit from this Menu."};
            
        }

        public static void GetKeyboardState()
        {
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.DownArrow)
            {
                if (index < Menu.Length - 1)
                {
                    index++;
                }
            }
            if (info.Key == ConsoleKey.UpArrow)
            {
                if (index > 0)
                {
                    index--;
                }
            }
            if (info.Key == ConsoleKey.Enter)
            {
                enterMenu(index);
            }
        }

        public static void DrawMenu()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < Menu.Length; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine(Menu[i]);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(Menu[i]);
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void enterMenu(int index) 
        {
            switch (index)
            {
                case 1:

                    break;

                case 2:

                    break;

                case 3:
                    {
                        if (SuperHero.Gold >= 100)
                        {
                            SuperHero.Gold -= 100;
                            SuperHero.Life += 100;
                        }
                        else Console.Beep();
                      }
                    break;
                case 4:
                    {
                        if (SuperHero.Gold >= 100)
                        {
                            SuperHero.Gold -= 100;
                            SuperHero.DefencePower += 100;
                        }
                        else Console.Beep();
                     }
                    break;
                case 5:
                    {
                        if (SuperHero.Gold >= 100)
                        {
                            SuperHero.Gold -= 100;
                            SuperHero.Shoot += 10;
                        }
                        else Console.Beep();
                        
                    }
                    break;
                case 6:
{
                        if (SuperHero.Gold >= 100)
                        {
                            SuperHero.Gold -= 100;
                            SuperHero.Attack += 300;
                        }
                        else Console.Beep();
                    }
                    break;
                case 7:
                    
                    break;

            }
        }
    }
}
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
        public static string[] MenuItems;
        public static int index = 0;
        public static bool stayInMenu = true;
        public static bool[] active = new bool[] { true, true, true, true, true, true, true };

        public static void MainMenu() //call menu
        {
            MenuInitialize();
            DrawMenu();
            stayInMenu = true;
            index = 0;
            for (int i = 0; i < active.Length - 1; i++)
            {
                active[i] = true;
            }

            string objType = "";
            //TODO:check colision object type to objType

            switch (objType)
            {
                case "Animal":
                    {
                        active[2] = false;
                        active[3] = false;
                        active[4] = false;
                        active[5] = false;
                    }
                    break;

                case "Warrior":
                    {
                        active[2] = false;
                        active[3] = false;
                        active[4] = false;
                        active[5] = false;
                    }
                    break;

                case "Trader":
                    {
                        active[0] = false;
                        active[1] = false;
                    }
                    break;

                case "Villager":
                    {
                        active[3] = false;
                        active[4] = false;
                        active[5] = false;
                    }
                    break;
            }





            while (stayInMenu)
            {
                GetKeyboardState();
                DrawMenu();
            }
        }

        public static void MenuInitialize()
        {
            MenuItems = new string[] { "1. Attack", "2. Escape" }; //, "3. Buy LIFE", "4. Buy ARMOUR", "5. Buy AMMUNITION", "6. Buy ATTACK", "7. Exit from this MenuItems." };

        }

        public static void GetKeyboardState()
        {
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.DownArrow)
            {
                if (index < MenuItems.Length - 1)
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
                //enterMenu(index,ref SuperHero);//????????????????????? ref to hero and 2nd colision object
            }
        }

        public static void DrawMenu()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < MenuItems.Length; i++)
            {
                if (i == index && active[i] == true)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(MenuItems[i]);
                }
                else if (i == index && active[i] == false)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(MenuItems[i]);
                }
                else if (active[i] == true)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(MenuItems[i]);
                }
                else if (active[i] == false)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(MenuItems[i]);
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void enterMenu(int index,SuperHero superHero)//ref to 2nd colision object
        {
            switch (index)
            {
                case 1:
                    {

                        //attack
                        stayInMenu = false;
                    }

                    break;

                case 2:
                    {
                        //escape
                        stayInMenu = false;
                    }

                    break;

                case 3:
                    {
                        if (superHero.Gold >= 100 && active[index - 1] == true)
                        {
                            superHero.Gold -= 100;
                            superHero.Life += 100;
                        }
                        else Console.Beep();
                    }
                    break;
                case 4:
                    {
                        if (superHero.Gold >= 100 && active[index - 1] == true)
                        {
                            superHero.Gold -= 100;
                            superHero.DefensePower += 100;
                        }
                        else Console.Beep();
                    }
                    break;
                case 5:
                    {
                        if (superHero.Gold >= 100 && active[index - 1] == true)
                        {
                            superHero.Gold -= 100;
                            superHero.Shoot += 10;
                        }
                        else Console.Beep();

                    }
                    break;
                case 6:
                    {
                        if (superHero.Gold >= 100 && active[index - 1] == true)
                        {
                            superHero.Gold -= 100;
                            superHero.AttackPower += 300;
                        }
                        else Console.Beep();
                    }
                    break;
                case 7:
                    {
                        stayInMenu = false;
                    }
                    break;

            }
        }
    }
}
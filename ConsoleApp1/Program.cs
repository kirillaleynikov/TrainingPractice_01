using System;
using System.IO;

namespace Labirint
{
    internal class Program
    {
        static void LAB(int[,] labirint)
        {

            Console.SetCursorPosition(42, 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(@"             Упраление: W - Вверх
                                                                  S - Вниз
                                                                  D - Вправо
                                                                  A - Влево");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            
            Console.ResetColor();
        }
        static void step(int[,] labirint, int x, int y, bool prov)
        {
            if (prov)
            {
                Console.Clear();
                LAB(labirint);
                Console.SetCursorPosition(x, y);
                Console.Write("☻");
                Console.SetCursorPosition(55, 0);
            }
            else
            {
                Console.Clear();
                LAB(labirint);
                Console.SetCursorPosition(x, y);
                Console.Write("☻");
                Console.SetCursorPosition(55, 15);
                Console.Write("Вы врезались в стену!");
            }
        }
        static void finish(int[,] labirint, int x, int y)
        {
            Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.Write("☻");
            Console.SetCursorPosition(55, 15);
            Console.WriteLine("Вы прошли лабиринт!");
        }

        static void Main(string[] args)
        {
            var x = 0;
            var y = 0;
            Console.CursorVisible = false;
            Console.SetWindowSize(100, 30);
            string[] lines = File.ReadAllLines("map.txt");
            int[,] labirint = new int[lines.Length, lines[0].Length];
            for (int i = 0; i < lines.GetLength(0); i++) //создание лабиринта
            {
               for (int j = 0; j < lines[i].Length; j++)
                {
                    labirint[i, j] = int.Parse(lines[i][j].ToString());
                }
            }
            //{
            //{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            //{1,2,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,1},
            //{1,0,1,1,1,1,1,0,1,1,1,0,1,0,1,1,1,0,1,0,1},
            //{1,0,0,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,1},
            //{1,0,1,1,1,0,1,1,1,0,1,0,1,1,1,0,1,0,1,0,1},
            //{1,0,1,0,0,0,1,0,0,0,1,0,1,0,0,0,1,0,0,0,1},
            //{1,0,1,0,1,1,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1},
            //{1,0,1,0,0,0,1,0,1,0,0,0,0,0,1,0,1,0,0,0,1},
            //{1,0,1,1,1,0,1,1,1,1,1,1,1,0,1,1,1,0,1,0,1},
            //{1,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,1},
            //{1,0,1,0,1,1,1,0,1,0,1,1,1,1,1,0,1,1,1,0,1},
            //{1,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,1},
            //{1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1},
            //{1,0,1,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,1,0,1},
            //{1,0,1,1,1,1,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1},
            //{1,0,0,0,0,0,1,0,1,0,1,0,1,0,1,0,0,0,0,0,1},
            //{1,1,1,1,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1},
            //{1,0,0,0,1,0,1,0,1,0,1,0,1,0,0,0,0,0,0,0,1},
            //{1,0,1,0,1,0,1,1,1,0,1,0,1,1,1,1,1,1,1,0,1},
            //{1,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,3,1},
            //{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
            //};
            LAB(labirint);
            x = 1;
            y = 1;
            Console.SetCursorPosition(x, y);
            Console.Write("☻");
            var GameOver = false;
            while (!GameOver)
            {
                switch (Console.ReadKey().KeyChar)
                {
                    case ('w'):
                        if (labirint[--y, x] == 1)
                        {
                            ++y;
                            step(labirint, x, y, false);
                        }
                        else
                        if (labirint[--y, x] == 0)
                        {
                            step(labirint, x, y, true);
                        }
                        else
                        {
                            finish(labirint, x, y);
                        }
                        break;
                    case ('s'):
                        if (labirint[++y, x] == 1)
                        {
                            --y;
                            step(labirint, x, y, false);
                        }
                        else
                        if (labirint[++y, x] == 0)
                        {
                            step(labirint, x, y, true);
                        }
                        else
                        {
                            finish(labirint, x, y);
                        }
                        break;
                    case ('a'):
                        if (labirint[y, --x] == 1)
                        {
                            ++x;
                            step(labirint, x, y, false);
                        }
                        else
                        if (labirint[y, --x] == 0)
                        {
                            step(labirint, x, y, true);
                        }
                        else
                        {
                            finish(labirint, x, y);
                        }
                        break;
                    case ('d'):
                        if (labirint[y, ++x] == 1)
                        {
                            --x;
                            step(labirint, x, y, false);
                        }
                        else
                        if (labirint[y, ++x] == 0)
                        {
                            step(labirint, x, y, true);
                        }
                        else
                        {
                            finish(labirint, x, y);
                        }
                        break;
                    default:
                        Console.Clear();
                        LAB(labirint);
                        Console.SetCursorPosition(x, y);
                        Console.Write("☻");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}

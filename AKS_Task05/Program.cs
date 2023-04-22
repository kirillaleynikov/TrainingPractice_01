using System;
using System.IO;

namespace Labirint
{
    internal class Program
    {
        static void LAB(int[,] labirint)
        {
            var x = 0;
            var y = 0;
            Console.SetCursorPosition(42, 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(@"             Упраление: W - Вверх
                                                                  S - Вниз
                                                                  D - Вправо
                                                                  A - Влево");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i < labirint.GetLength(0); i++, ++y) //создание лабиринта
            {
                for (int j = 0; j < labirint.GetLength(1); j++, ++x)
                {
                    Console.SetCursorPosition(x, y);
                    if (labirint[i, j] == 1)
                    {
                        Console.Write("█");
                    }
                    if (labirint[i, j] == 0)
                    {
                        Console.Write(" ");
                    }
                    if (labirint[i, j] == 3)
                    {
                        Console.Write("X");
                    }
                }
                x = 0;
            }
            Console.ResetColor();
        }
        static void step(int[,] labirint, int x, int y, bool prov)
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (prov)
            {
                LAB(labirint);
                Console.SetCursorPosition(x, y);
                Console.Write("☻");
                Console.SetCursorPosition(55, 15);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Вы врезались в стену!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
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
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Console.WindowWidth / 2 - "Поздравляем!".Length / 2, Console.WindowHeight / 2);
            Console.WriteLine("Поздравляем!");
            Console.SetCursorPosition(Console.WindowWidth / 2 - "Вы прошли лабиринт!".Length / 2, Console.WindowHeight / 2 + 1);
            Console.WriteLine("Вы прошли лабиринт!");
            Console.ReadKey();
            Environment.Exit(0);
        }

        static void Main(string[] args)
        {
            var x = 0;
            var y = 0;
            Console.CursorVisible = false;
            Console.SetWindowSize(100, 30);
            string[] strings = File.ReadAllLines("map.txt");
            int[,] labirint = new int[strings.Length, strings[0].Length];
            for (int i = 0; i < strings.Length; i++)
                for (int j = 0; j < strings[0].Length; j++)
                {
                    labirint[i, j] = int.Parse(strings[i][j].ToString());
                    if (labirint[i, j] == 2)
                    {
                        x = j;
                        y = i;
                        labirint[i, j] = 0;
                    }
                }
            LAB(labirint);
            Console.SetCursorPosition(x, y);
            Console.Write("☻");
            var GameOver = false;
            while (!GameOver)
            {
                Console.SetCursorPosition(Console.WindowWidth - 5, Console.WindowHeight - 5);
                Console.ForegroundColor = ConsoleColor.Black;
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
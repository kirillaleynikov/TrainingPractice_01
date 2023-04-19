using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var counter = 0;
            for (int i = 1; i > counter; i++)
            {
                Console.Write("Введите первое слово: ");
                var firstValue = Console.ReadLine();
                if (firstValue.ToLower() == "exit")
                {
                    Console.WriteLine("Программа закрывается...");
                    break;
                }
                Console.Write("Введите второе слово для его сложения с первым: ");
                var secondValue = Console.ReadLine();
                if (secondValue.ToLower() == "exit")
                {
                    Console.WriteLine("Программа закрывается...");
                    break;
                }
                Console.WriteLine($"Полученное предложение: {firstValue + " " + secondValue}");
                Console.WriteLine();
            }
        }
    }
}
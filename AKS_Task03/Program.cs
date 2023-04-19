using System;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "qwerty";
            for (var i = 0; i < 3; i++)
            {
                Console.Write("Введите пароль: ");
                var input = Console.ReadLine();
                if (input == password)
                {
                    Console.WriteLine("Секретное сообщение: Привет!");
                    Console.ReadKey();
                    break;
                }
                Console.WriteLine("Неверный пароль! Повторите попытку");
                Console.WriteLine();
            }
        }
    }
}

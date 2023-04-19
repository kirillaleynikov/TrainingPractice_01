using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS_Task06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] posts = new string[0];
            string[] fullNames = new string[0];
            bool isExitProgram = true;
            while (isExitProgram)
            {
                Console.Clear();
                Console.WriteLine($"1 - Добавить досье\n" + 
                    $"2 - Вывод всех досье на экран с их ID в программе\n" +
                    $"3 - Поиск досье по ФИО\n" +
                    $"4 - Удалить досье по ID\n" + 
                    $"5 - Выход из программы\n");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        AddDossier(ref fullNames, ref posts);
                        break;
                    case "2":
                        Console.Clear();
                        ShowAllDossiers(posts, fullNames);
                        break;   
                    case "3":
                        Console.Clear();
                        SearchDossier(fullNames, posts);
                        break;
                    case "4":
                        Console.Clear();
                        DeleteDossier(ref fullNames, ref posts);
                        break;
                    case "5":
                        isExitProgram = false;
                        break;
                }
                Console.WriteLine(new string('-', 100));
                Console.Write("Нажмите любую клавишу для продолжения работы");
                Console.ReadKey();
            }
        }

        private static void AddDossier(ref string[] names, ref string[] posts)
        {
            Console.Write("Введите ФИО: ");
            string name = Console.ReadLine();
            Console.Write("Введите должность: ");
            string post = Console.ReadLine();
            names = IncreasArray(names, name);
            posts = IncreasArray(posts, post);
        }

        private static string[] IncreasArray(string[] array, string text)
        {
            string[] temporaryArray = new string[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                temporaryArray[i] = array[i];
            }
            temporaryArray[temporaryArray.Length - 1] = text;
            array = temporaryArray;
            return array;
        }

        private static void ShowAllDossiers(string[] posts, string[] fullNames)
        {
            int id = 1;
            for (int i = 0; i < posts.Length; i++)
            {
                Console.WriteLine($"ID [{id}] | ФИО : {fullNames[i]} | должность : {posts[i]}");
                id++;
            }
        }

        private static void DeleteDossier(ref string[] fullNames, ref string[] posts)
        {
            Console.Write("Введите номер досье: ");
            int number = int.Parse(Console.ReadLine());
            if (number > 0 && number <= fullNames.Length)
            {
                int id = number - 1;
                fullNames = DecreaseArray(fullNames, id);
                posts = DecreaseArray(posts, id);
                Console.WriteLine($"Досье с ID [{number}] удалено");
            }
            else
            {
                Console.WriteLine("Досье с таким ID не существует");
            }
        }

        private static string[] DecreaseArray(string[] array, int id)
        {
            string[] temporaryArray = new string[array.Length - 1];
            for (int i = 0; i < id; i++)
            {
                temporaryArray[i] = array[i];
            }
            for (int i = id; i < array.Length - 1; i++)
            {
                temporaryArray[i] = array[i + 1];
            }
            array = temporaryArray;
            return array;
        }

        private static void SearchDossier(string[] fullNames, string[] posts)
        {
            Console.Write("Введите фамилию для поиска досье: ");
            string surname = Console.ReadLine();
            bool isSuccessfulSearch = false;
            for (int i = 0; i < fullNames.Length; i++)
            {
                string[] split = fullNames[i].Split(' ');

                if (split[0].ToLower() == surname.ToLower())
                {
                    Console.WriteLine($"ID [{i + 1}] | ФИО : {fullNames[i]} | должность : {posts[i]}");
                    isSuccessfulSearch = true;
                }
            }
            if (isSuccessfulSearch == false)
            {
                Console.WriteLine($"Досье с фамилией '{surname}' не найдено");
            }
        }
    }
}
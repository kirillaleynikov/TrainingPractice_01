using System;

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
                        $"2 - Вывод всех досье\n" +
                        $"3 - Поиск досье по ФИО\n" +
                        $"4 - Удалить досье по ID\n" +
                        $"5 - Выход из программы\n");
                    switch (Console.ReadLine()) //выбор пунктов меню
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

        private static void AddDossier(ref string[] names, ref string[] posts) //добавление досье
        {
            Console.WriteLine("exit - Перейти в главное меню\n");
            Console.Write("Введите ФИО: ");
            string name = Console.ReadLine();
            if (name == "exit")
            {
                return;
            }
            Console.Write("Введите должность: ");
            string post = Console.ReadLine();
            names = IncreasArray(names, name); //обращение к методу добавления ФИО и должности в массив, передача массива с ФИО и нового элемента
            posts = IncreasArray(posts, post); //обращение к методу добавления ФИО и должности в массив, передача массива с должностями и новой должности
        }

        private static string[] IncreasArray(string[] array, string text) //добавление ФИО и должности в массив
        {
            string[] bufArray = new string[array.Length + 1]; //временный массив
            for (int i = 0; i < array.Length; i++)
            {
                bufArray[i] = array[i]; //добавление ногового элемента в массив
            }
            bufArray[bufArray.Length - 1] = text;
            array = bufArray;
            return array;
        }

        private static void ShowAllDossiers(string[] posts, string[] fullNames) //отображение всех досье
        {
            int id = 1;
            for (int i = 0; i < posts.Length; i++)
            {
                Console.WriteLine($"ID [{id}] | ФИО : {fullNames[i]} | должность : {posts[i]}");
                id++;
            }
        }

        private static void DeleteDossier(ref string[] fullNames, ref string[] posts) //удаление досье
        {
            int id2 = 1;
            for (int i = 0; i < posts.Length; i++) //вывод всех досье
            {
                Console.WriteLine($"ID [{id2}] | ФИО : {fullNames[i]} | должность : {posts[i]}");
                id2++;
            }
            Console.Write("Введите номер досье: ");
            int number = int.Parse(Console.ReadLine());
            if (Convert.ToString(number) == "1")
            {
                return;
            }
            if (number > 0 && number <= fullNames.Length)
            {
                int id = number - 1;
                fullNames = DecreaseArray(fullNames, id); //обращение к методу удаления ФИО и должности из массива, передача массива с ФИО и id, по которому произойдёт удаление
                posts = DecreaseArray(posts, id); //обращение к методу удаления ФИО и должности из массива, передача массива с должностью и id, по которому произойдёт удаление
                Console.WriteLine($"Досье с ID [{number}] удалено");
            }
            else
            {
                Console.WriteLine("Досье с таким ID не существует");
            }
        }

        private static string[] DecreaseArray(string[] array, int id) //удаление ФИО и должности из массива
        {
            string[] bufArray = new string[array.Length - 1]; //временный массив
            for (int i = 0; i < id; i++)
            {
                bufArray[i] = array[i];
            }
            for (int i = id; i < array.Length - 1; i++)
            {
                bufArray[i] = array[i + 1];
            }
            array = bufArray;
            return array;
        }

        private static void SearchDossier(string[] fullNames, string[] posts) //поиск досье по фамилии
        {
            Console.WriteLine("exit - Перейти в главное меню\n");
            Console.Write("Введите фамилию для поиска досье: ");
            string lastName = Console.ReadLine();
            if (lastName == "exit")
            {
                return;
            }
            bool search = false;
            for (int i = 0; i < fullNames.Length; i++)
            {
                string[] surname = fullNames[i].Split(' '); //взятие фамилии из ФИО
                if (surname[0].ToLower() == lastName.ToLower())
                {
                    Console.WriteLine($"ID [{i + 1}] | ФИО : {fullNames[i]} | должность : {posts[i]}");
                    search = true;
                }
            }
            if (search == false)
            {
                Console.WriteLine($"Досье с фамилией '{lastName}' не существует");
            }
        }
    }
}
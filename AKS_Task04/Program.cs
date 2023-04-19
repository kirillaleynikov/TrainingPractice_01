using System;
using System.Threading;

namespace AKS_Task04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var konfringo = false;
            var startGame = true;
            var stepCounter = 0;
            Random rnd = new Random();
            var choice = rnd.Next(0, 2);
            var bossHealthLevel = rnd.Next(500, 800);
            var userHealthLevel = rnd.Next(500, 800);
            Console.WriteLine($"Игра - Победи БОССА\nУсловия:\nМаксимальный уровень жизни у БОССА и игрока - 800 XP\n" +
            $"Случайным образом выбирается игрок, делающий первый ход\nВеличина урона, наносимого БОССОМ, для каждого хода случайна\n" +
            $"Игрок может пользоваться следующими заклинаниями:\n\nкруциатус - пыточное заклинание. Непростительное заклятие. Наносит урон " +
            $"размером в 80 единиц и прибавляет игроку 80 XP\n\nсектумсемпра - нанесение глубоких резаных ран. Наносит урон размером в 100 единиц и отнимает у " +
            $"игрока 30 XP\n\nорбис - синий смерч, закапывающий под землю. Наносит урон размером в 120 единиц\n\nэкспульсо - заклинание взрыва. Наносит урон размером " +
            $"в 145 единиц. Можно выполнить, если уровень здоровья у игрока не меньше 100 единиц\n\nконфринго - заклинание пожара и взрыва. Наносит урон размером в 50 единиц каждую " +
            $"секунду 5 раз. МОЖЕТ БЫТЬ ВЫПОЛНЕНО ТОЛЬКО ПОСЛЕ ВЫЗОВА ОРБИСА\n\nНачальное значение здоровья у игрока - {userHealthLevel} XP\nНачальное значение здоровья у БОССА " +
            $"- {bossHealthLevel} XP\n");
            while (startGame)
            {
                if (bossHealthLevel <= 0)
                {
                    Console.WriteLine("Босс погиб! Вы победили! Игра окончена!");
                    startGame = false;
                }
                else if (userHealthLevel <= 0)
                {
                    Console.WriteLine("Вы погибли! Игра окончена!");
                    startGame = false;
                }
                else
                {
                    ++stepCounter;
                    Console.WriteLine($"Игровой шаг - {stepCounter}");
                    Console.WriteLine("Атакует игрок");
                    Console.Write("Введите заклинание: ");
                    var userInput = Console.ReadLine();
                    Console.WriteLine();
                    switch (userInput.ToLower())
                    {
                        case "круциатус":
                            Console.WriteLine("БОСС потерял 80 единиц здоровья и вы получили их себе");
                            bossHealthLevel -= 80;
                            userHealthLevel += 80;
                            Console.WriteLine($"Ваш актуальный запас здоровья: {userHealthLevel}");
                            Console.WriteLine($"Запас здоровья БОССА: {bossHealthLevel}");
                            BossStep();
                            break;
                        case "сектумсемпра":
                            Console.WriteLine("БОСС потерял 100 единиц здоровья, а вы - 30 единиц");
                            bossHealthLevel -= 100;
                            userHealthLevel -= 30;
                            Console.WriteLine($"Ваш актуальный запас здоровья: {userHealthLevel}");
                            Console.WriteLine($"Запас здоровья БОССА: {bossHealthLevel}");
                            BossStep();
                            break;
                        case "орбис":
                            konfringo = true;
                            Console.WriteLine("БОСС потерял 120 единиц здоровья. Теперь вы можете вызвать заклинание конфринго!");
                            bossHealthLevel -= 120;
                            Console.WriteLine($"Ваш актуальный запас здоровья: {userHealthLevel}");
                            Console.WriteLine($"Запас здоровья БОССА: {bossHealthLevel}");
                            BossStep();
                            break;
                        case "экспульсо":
                            if (userHealthLevel < 100)
                            {
                                Console.WriteLine("Вы не можете выполнить это заклинание, т.к. ваш уровень здоровья меньше 100 единиц");
                            }
                            else
                            {
                                Console.WriteLine("БОСС потерял 120 единиц здоровья.");
                                bossHealthLevel -= 120;
                                Console.WriteLine($"Ваш актуальный запас здоровья: {userHealthLevel}");
                                Console.WriteLine($"Запас здоровья БОССА: {bossHealthLevel}");
                                BossStep();
                            }
                            break;
                        case "конфринго":
                            if (konfringo == false)
                            {
                                Console.WriteLine("Вы не можете выполнить это заклинание, т.к. заклинание орбис ещё не произведено");
                            }
                            else
                            {
                                int fire = 0;
                                for (int i = 1; i < 6; i++)
                                {
                                    fire += 50;
                                    Thread.Sleep(1000);
                                    bossHealthLevel -= 50;
                                    Console.Write($"Атака пожаром и взрывом наносит урон БОССУ {fire}:  \nПродолжительность атаки {i} секунд");
                                    Console.WriteLine();
                                }
                                Console.WriteLine("\nБОСС потерял после атаки 250 единиц здоровья");
                                Console.WriteLine();
                                Console.WriteLine($"Ваш актуальный запас здоровья: {userHealthLevel}");
                                Console.WriteLine($"Запас здоровья БОССА: {bossHealthLevel}");
                                BossStep();
                            }
                            break;
                        default:
                            Console.WriteLine("Такого заклинания не существует!");
                            BossStep();
                            break;
                    }
                }
                void BossStep()
                {
                    Console.WriteLine();
                    ++stepCounter;
                    Console.WriteLine($"Игровой шаг - {stepCounter}");
                    Console.WriteLine("Атакует БОСС");
                    var bossDamage = rnd.Next(100, 200);
                    Console.WriteLine($"Сила удара - {bossDamage} единиц");
                    userHealthLevel -= bossDamage;
                    Console.WriteLine($"Ваш актуальный запас здоровья: {userHealthLevel}");
                    Console.WriteLine($"Запас здоровья БОССА: {bossHealthLevel}");
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}
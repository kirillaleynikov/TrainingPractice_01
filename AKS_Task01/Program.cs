using System;

namespace AKS_Task01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var N = 35;
            Console.Write("Введите количество золота: ");
            var goldAmount = int.Parse(Console.ReadLine());
            var crystallsMaxAmount = goldAmount / N;
            Console.WriteLine($"Актуальный курс: 1 кристалл за {N} золота");
            Console.WriteLine($"Максимальное количество кристаллов, которое вы сможете купить: {crystallsMaxAmount}");
            Console.Write("Введите количество кристаллов, которое необходимо купить: ");
            var crystalls = int.Parse(Console.ReadLine());
            var check1 = goldAmount >= (N * crystalls);
            crystalls *= Convert.ToInt32(check1);
            var goldBalance = goldAmount - (crystalls * N);
            Console.WriteLine($"Ваш баланс: {crystalls} кристаллов, {goldBalance} золота");
            Console.ReadKey();
        }
    }
}
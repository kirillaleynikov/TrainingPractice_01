using System;

namespace AKS_Task07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.Write("Введите количество элементов массива: ");
            int[] mas1 = new int[Convert.ToInt32(Console.ReadLine())];
            for (int i=0; i<mas1.Length; i++)
            {
                mas1[i] = rnd.Next(-50,50);
            }
            Console.WriteLine("Введённый массив:");
            for (int i = 0; i < mas1.Length; i++)
            {
                Console.Write(mas1[i]+" ");
            }
            Console.WriteLine();
            Console.WriteLine("Перемешанный массив:");
            for (int i = mas1.Length - 1; i>=0; i--)
            {
                int rnd2 = rnd.Next(i);
                int shuffledElement = mas1[rnd2];
                mas1[rnd2] = mas1[i];
                mas1[i] = shuffledElement;
                Console.Write(mas1[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
using System;

namespace Less1Ex3
{
    internal class Program
    {
        /*
            Долгуев Владимир.
            Реализуйте функцию вычисления числа Фибоначчи.
            Требуется реализовать рекурсивную версию и версию без рекурсии (через цикл).
         */

        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите номер числа из положительного ряда Фибоначчи");
                bool isValid = int.TryParse(Console.ReadLine(), out int num);
                if (!isValid || num < 1)
                {
                    Console.WriteLine("Введено некорректное значение");
                    continue;
                }
                Console.WriteLine("Число по введенному номеру циклическим методом: " + FibonacciCyc(num));
                Console.WriteLine("Число по введенному номеру рекурсивным методом: " + FibonacciRec(num));
                break;
            }
            Console.ReadKey();
        }

        private static int FibonacciRec(int number)
        {
            if (number == 0 || number == 1)
            {
                return number;
            }

            return FibonacciRec(number - 1) + FibonacciRec(number - 2);
        }

        private static int FibonacciCyc(int number)
        {
            int a = 1;
            int b = 1;

            for (int i = 2; i < number; i++)
            {
                b = a + b;
                a = b - a;
            }
            return b;
        }
    }
}
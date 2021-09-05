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

        private static int iter;

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
                iter = 0;
                Console.WriteLine("Число по введенному номеру циклическим методом: " + FibonacciCyc(num));
                Console.WriteLine($"Потребовалось действий: {iter}\n");
                iter = 0;
                Console.WriteLine("Рекурсивный метод №1 - без усложнения функции и с возвратом первых двух чисел ряда.");
                Console.WriteLine("Число по введенному номеру рекурсивным методом №1: " + FibonacciRecV1(num));
                Console.WriteLine($"Потребовалось действий: {iter}\n");
                iter = 0;
                Console.WriteLine("Рекурсивный метод №2 - без усложнения функции и с возвратом первых четырех чисел ряда.");
                Console.WriteLine("Число по введенному номеру рекурсивным методом №2: " + FibonacciRecV2(num));
                Console.WriteLine($"Потребовалось действий: {iter}\n");
                iter = 0;
                Console.WriteLine("Рекурсивный метод №3 - усложнение функции на один уровень и возврат первых четырех чисел ряда.");
                Console.WriteLine("Число по введенному номеру рекурсивным методом №3: " + FibonacciRecV3(num));
                Console.WriteLine($"Потребовалось действий: {iter}\n");
                iter = 0;
                Console.WriteLine("Рекурсивный метод №4 - усложнение функции на два уровеня и возврат первых пяти чисел ряда.");
                Console.WriteLine("Число по введенному номеру рекурсивным методом №4: " + FibonacciRecV4(num));
                Console.WriteLine($"Потребовалось действий: {iter}\n");

                break;
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Метод цикличного вычисления функции
        /// </summary>
        private static int FibonacciCyc(int number)
        {
            iter++;
            int a = 1;
            int b = 1;

            for (int i = 2; i < number; i++)
            {
                b = a + b;
                a = b - a;
                iter++;
            }
            return b;
        }

        /// <summary>
        /// Метод рекурсивного вычисления функции
        /// без усложнения
        /// и возвратом первых двух чисел ряда
        /// </summary>
        private static int FibonacciRecV1(int number)
        {
            iter++;
            if (number == 0 || number == 1)
            {
                return number;
            }
            return FibonacciRecV1(number - 1) + FibonacciRecV1(number - 2);
        }

        /// <summary>
        /// Метод рекурсивного вычисления функции
        /// без усложнения
        /// и возвратом первых четырех чисел ряда
        /// </summary>
        private static int FibonacciRecV2(int number)
        {
            iter++;
            switch (number)
            {
                case 0: return 0;
                case 1:
                case 2: return 1;
                case 3: return 2;
                default: return FibonacciRecV2(number - 1) + FibonacciRecV2(number - 2);
            }
        }

        /// <summary>
        /// Метод рекурсивного вычисления функции
        /// с усложнением на один уровень
        /// и возвратом первых четырех чисел ряда
        /// </summary>
        private static int FibonacciRecV3(int number)
        {
            iter++;
            switch (number)
            {
                case 0: return 0;
                case 1:
                case 2: return 1;
                case 3: return 2;
                default: return 2 * FibonacciRecV3(number - 2) + FibonacciRecV3(number - 3);
            }
        }

        /// <summary>
        /// Метод рекурсивного вычисления функции
        /// с усложнением на два уровня
        /// и возвратом первых пяти чисел ряда
        /// </summary>
        private static int FibonacciRecV4(int number)
        {
            iter++;
            switch (number)
            {
                case 0: return 0;
                case 1:
                case 2: return 1;
                case 3: return 2;
                case 4: return 3;
                default: return 3 * FibonacciRecV4(number - 3) + 2 * FibonacciRecV4(number - 4);
            }
        }
    }
}
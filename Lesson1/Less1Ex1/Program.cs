using System;

namespace Less1Ex1
{
    internal class Program
    {
        /*
            Долгуев Владимир.
            Требуется реализовать на C# функцию согласно блок-схеме. Блок-схема описывает алгоритм проверки, простое число или нет.
            Написать консольное приложение.
            Алгоритм реализовать отдельно в функции согласно блок-схеме.
            Написать проверочный код в main функции .
            Код выложить на GitHub.
         */

        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите любое целое число больше 1");
                var n = Console.ReadLine();
                if (n.Length > 0)
                {
                    bool isValid = int.TryParse(n, out int number);

                    if (isValid)
                    {
                        if (number < 2)
                        {
                            WriteColorText(ConsoleColor.Red, "Введенное число меньше минимально запрашиваемого");
                            continue;
                        }
                        CheckPrimeNumber(number);
                        break;
                    }
                    WriteColorText(ConsoleColor.Red, "Введенное число слишком длинное либо содержит недопустимые символы");
                }
                else WriteColorText(ConsoleColor.Red, "Число не было введено");
            }
            Console.ReadKey();
        }

        private static void CheckPrimeNumber(int number)
        {
            int i = 2;
            int d = 0;
            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                    // Для ускорения работы рекомендуется раскомментировать строку 'break;'. Ибо нет смысла проверять дальше, если уже нашли делитель.
                    // тут закомментировано т.к. в блок-схеме нет такого выхода из цикла.
                    //break;
                }
                i++;
            }
            WriteColorText(ConsoleColor.Green, "Введенное число - " + ((d == 0) ? "простое" : "не простое"));
        }

        private static void WriteColorText(ConsoleColor color, string error)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(error);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
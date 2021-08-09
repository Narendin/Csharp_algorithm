using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Less1Ex1
{
    internal class Program
    {
        /*
            Долгуев Владимир.
            1. Протестируйте поиск строки в HashSet и в массиве
            Заполните массив и HashSet случайными строками, не менее 10 000 строк.
            Строки можно сгенерировать.
            Потом выполните замер производительности проверки наличия строки в массиве и HashSet.
            Выложите код и результат замеров.

            Итог:
                Поиск в массиве занял: 2508 микросекунд.
                Поиск в HashSet занял: 179 микросекунд.

                P.S. Понимаю, что тик не равен микросекунде, но для визуального сравнения скорости выполнения это не принципиально.
         */
        private static readonly int arrLength = 10_000;

        private static void Main(string[] args)
        {
            var hashSet = new HashSet<string>();
            var array = new string[arrLength];
            Stopwatch stopwatch = new Stopwatch();

            GenerateCollectons(ref hashSet, ref array);

            stopwatch.Start();
            bool isfindPos = Array.IndexOf(array, "HJKGSDFRKU") != -1;
            stopwatch.Stop();
            Console.WriteLine($"Поиск в массиве занял: {stopwatch.ElapsedTicks} микросекунд. Позиция: {(!isfindPos ? "не" : "")} найдена");
            stopwatch.Reset();

            stopwatch.Start();
            isfindPos = hashSet.Contains("HJKGSDFRKU");
            stopwatch.Stop();
            Console.WriteLine($"Поиск в HashSet занял: {stopwatch.ElapsedTicks} микросекунд. Позиция: {(!isfindPos ? "не" : "")} найдена");
            stopwatch.Reset();

            Console.ReadKey();
        }

        private static void GenerateCollectons(ref HashSet<string> hashSet, ref string[] array)
        {
            int lettersInWord = 10;
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            Random rand = new Random();

            for (int i = 0; i < arrLength; i++)
            {
                StringBuilder word = new StringBuilder();
                for (int j = 0; j < lettersInWord; j++)
                {
                    word.Append(letters[rand.Next(letters.Length)]);
                }
                hashSet.Add(word.ToString());
                array[i] = word.ToString();
            }
        }
    }
}
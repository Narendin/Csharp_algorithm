using System;
using System.Linq;

namespace Less2Ex2
{
    internal class Program
    {
        /*
            Долгуев Владимир.
            Требуется написать функцию бинарного поиска, посчитать его асимптотическую сложность и проверить работоспособность функции.
         */

        private static void Main()
        {
            TestBinarySearch("1 2 3 4 5 6 7 8 9 10", 3, 2);
            TestBinarySearch("-345 0 75 76 122 231", 122, 4);
            TestBinarySearch("-725 25 78 295 678 781 874 925 1065 1167 2356 7894 8965", 874, 6);
            TestBinarySearch("1 2 3 4 5 6 7 8 9 0", 3, 2);
            TestBinarySearch("1 2 3 4 5 6 7 8 9 10", 11, 2);
            TestBinarySearch("1 2 3 4 5 в 6 7 8 9 10", 11, 2);

            Console.ReadKey();
        }

        private static void TestBinarySearch(string stringArray, int needFind, int posFindNUm)
        {
            try
            {
                int[] arr = stringArray.Split().Select(item => int.Parse(item)).ToArray();

                // сортируем массив по возрастанию и сравниваем с имеющимся массивом.
                bool asc = arr.OrderBy(item => item).SequenceEqual(arr) ? true : false;
                if (!asc)
                    throw new Exception("Массив должен быть возрастающим");

                int find = BinarySearch(arr, needFind);
                Console.WriteLine($"В массиве '{stringArray}'");
                Console.WriteLine($"Число '{needFind}' " + ((find != -1) ? $"находится на позиции: {find + 1}" : "не найдено"));
                Console.WriteLine($"Ожидаемая позиция: {posFindNUm + 1}");
                Console.Write("Результат выполнения: ");
                Console.ForegroundColor = (find == posFindNUm) ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine($"{find == posFindNUm}\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"В массиве '{stringArray}' ошибка:");
                Console.WriteLine($"{ex.Message}\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        // ниже по факту код из методички
        private static int BinarySearch(int[] inputArray, int searchValue)
        {
            int left = 0;                                   // O(1)
            int right = inputArray.Length - 1;              // O(1)
            while (left <= right)                           // O(30) - обоснование ниже
            {
                int mid = (left + right) / 2;
                if (searchValue == inputArray[mid])         // Каждое сравнение мы либо выходим из цикла, либо сокращаем длину проверяемого массива на 1 и делим пополам;
                {                                           // Свойство Length массива имеет тип int, то максимальный размер массива 2^31-1 элементов;
                    return mid;                             // После первого деления получается (2^31 - 1 - 1) / 2 = (2^31 - 2) / 2 = 2^30 - 1
                }                                           // По итогу деления мы просто уменьшили степень на единицу
                else if (searchValue < inputArray[mid])     // Тогда в наихудшем варианте поиска пройдем цикл 30 раз, в результате чего останется 2^1 - 1 = 2 - 1 = 1 (искомое значение)
                {                                           // Значит, если принять один проход цикла за O(1), асимптотическая сложность цикла равна O(30)
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;                                      // O(1)
        }
    }                                                       // Итого, асимптотическая сложность алгоритма равна O(33), что мжно записать как O(N) без особой погрещности
}
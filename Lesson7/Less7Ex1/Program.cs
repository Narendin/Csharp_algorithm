using System;

namespace Less7Ex1
{
    public class Program
    {
        /*
            Долгуев Владимир.
            Для прямоугольного поля размера M на N клеток, подсчитать количество путей из верхней левой клетки в правую нижнюю.
            Известно что ходить можно только на одну клетку вправо или вниз.
         */

        private static void Main(string[] args)
        {
            int N = GetInt("Введите высоту прямоугольного поля: ");
            int M = GetInt("Введите ширину прямоугольного поля: ");
            Console.WriteLine();

            int[,] A = new int[N, M];
            int i, j;
            for (j = 0; j < M; j++)
                A[0, j] = 1; // Первая строка заполнена единицами
            for (i = 1; i < N; i++)
            {
                A[i, 0] = 1;
                for (j = 1; j < M; j++)
                    A[i, j] = A[i, j - 1] + A[i - 1, j];
            }

            WriteBorad(N, M, A);

            Console.WriteLine($"\nМаксимальное количество маршрутов из левого верхнего угла в правый нижний: {A[N - 1, M - 1]}");
        }

        private static void WriteBorad(int n, int m, int[,] a)
        {
            int i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                    Console.Write($"{a[i, j]}\t");
                Console.Write("\r\n");
            }
        }

        public static int GetInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                var data = Console.ReadLine();
                var isValid = int.TryParse(data, out int result);
                if (isValid) return result;
                Console.WriteLine("Введены некорректные данные.");
            }
        }
    }
}
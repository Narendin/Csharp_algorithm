using BenchmarkDotNet.Running;
using System;

namespace Less3Ex1
{
    public class Program
    {
        /*
            Долгуев Владимир
            Напишите тесты производительности для расчёта дистанции между точками с помощью BenchmarkDotNet.
            Рекомендуем сгенерировать заранее массив данных, чтобы расчёт шёл с различными значениями,
            но сам код генерации должен происходить вне участка кода, время которого будет тестироваться.

            Для каких методов потребуется написать тест:
                Обычный метод расчёта дистанции со ссылочным типом (PointClass — координаты типа float).
                Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа float).
                Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа double).
                Метод расчёта дистанции без квадратного корня со значимым типом (PointStruct — координаты типа float).
            Результаты можно оформить в виде списка или таблицы, в которой наглядно можно будет увидеть время выполнения того или иного метода.
         */

        private static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkClass>();

            Console.ReadKey();
        }

        public static float PointClassDistanceSqrtFloat(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public static float PointStructDistanceSqrtFloat(PointStruct<float> pointOne, PointStruct<float> pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public static double PointStructDistanceSqrtDouble(PointStruct<double> pointOne, PointStruct<double> pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        public static float PointStructDistanceFloat(PointStruct<float> pointOne, PointStruct<float> pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return fsrt(x * x + y * y);
        }

        // Код из методички, который якобы быстрее обычного вычисления квадратного корня
        public static float fsrt(float z)
        {
            if (z == 0) return 0;
            FloatIntUnion u;
            u.i = 0;
            u.f = z;
            u.i -= 1 << 23;
            u.i >>= 1;
            u.i += 1 << 29;
            return u.f;
        }
    }
}
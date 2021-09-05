using System;

namespace Less7Ex2
{
    internal class Program
    {
        /*
            Долгуев Владимир.
            Найти количество способов "превращения" числа 3 в число 25,
            имея операции +1 и *2
         */

        private static void Main(string[] args)
        {
            int a = Less7Ex1.Program.GetInt("Введите первое число: ");
            int b = Less7Ex1.Program.GetInt("Введите второе число число, большее, чем первое: ");

            int variantNum = GetRecResult1(a, b);
            Console.WriteLine(variantNum);
            Console.WriteLine($"Количество вариантов переходов с числа {a} в число {b} первым методом: {variantNum}");

            variantNum = 0;
            GetRecResult2(a, b, ref variantNum);
            Console.WriteLine("Используя только операции +1 и *2");
            Console.WriteLine($"Количество вариантов переходов с числа {a} в число {b} вторым методом: {variantNum}");
        }

        private static int GetRecResult1(int firstNum, int lastNum)
        {
            if (lastNum % 2 != 0 && lastNum > firstNum + 1) return GetRecResult1(firstNum, lastNum - 1);
            if (lastNum % 2 == 0 && lastNum > firstNum + 1) return GetRecResult1(firstNum, lastNum - 1) + GetRecResult1(firstNum, lastNum / 2);

            return 1;
        }

        private static void GetRecResult2(int a, int b, ref int variantNum)
        {
            for (int i = 0; i < 2; i++)
            {
                int n = a;
                if (i == 0) n++;
                else n *= 2;
                if (n < b) GetRecResult2(n, b, ref variantNum);
                else if (n == b) variantNum++;
            }
        }
    }
}
using System;

namespace Less5Ex1
{
    internal class Program
    {
        /*
            Долгуев Владимир.
            Реализуйте DFS и BFS для дерева с выводом каждого шага в консоль.
         */

        private static void Main(string[] args)
        {
            int listLength = 10;    // количество элементов дерева
            int maxNum = 1000;       // максимальное значение в дереве
            Tree tree = new Tree(listLength, maxNum);
            tree.BFS(5);

            Console.WriteLine("\nЧтобы запустить поиск в глубину, намите любую клавишу...");
            Console.ReadKey(true);
            Console.Clear();

            tree.DFS(3);
            Console.ReadKey();
        }
    }
}
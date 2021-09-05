using System;

namespace Less4Ex2
{
    internal class Program
    {
        /*
            Долгуев Владимир.
            2. Реализуйте двоичное дерево и метод вывода его в консоль.
            Реализуйте класс двоичного дерева поиска с операциями вставки, удаления, поиска.
            Дерево должно быть сбалансированным (это требование не обязательно).
            Также напишите метод вывода в консоль дерева, чтобы увидеть, насколько корректно работает ваша реализация.
         */

        private static void Main(string[] args)
        {
            int listLength = 10;    // количество элементов дерева
            int maxNum = 100;       // максимальное значение в дереве

            Tree tree = new Tree(listLength, maxNum);
            tree.PrintTree();
            Console.WriteLine("Для проверки следующих операций нажмите любую клавишу...");
            Console.ReadKey(true);

            Console.Clear();
            tree.AddItem(1);
            tree.AddItem(19);
            tree.AddItem(132);
            tree.AddItem(11785);
            tree.AddItem(1532);
            tree.AddItem(1178);

            tree.PrintTree();
            Console.WriteLine("Для проверки следующих операций нажмите любую клавишу...");
            Console.ReadKey(true);

            Console.Clear();
            tree.RemoveItem(11785);
            tree.RemoveItem(1178);
            tree.RemoveItem(1);

            tree.PrintTree();
            Console.WriteLine("Для проверки следующих операций нажмите любую клавишу...");
            Console.ReadKey(true);

            Console.Clear();
            var root = tree.GetRoot();
            Console.WriteLine($"Корень дерева: {root.Value}");

            var node = tree.GetNodeByValue(1532);
            Console.WriteLine($"Искомое значение: 1532. Найденное значение {node.Value}. Правильность выполнения: {node.Value == 1532}");

            Console.ReadKey(true);
        }
    }
}
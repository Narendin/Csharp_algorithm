using System;
using System.Collections.Generic;

namespace Less5Ex1
{
    public class Tree
    {
        private List<int> _list = new();
        private TreeNode _head;
        private int _length;

        public Tree(int length, int maxNum)
        {
            _length = length;
            Random rand = new();

            for (int i = 0; i < length; i++)
            {
                _list.Add(rand.Next(maxNum));
            }
            _list.Sort();
            _head = CreateTree(0, _length);
        }

        /// <summary>
        /// Добавление нового элемента списка
        /// </summary>
        /// <param name="value">Значение нового элемента</param>
        /// Т.к. новое значение может поломать логику работы бинарного дерева
        /// это самое дерево приходится заново перестраивать
        public void AddItem(int value)
        {
            _list.Add(value);
            _list.Sort();
            _length++;
            _head = CreateTree(0, _length);
        }

        /// <summary>
        /// Генерация бинарного дерева
        /// </summary>
        /// <param name="left">Левая граница списка для определения родителя</param>
        /// <param name="rigth">Правая граница списка для определения родителя</param>
        /// <returns>Корень дерева</returns>
        private TreeNode CreateTree(int left, int rigth)
        {
            TreeNode newNode;
            if (left >= rigth)
                return null;
            else
            {
                newNode = new TreeNode();

                var n = (rigth + left) / 2;
                newNode.Value = _list[n];

                newNode.LeftChild = CreateTree(left, n);
                newNode.RightChild = CreateTree(n + 1, rigth);
            }
            return newNode;
        }

        /// <summary>
        /// Поиск по дереву в ширину
        /// </summary>
        /// <param name="value">Искомое значение</param>
        /// <returns>Узел дерева либо null</returns>
        public TreeNode BFS(int value)
        {
            Console.WriteLine($"Поиск по дереву в ширину (BFS). Ищем число {value}");
            Console.WriteLine("Создаем очередь...");
            var queue = new Queue<TreeNode>();
            Console.WriteLine("В очередь добавляем корень дерева.");
            queue.Enqueue(_head);

            while (queue.Count > 0)
            {
                Console.WriteLine($"\nУзлов в очереди: {queue.Count}.");
                Console.WriteLine("Получаем узел из очереди");
                var node = queue.Dequeue();
                Console.WriteLine($"Сравниваем значения: {node.Value} и {value}. Результат: {node.Value == value}");
                if (node.Value == value)
                {
                    Console.WriteLine("Искомое значенеи найдено, возвращаем узел дерева.");
                    return node;
                }
                if (node.LeftChild != null)
                {
                    Console.WriteLine("Добавляем в очередь левого сына узла.");
                    queue.Enqueue(node.LeftChild);
                }
                if (node.RightChild != null)
                {
                    Console.WriteLine("Добавляем в очередь правого сына узла.");
                    queue.Enqueue(node.RightChild);
                }
            }
            Console.WriteLine("\nОчередь закончилась. Ничего не найдено. Возвращаем null.");
            return null;
        }

        /// <summary>
        /// Поиск по дереву в глубину
        /// </summary>
        /// <param name="value">Искомое значение</param>
        /// <returns>Узел дерева либо null</returns>
        public TreeNode DFS(int value)
        {
            Console.WriteLine($"Поиск по дереву в глубину (DFS). Ищем число {value}");
            Console.WriteLine("Создаем стек...");
            var stack = new Stack<TreeNode>();
            Console.WriteLine("В стек помещаем корень дерева.");
            stack.Push(_head);

            while (stack.Count > 0)
            {
                Console.WriteLine($"\nУзлов в cтеке: {stack.Count}.");
                Console.WriteLine("Извлекаем узел из стека");
                var node = stack.Pop();
                Console.WriteLine($"Сравниваем значения: {node.Value} и {value}. Результат: {node.Value == value}");
                if (node.Value == value)
                {
                    Console.WriteLine("Искомое значенеи найдено, возвращаем узел дерева.");
                    return node;
                }
                if (node.LeftChild != null)
                {
                    Console.WriteLine("Добавляем в очередь левого сына узла.");
                    stack.Push(node.LeftChild);
                }
                if (node.RightChild != null)
                {
                    Console.WriteLine("Добавляем в очередь правого сына узла.");
                    stack.Push(node.RightChild);
                }
            }
            Console.WriteLine("\nСтек пуст. Ничего не найдено. Возвращаем null.");
            return null;
        }
    }
}
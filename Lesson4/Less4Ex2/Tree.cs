using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less4Ex2
{
    public class Tree : ITree
    {
        private List<int> _list = new();
        private TreeNode _head;
        private int _length;
        private int _maxLength;

        public Tree(int length, int maxNum)
        {
            _length = length;
            _maxLength = maxNum.ToString().Length;
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
            _maxLength = _list[_list.Count - 1].ToString().Length;
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
        /// Получение узла дерева по его значению
        /// </summary>
        /// <param name="value">Значение для поиска</param>
        /// <returns>Узел дерева с искомым значением либо null</returns>
        public TreeNode GetNodeByValue(int value)
        {
            if (_head == null) return null;

            var tempNode = _head;
            while (tempNode != null)
            {
                if (value == tempNode.Value)
                {
                    return tempNode;
                }
                if (value < tempNode.Value)
                {
                    tempNode = tempNode.LeftChild;
                }
                else
                {
                    tempNode = tempNode.RightChild;
                }
            }

            return tempNode;
        }

        /// <summary>
        /// Получение корня дерева
        /// </summary>
        /// <returns>Корень дерева</returns>
        public TreeNode GetRoot()
        {
            return _head;
        }

        /// <summary>
        /// Вывод дерева в консоль
        /// </summary>
        public void PrintTree()
        {
            Print(_head);
        }

        /// <summary>
        /// Вывод дерева центрированным обходом
        /// </summary>
        /// <param name="root">Корень дерева</param>
        /// <param name="p">Добавочный отступ при выводе</param>
        private void Print(TreeNode root, string p = "")
        {
            if (root != null)
            {
                Print(root.RightChild, p + new string(' ', _maxLength));
                Console.WriteLine($"{p}{root.Value}");
                Print(root.LeftChild, p + new string(' ', _maxLength));
            }
        }

        /// <summary>
        /// Удаление элемента из дерева
        /// </summary>
        /// <param name="value">Удаляемое значение</param>
        /// Будет удалено первое попавшееся значение, если они повторяются
        /// После эдаления элемента дерево лучше перестроить целиком, иначе оно может перестать быть сбалансированным
        public void RemoveItem(int value)
        {
            _list.Remove(value);
            _length--;
            _maxLength = _list[_list.Count - 1].ToString().Length;
            _head = CreateTree(0, _length);
        }
    }
}
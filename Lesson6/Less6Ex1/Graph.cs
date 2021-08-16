using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less6Ex1
{
    internal class Graph
    {
        private List<Node> _graph;
        private int firstIndex = 1; // пусть граф будет без петель и будет зеркальным

        public Graph(int[,] adjacencyMatrix)
        {
            _graph = new List<Node>();
            // создаем список узлов пока без взаимосвязей
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                _graph.Add(new Node(i));
            }
            // задаем взяимосвязи в соответствии с матрицей смежности
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = firstIndex; j < adjacencyMatrix.GetLength(1); j++)
                {
                    if (adjacencyMatrix[i, j] == 1)
                    {
                        _graph[i].Nodes.Add(_graph[j]);
                        _graph[j].Nodes.Add(_graph[i]);
                    }
                }
                firstIndex++;  // тут мы обходим только верхнюю половину матрицы, т.к. она зеркальная
            }
        }

        /// <summary>
        /// Вывод матрицы смежности в консоль
        /// </summary>
        public void Print()
        {
            var adjacencyMatrix = new int[6, 6];

            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < _graph[i].Nodes.Count; j++)
                {
                    adjacencyMatrix[i, _graph[i].Nodes[j].Value] = 1;
                }
                for (int m = 0; m < adjacencyMatrix.GetLength(1); m++)
                {
                    Console.Write($"{adjacencyMatrix[i, m]} ");
                }
                Console.WriteLine();
            }
        }

        public void BFS()
        {
            Console.WriteLine("Обход графа в ширину начат.");
            var nodeHash = new HashSet<Node>();
            var queue = new Queue<Node>();

            Console.WriteLine($"Помещаем в очередь первый элемент графа (узел {_graph[0].Value})");
            queue.Enqueue(_graph[0]);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                Console.WriteLine($"Обходим узел {node.Value}");
                nodeHash.Add(node);

                foreach (var item in node.Nodes)
                {
                    if (!nodeHash.Contains(item))
                    {
                        Console.WriteLine($"Помещаем в очередь узел {item.Value}");
                        queue.Enqueue(item);
                        nodeHash.Add(item);
                    }
                }
            }
            Console.WriteLine("Обход графа в ширину закончен.\n");
        }

        public void DFS()
        {
            Console.WriteLine("Обход графа в глубину начат.");
            var nodeHash = new HashSet<Node>();
            var stack = new Stack<Node>();
            Console.WriteLine($"Помещаем в стек первый элемент графа (узел {_graph[0].Value})");
            stack.Push(_graph[0]);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                Console.WriteLine($"Обходим узел {node.Value}");
                nodeHash.Add(node);

                foreach (var item in node.Nodes)
                {
                    if (!nodeHash.Contains(item))
                    {
                        Console.WriteLine($"Помещаем в очередь узел {item.Value}");
                        stack.Push(item);
                        nodeHash.Add(item);
                    }
                }
            }
            Console.WriteLine("Обход графа в глубину закончен.\n");
        }
    }
}
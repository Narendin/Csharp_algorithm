using System;

namespace Less6Ex1
{
    internal class Program
    {
        /*
            Долгуев Владимир.
            Модифицируйте DFS и BFS из предыдущего урока, но уже для графа, также с выводом каждого шага
         */

        private static void Main(string[] args)
        {
            var adjacencyMatrix = new int[,] {{0, 1, 0, 0, 1, 0 },
                                              {1, 0, 1, 0, 1, 0 },
                                              {0, 1, 0, 1, 0, 0 },
                                              {0, 0, 1, 0, 1, 1 },
                                              {1, 1, 0, 1, 0, 0 },
                                              {0, 0, 0, 1, 0, 0 }};

            Graph graph = new Graph(adjacencyMatrix);
            graph.Print();

            graph.BFS();

            graph.DFS();

            Console.ReadKey();
        }
    }
}
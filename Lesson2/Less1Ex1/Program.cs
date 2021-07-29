using System;

namespace Less1Ex1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                int firstValue = 15;                    // Значение первого элемента списка
                int listAddCount = 10;                   // Сколько после этого элементов будет добавлено
                int addNodeAfterIndex = 4;              // После акого элемента надо добавить новый
                int newValue = 100;                     // Значение нового элемента
                int findNode = 4;                      // Значение искомого элемента
                int waitingCount = listAddCount + 2;    // Сколько ожидается элементов в списке (+2 т.к. один были значально и один добавили через 'AddNodeAfter')
                int nodeIndex = 3;                      // Индекс элемента для его получения и удаления

                var nodeList = new LinkedList(firstValue);

                string resultString = Test.AddNode(nodeList, firstValue, listAddCount);

                resultString = Test.AddNodeAfter(nodeList, addNodeAfterIndex, newValue, resultString);

                Node node = Test.FindNode(nodeList, findNode);

                Test.GetCount(nodeList, waitingCount);

                Test.GetNodeFromIndex(nodeList, nodeIndex);

                resultString = Test.RemoveNodeByNode(nodeList, node, resultString);

                Test.RemoveNodeByIndex(nodeList, nodeIndex, resultString);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
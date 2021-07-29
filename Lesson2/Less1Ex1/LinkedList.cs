using System;
using System.Text;

namespace Less1Ex1
{
    public class LinkedList : ILinkedList
    {
        private Node head;

        public LinkedList(int value)
        {
            head = new Node { Value = value };
        }

        public void AddNode(int value)
        {
            var lastNode = head;
            while (lastNode.NextNode != null)
            {
                lastNode = lastNode.NextNode;
            }
            var newNode = new Node { Value = value };
            lastNode.NextNode = newNode;
            newNode.PrevNode = lastNode;
        }

        public void AddNodeAfter(Node node, int value)
        {
            var newNode = new Node { Value = value };
            var nextNode = node.NextNode;

            node.NextNode = newNode;
            if (nextNode != null)
                nextNode.PrevNode = newNode;

            newNode.NextNode = nextNode;
            newNode.PrevNode = node;
        }

        public Node FindNode(int searchValue)
        {
            var findNode = head;
            while (findNode != null)
            {
                if (findNode.Value == searchValue)
                    return findNode;
                findNode = findNode.NextNode;
            }
            return null;
        }

        public int GetCount()
        {
            var lastNode = head;
            int nodeCount = 0;
            while (lastNode != null)
            {
                nodeCount++;
                lastNode = lastNode.NextNode;
            }
            return nodeCount;
        }

        public Node GetNodeFromIndex(int index)
        {
            var findNode = head;
            var currentIndex = 0;
            while (findNode != null)
            {
                if (currentIndex == index)
                    return findNode;

                findNode = findNode.NextNode;
                currentIndex++;
            }
            return null;
        }

        public void RemoveNode(int index)
        {
            var currentNode = head;
            var currentIndex = 0;

            while (currentNode != null)
            {
                if (currentIndex == index - 1)
                {
                    RemoveNode(currentNode);
                    return;
                }

                currentIndex++;
                currentNode = currentNode.NextNode;
            }
            throw new Exception("Элемента списка под указанным номером не существует");
        }

        public void RemoveNode(Node node)
        {
            if (node.PrevNode == null)
            {
                if (head.NextNode == null)
                    throw new Exception("Из данного списка невозможно удалить последний элемент");
                head = head.NextNode;
                head.PrevNode = null;
                return;
            }
            else
            {
                node.PrevNode.NextNode = node.NextNode;
                if (node.NextNode != null)
                    node.NextNode.PrevNode = node.PrevNode;
            }
        }

        public override string ToString()
        {
            var node = head;
            StringBuilder result = new StringBuilder();
            while (node != null)
            {
                result.Append($"{node.Value} ");
                node = node.NextNode;
            }
            //result.Remove(result.Length - 1, 1); //ВНИМАНИЕ! выводится с пробелом в конце для упрощения дальнейших операций при проведении тестов!
            return result.ToString();
        }
    }
}
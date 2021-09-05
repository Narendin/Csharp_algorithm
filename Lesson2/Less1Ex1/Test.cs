using System;
using System.Linq;
using System.Text;

namespace Less1Ex1
{
    public class Test
    {
        public static void WriteTestResult<T>(string testName, T wait, T result)
        {
            try
            {
                bool success = wait.Equals(result);
                Console.WriteLine(new string('-', 10));
                Console.Write($"Результат выполнения теста {testName}: ");

                if (success) Console.ForegroundColor = ConsoleColor.Green;
                else Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(success);
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"Ожидаемый результат:  {wait}");
                Console.WriteLine("Полученный результат: " + (result != null ? result.ToString() : "null"));

                string testException = string.Empty;
                if (!success)
                {
                    switch (testName)
                    {
                        case "TestAddNote":
                            testException = "Ошибка в методе добавления элемента в конец списка";
                            break;

                        case "TestAddNodeAfter":
                            testException = "Ошибка в методе добавленя элемента в любое место списка";
                            break;

                        case "TestFindNode":
                            if (result == null)
                                throw new Exception($"Элемент со значением {wait} не найден");
                            testException = "Ошибка в методе поиска элемента по его значению";
                            break;

                        case "TestGetCount":
                            testException = "Ошибка в методе подсчета элементов списка";
                            break;

                        case "TestGetNodeFromIndex":
                            testException = "Ошибка в методе поиска элемента по индексу";
                            break;

                        case "TestRemoveNodeByNode":
                            testException = "Ошибка в методе удаления указанного элемента";
                            break;

                        case "TestRemoveNodeBy":
                            testException = "Ошибка в методе удаления элемента по его индексу";
                            break;
                    }
                    throw new Exception(testException);
                }
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
        }

        public static string AddNode(LinkedList nodeList, int firstValue, int addedCount)
        {
            try
            {
                StringBuilder waitString = new StringBuilder();
                waitString.Append($"{firstValue} ");

                for (int i = firstValue + 1; i <= firstValue + addedCount; i++)
                {
                    nodeList.AddNode(i);
                    waitString.Append($"{i} ");
                }
                string resultString = nodeList.ToString();

                WriteTestResult("TestAddNote", waitString.ToString(), resultString);
                return resultString;
            }
            catch (Exception ex)
            {
                WriteException(ex);
                return string.Empty;
            }
        }

        public static string AddNodeAfter(LinkedList nodeList, int indexAfterAdd, int newValue, string baseString)
        {
            try
            {
                Node node = nodeList[indexAfterAdd];
                if (node == null)
                    throw new Exception($"Элемент под индексом {indexAfterAdd} не существует");
                nodeList.AddNodeAfter(node, newValue);

                var elementList = baseString.Split().ToList();
                elementList.Insert(indexAfterAdd + 1, newValue.ToString());

                string waitString = string.Join(" ", elementList);
                string resultString = nodeList.ToString();

                WriteTestResult("TestAddNodeAfter", waitString, resultString);
                return resultString;
            }
            catch (Exception ex)
            {
                WriteException(ex);
                return baseString;
            }
        }

        public static Node FindNode(LinkedList nodeList, int findValue)
        {
            try
            {
                Node findNumber = nodeList.FindNode(findValue);
                WriteTestResult("TestFindNode", findValue, findNumber?.Value);
                return findNumber;
            }
            catch (Exception ex)
            {
                WriteException(ex);
                return null;
            }
        }

        public static void GetCount(LinkedList nodeList, int waitingCount)
        {
            try
            {
                WriteTestResult("TestGetCount", waitingCount, nodeList.GetCount());
            }
            catch (Exception ex) { WriteException(ex); }
        }

        public static void GetNodeFromIndex(LinkedList nodeList, int index)
        {
            try
            {
                Node findNode = nodeList[index];
                bool isFind = findNode == null ? false : true;
                WriteTestResult("TestGetNodeFromIndex", isFind, true);
            }
            catch (Exception ex) { WriteException(ex); }
        }

        public static string RemoveNodeByNode(LinkedList nodeList, Node node, string baseString)
        {
            try
            {
                nodeList.RemoveNode(node);
                string waitString = baseString.Replace($"{node.Value} ", "");
                string resultString = nodeList.ToString();
                WriteTestResult("TestRemoveNodeByNode", waitString, resultString);
                return resultString;
            }
            catch (Exception ex)
            {
                Console.WriteLine(new string('-', 10));
                WriteException(ex);
                return baseString;
            }
        }

        public static string RemoveNodeByIndex(LinkedList nodeList, int index, string baseString)
        {
            try
            {
                nodeList.RemoveNode(index);

                var elementList = baseString.Split().ToList();
                elementList.RemoveAt(index - 1);

                string waitString = string.Join(" ", elementList);
                string resultString = nodeList.ToString(); ;

                WriteTestResult("TestRemoveNodeBy", waitString, nodeList.ToString());
                return resultString;
            }
            catch (Exception ex)
            {
                WriteException(ex);
                return baseString;
            }
        }

        public static void WriteException(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{ex.Message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
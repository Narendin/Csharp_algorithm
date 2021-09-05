namespace Less4Ex2
{
    public interface ITree
    {
        TreeNode GetRoot(); // Получить корень дерева

        void AddItem(int value); // добавить узел

        void RemoveItem(int value); // удалить узел по значению

        TreeNode GetNodeByValue(int value); //получить узел дерева по значению

        void PrintTree(); //вывести дерево в консоль
    }
}
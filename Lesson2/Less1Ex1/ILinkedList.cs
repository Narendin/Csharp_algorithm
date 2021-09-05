namespace Less1Ex1
{
    internal interface ILinkedList
    {
        /// <summary>
        /// Добавление нового элемента списка в его конец
        /// </summary>
        /// <param name="value">Значение нового элемента списка</param>
        void AddNode(int value);

        /// <summary>
        /// Добавление нового элемента списка после определённого элемента
        /// </summary>
        /// <param name="node">Элемент списка, поле которого добавляется новый</param>
        /// <param name="value">Значение нового элемента списка</param>
        void AddNodeAfter(Node node, int value);

        /// <summary>
        /// Количество элементов в списке
        /// </summary>
        /// <returns>Количество элементов в списке</returns>
        int GetCount();

        /// <summary>
        /// Получение элемента списка по его индексу
        /// </summary>
        /// <returns>Элемент списка по указанному индексу либо null</returns>
        Node GetNodeFromIndex(int index);

        /// <summary>
        /// Удаление элемента по порядковому номеру
        /// </summary>
        /// <param name="index">Порядковый номер удаляемого элемента</param>
        void RemoveNode(int index); //

        /// <summary>
        /// Удаление указанного элемента
        /// </summary>
        /// <param name="node">Удаляемый элемент</param>
        void RemoveNode(Node node); //

        /// <summary>
        /// Поиск элемента по его значению
        /// </summary>
        /// <param name="searchValue">Значение искомого элемента списка</param>
        /// <returns>Первый найденный элемент либо null</returns>
        Node FindNode(int searchValue); //
    }
}
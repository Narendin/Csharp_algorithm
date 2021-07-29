namespace Less1Ex1
{
    /// <summary>
    /// Элемент именованного списка
    /// </summary>
    public sealed class Node
    {
        /// <summary>
        /// Значение элемента списка
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Ссылка на следующий элемент списка
        /// </summary>
        public Node NextNode { get; set; }

        /// <summary>
        /// Ссылка на предыдущий элемент списка
        /// </summary>
        public Node PrevNode { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
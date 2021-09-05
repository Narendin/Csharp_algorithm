namespace Less3Ex1
{
    public struct PointStruct<T>
    {
        public T X;
        public T Y;

        public PointStruct(T x, T y)
        {
            X = x;
            Y = y;
        }
    }
}
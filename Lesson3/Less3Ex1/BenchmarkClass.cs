using BenchmarkDotNet.Attributes;

namespace Less3Ex1
{
    [MemoryDiagnoser]
    [RankColumn]
    public class BenchmarkClass
    {
        private PointClass classPointOne = new(0.1F, 12.7F);
        private PointClass classPointTwo = new(25.4F, -13.2F);

        private PointStruct<float> structPointOneFloat = new(0.1F, 12.7F);
        private PointStruct<float> structPointTwoFloat = new(25.4F, -13.2F);

        private PointStruct<double> structPointOneDouble = new(0.1F, 12.7F);
        private PointStruct<double> structPointTwoDouble = new(25.4F, -13.2F);

        [Params(1000, 10000)]
        public int n;

        [Benchmark]
        public void TestPointClassDistanceSqrtFloat()
        {
            for (int i = 0; i < n; i++)
            {
                float result = Program.PointClassDistanceSqrtFloat(classPointOne, classPointTwo);
            }
        }

        [Benchmark]
        public void TestPointStructDistanceSqrtFloat()
        {
            for (int i = 0; i < n; i++)
            {
                float result = Program.PointStructDistanceSqrtFloat(structPointOneFloat, structPointTwoFloat);
            }
        }

        [Benchmark]
        public void TestPointStructDistanceSqrtDouble()
        {
            for (int i = 0; i < n; i++)
            {
                double result = Program.PointStructDistanceSqrtDouble(structPointOneDouble, structPointTwoDouble);
            }
        }

        [Benchmark]
        public void TestPointStructDistanceFloat()
        {
            for (int i = 0; i < n; i++)
            {
                float result = Program.PointStructDistanceFloat(structPointOneFloat, structPointTwoFloat);
            }
        }
    }
}
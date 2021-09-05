using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less8Ex1
{
    public static class BucketSort
    {
        private static int _min;
        private static int _max;

        public static int[] GenerateArray(int min, int max, int length)
        {
            _min = min;
            _max = max;

            var array = new int[length];
            var random = new Random();

            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(min, max);
            }
            return array;
        }

        public static void Sort(int[] arr)
        {
        }
    }
}
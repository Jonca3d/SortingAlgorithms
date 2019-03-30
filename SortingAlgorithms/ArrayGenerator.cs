using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public static class ArrayGenerator
    {
        public static int[] Generate(int arrayLength, int minValue, int maxValue)
        {
            Random rnd = new Random();
            int[] array = new int[arrayLength];
            for(int i = 0; i < arrayLength; i++)
            {
                array[i] = rnd.Next(minValue, maxValue);
            }

            return array;
        }
    }
}

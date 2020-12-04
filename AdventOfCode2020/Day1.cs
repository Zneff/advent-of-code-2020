using System.Collections.Generic;

namespace AdventOfCode2020
{
    public static class Day1
    {
        public static int Calculate2Sum_NlogN(List<int> list, int target)
        {
            list.Sort();
            var low = 0;
            var high = list.Count - 1;

            while (low < high)
            {
                var sum = list[low] + list[high];
                if (sum == target) return list[low] * list[high];
                if (sum < target)
                {
                    low++;
                }
                else
                {
                    high--;
                }
            }

            return -1;
        }

        public static int Calculate3SumNaive_N3(List<int> list, int target)
        {
            for (var i = 0; i < list.Count - 2; i++)
            for (var j = i + 1; j < list.Count - 2; j++)
            for (var k = j + 1; k < list.Count; k++)
            {
                if (list[i] + list[j] + list[k] == target)
                {
                    return list[i] * list[j] * list[k];
                }
            }

            return -1;
        }

        public static int Calculate3Sum_N2(List<int> list, int target)
        {
            list.Sort();

            for (var i = 0; i < list.Count - 2; i++)
            {
                var low = i + 1;
                var high = list.Count - 1;

                while (low < high)
                {
                    var sum = list[i] + list[low] + list[high];
                    if (sum == target) return list[i] * list[low] * list[high];
                    if (sum < target)
                    {
                        low++;
                    }
                    else
                    {
                        high--;
                    }
                }
            }

            return -1;
        }
    }
}
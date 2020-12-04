using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day3
    {
        public static char[][] GetMap(IEnumerable<string> input)
        {
            return input.Select(x => x.ToCharArray()).ToArray();
        }

        public static int CountTrees(char[][] map, int right, int down)
        {
            var count = 0;

            var row = 0;
            var column = 0;

            while (row < map.Length)
            {
                if (map[row][column % map[row].Length] == '#') count++;

                row += down;
                column += right;
            }

            return count;
        }
    }
}
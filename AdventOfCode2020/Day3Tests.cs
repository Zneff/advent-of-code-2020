using System.IO;
using NUnit.Framework;

namespace AdventOfCode2020
{
    [TestFixture]
    public class Day3Tests
    {
        private static char[][] GetExampleData()
        {
            var input = new[]
            {
                "..##.......",
                "#...#...#..",
                ".#....#..#.",
                "..#.#...#.#",
                ".#...##..#.",
                "..#.##.....",
                ".#.#.#....#",
                ".#........#",
                "#.##...#...",
                "#...##....#",
                ".#..#...#.#",
            };
            return Day3.GetMap(input);
        }
        
        private static char[][] GetInputData()
        {
            var input = File.ReadAllLines("Input\\Day3.txt");
            return Day3.GetMap(input);
        }

        [Test]
        public void TestExample1()
        {
            var input = GetExampleData();

            var result = Day3.CountTrees(input, 3, 1);
            
            Assert.AreEqual(7, result);
        }
        
        [Test]
        public void TestInput1()
        {
            var input = GetInputData();

            var result = Day3.CountTrees(input, 3, 1);
            
            Assert.AreEqual(148, result);
        }
        
        [Test]
        public void TestExample2()
        {
            var input = GetExampleData();

            var result1 = Day3.CountTrees(input, 1, 1);
            var result2 = Day3.CountTrees(input, 3, 1);
            var result3 = Day3.CountTrees(input, 5, 1);
            var result4 = Day3.CountTrees(input, 7, 1);
            var result5 = Day3.CountTrees(input, 1, 2);

            var result = result1 * result2 * result3 * result4 * result5; 
            
            Assert.AreEqual(2, result1);
            Assert.AreEqual(7, result2);
            Assert.AreEqual(3, result3);
            Assert.AreEqual(4, result4);
            Assert.AreEqual(2, result5);
            
            Assert.AreEqual(336, result);
        }
        
        [Test]
        public void TestInput2()
        {
            var input = GetInputData();

            var result1 = Day3.CountTrees(input, 1, 1);
            var result2 = Day3.CountTrees(input, 3, 1);
            var result3 = Day3.CountTrees(input, 5, 1);
            var result4 = Day3.CountTrees(input, 7, 1);
            var result5 = Day3.CountTrees(input, 1, 2);

            var result = result1 * result2 * result3 * result4 * result5;
            
            Assert.AreEqual(727923200, result);
        }
    }
}
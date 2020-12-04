using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2020
{
    [TestFixture]
    public class Day1Tests
    {
        private const int Example2SumAnswer = 514579;
        private const int Example3SumAnswer = 241861950;
        private const int Input2SumAnswer = 436404;
        private const int Input3SumAnswer = 274879808;

        private static List<int> GetExampleData()
        {
            return new List<int> {1721, 979, 366, 299, 675, 1456};
        }
        
        private static List<int> GetInputData()
        {
            return File.ReadAllLines("Input\\Day1.txt")
                .Select(int.Parse).ToList();
        }
        
        [Test]
        public void Test2SumExample()
        {
            var input = GetExampleData();

            var result = Day1.Calculate2Sum_NlogN(input, 2020);
            
            Assert.AreEqual(Example2SumAnswer, result);
        }

        [Test]
        public void Test3SumNaiveExample()
        {
            var input = GetExampleData();

            var result = Day1.Calculate3SumNaive_N3(input, 2020);
            
            Assert.AreEqual(Example3SumAnswer, result);
        }
        
        [Test]
        public void Test3SumExample()
        {
            var input = GetExampleData();

            var result = Day1.Calculate3Sum_N2(input, 2020);
            
            Assert.AreEqual(Example3SumAnswer, result);
        }
        
        [Test]
        public void Test2SumInput()
        {
            var input = GetInputData();

            var result = Day1.Calculate2Sum_NlogN(input, 2020);
            
            Assert.AreEqual(Input2SumAnswer, result);
        }

        [Test]
        public void Test3SumNaiveInput()
        {
            var input = GetInputData();

            var result = Day1.Calculate3SumNaive_N3(input, 2020);
            
            Assert.AreEqual(Input3SumAnswer, result);
        }
        
        [Test]
        public void Test3SumInput()
        {
            var input = GetInputData();

            var result = Day1.Calculate3Sum_N2(input, 2020);
            
            Assert.AreEqual(Input3SumAnswer, result);
        }
    }
}
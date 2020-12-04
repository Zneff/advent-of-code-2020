using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace AdventOfCode2020
{
    [TestFixture]
    public class Day2Tests
    {
        private static IEnumerable<Day2.Record> GetExampleData()
        {
            var input = new List<string>
            {
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc"
            };
            return Day2.Record.Parse(input);
        }        
        
        private static IEnumerable<Day2.Record> GetInputData()
        {
            var input = File.ReadAllLines("Input\\Day2.txt");
            return Day2.Record.Parse(input);
        }

        [Test]
        public void TestExample1()
        {
            var input = GetExampleData();

            var result = Day2.CountValid1_N(input);
            
            Assert.AreEqual(2, result);
        }
        
        [Test]
        public void TestInput1()
        {
            var input = GetInputData();

            var result = Day2.CountValid1_N(input);
            
            Assert.AreEqual(524, result);
        }
        
        [Test]
        public void TestExample2()
        {
            var input = GetExampleData();

            var result = Day2.CountValid2_N(input);
            
            Assert.AreEqual(1, result);
        }
        
        [Test]
        public void TestInput2()
        {
            var input = GetInputData();

            var result = Day2.CountValid2_N(input);
            
            Assert.AreEqual(485, result);
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Day2
    {
        public class Record
        {
            public int FirstDigit { get; private set; }
            public int SecondDigit { get; private set; }
            public char Letter { get; private set; }
            public string Password { get; private set; }

            public override string ToString()
            {
                return $"{FirstDigit}-{SecondDigit} {Letter}: {Password}";
            }

            public static IEnumerable<Record> Parse(IEnumerable<string> input)
            {
                return input
                    .Select(x => x.Split(' '))
                    .Select(x => new Record
                    {
                        FirstDigit = int.Parse(x[0].Split('-')[0]),
                        SecondDigit = int.Parse(x[0].Split('-')[1]),
                        Letter = x[1][0],
                        Password = x[2]
                    });
            }
        }

        public static int CountValid1_N(IEnumerable<Record> list)
        {
            var valid = 0;

            foreach (var record in list)
            {
                var count = record.Password.Count(letter => letter == record.Letter);
                if (record.FirstDigit <= count && count <= record.SecondDigit) valid++;
            }

            return valid;
        }

        public static int CountValid2_N(IEnumerable<Record> list)
        {
            var valid = 0;

            foreach (var record in list)
            {
                if (record.Password.Length < record.SecondDigit) continue;
                var count = 0;
                if (record.Password[record.FirstDigit - 1] == record.Letter) count++;
                if (record.Password[record.SecondDigit - 1] == record.Letter) count++;
                if (count == 1) valid++;
            }

            return valid;
        }
    }
}
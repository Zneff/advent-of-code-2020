using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public static class Day4
    {
        public class Passport
        {
            public string Byr { get; set; } // (Birth Year)
            public string Iyr { get; set; } // (Issue Year)
            public string Eyr { get; set; } // (Expiration Year)
            public string Hgt { get; set; } // (Height)
            public string Hcl { get; set; } // (Hair Color)
            public string Ecl { get; set; } // (Eye Color)
            public string Pid { get; set; } // (Passport ID)

            public bool IsValid()
            {
                if (HasMissingFields()) return false;

                if (!IsYearValid(Byr, 1920, 2002)) return false;
                if (!IsYearValid(Iyr, 2010, 2020)) return false;
                if (!IsYearValid(Eyr, 2020, 2030)) return false;

                if (!IsHeightValid()) return false;
                if (!IsHairColorValid()) return false;
                if (!IsEyeColorValid()) return false;
                if (!IsPassportIdValid()) return false;

                return true;
            }
            
            public bool HasMissingFields()
            {
                var missing = string.IsNullOrEmpty(Byr)
                              || string.IsNullOrEmpty(Iyr)
                              || string.IsNullOrEmpty(Eyr)
                              || string.IsNullOrEmpty(Hgt)
                              || string.IsNullOrEmpty(Hcl)
                              || string.IsNullOrEmpty(Ecl)
                              || string.IsNullOrEmpty(Pid);
                return missing;
            }

            private static bool IsYearValid(string value, int min, int max)
            {
                return int.TryParse(value, out var year) && year >= min && year <= max;
            }

            private bool IsHeightValid()
            {
                if (Hgt.EndsWith("cm")
                    && int.TryParse(Hgt[..^2], out var centimeters)
                    && centimeters >= 150 && centimeters <= 193)
                {
                    return true;
                }
                
                if (Hgt.EndsWith("in")
                    && int.TryParse(Hgt[..^2], out var inches)
                    && inches >= 59 && inches <= 76)
                {
                    return true;
                }

                return false;
            }
            
            private bool IsHairColorValid()
            {
                var regex = new Regex(@"#[0-9a-f]{6}");
                return Hcl.Length == 7 && regex.IsMatch(Hcl);
            }
            
            private bool IsEyeColorValid()
            {
                var possibleColors = new[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
                return possibleColors.Contains(Ecl);
            }
            
            private bool IsPassportIdValid()
            {
                var regex = new Regex(@"[0-9]{9}");
                return Pid.Length == 9 && regex.IsMatch(Pid);
            }
        }

        public static List<Passport> Parse(IEnumerable<string> input)
        {
            var result = new List<Passport>();
            var passport = new Passport();
            foreach (var str in input)
            {
                if (string.IsNullOrEmpty(str))
                {
                    result.Add(passport);
                    passport = new Passport();
                    continue;
                }

                foreach (var pair in str.Split(' ')
                    .Select(x => new
                    {
                        Field = x.Split(':')[0], 
                        Value = x.Split(':')[1]
                    }))
                {
                    switch (pair.Field)
                    {
                        case "byr":
                            passport.Byr = pair.Value;
                            break;
                        case "iyr":
                            passport.Iyr = pair.Value;
                            break;
                        case "eyr":
                            passport.Eyr = pair.Value;
                            break;
                        case "hgt":
                            passport.Hgt = pair.Value;
                            break;
                        case "hcl":
                            passport.Hcl = pair.Value;
                            break;
                        case "ecl":
                            passport.Ecl = pair.Value;
                            break;
                        case "pid":
                            passport.Pid = pair.Value;
                            break;
                    }
                }
            }
            result.Add(passport);
            
            return result;
        }

        public static int CountWithRequiredFields(IEnumerable<Passport> passports)
        {
            return passports.Count(x => !x.HasMissingFields());
        }
        
        public static int CountValid(IEnumerable<Passport> passports)
        {
            return passports.Count(x => x.IsValid());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculatorKata
{
    public class StringCalculator
    {    
        public static int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;

            Regex.Match(numbers, @"(?<!\d)-\d+")
                .Groups.Cast<Group>()
                .SelectMany(g => g.Captures)
                .FirstOrDefault(c => throw new ArgumentException($"negatives not allowed: {c.Value}"));

            return Regex.Split(numbers, @"\D+")
                    .Select(n => int.TryParse(n, out int num) ? num : 0)
                    .Sum();
        }
    }
}

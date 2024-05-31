﻿using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Markup;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers to add, separated by commas");

            string? input = Console.ReadLine();

            try
            {

                int result = Add(input);
                Console.WriteLine($"The sum is: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            var numArray = numbers.Split(',');

            if (numArray.Length > 2)
            { 
                throw new Exception("Only maximum of 2 numbers allowed");
            }
                
                
            var parsedNumber = numArray.Select(num =>
            {
                int parsedValue;
                return int.TryParse(num, out parsedValue) ? parsedValue : 0;

            }).ToArray();

            int sum = parsedNumber.Sum();

            return sum;
        }
    }
}


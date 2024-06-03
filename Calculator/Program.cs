using System.Collections.Generic;
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

            //Add comma and newline delimiter 
            var delimiters = new string [] { ",", "\\n"};

            var numArray = numbers.Split(delimiters, StringSplitOptions.None);           
                
            var parsedNumber = numArray.Select(num =>
            {
                int parsedValue;
                return int.TryParse(num, out parsedValue) ? parsedValue : 0;

            }).ToArray();

            //Make any value greater than 1000 an invalid number (invalid numbers are converted to 0), 
            //calculation should continue and avoid the large number
            parsedNumber = numArray.Select(num =>
            {
                if(int.TryParse(num, out int largeNumber)) { 
                
                    if (largeNumber > 1000)
                    { 
                        return 0; 
                    }

                    return largeNumber;
                }
                return 0;

            }).ToArray();

            //Check for negative numbers, if found throw exception and include negatives in error message
            var negativeNumbers = parsedNumber.Where(n => n <0).ToArray();
            if (negativeNumbers.Any() )
            {
                throw new ArgumentException($"Negative numbers not allowed, following are negative: {string.Join(", ",negativeNumbers)}");
            }

            int sum = parsedNumber.Sum();

            return sum;
        }
    }
}


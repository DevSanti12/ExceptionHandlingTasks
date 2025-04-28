using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter Input Line: ");
            string input = Console.ReadLine();
            
            //Using exception handling
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input)) throw new ArgumentException("Input string cannot be empty or whitespace.");
            
            //Print out the first character
            Console.WriteLine("First character of entered line is: {0} ", input.Substring(0, 1));
        }
    }
}
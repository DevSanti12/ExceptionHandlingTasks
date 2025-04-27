using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // TODO: Implement the task here.
            string firstChar;
            try
            {
                firstChar = args[0].Substring(0, 1);
                Console.WriteLine("First character of entered line is: {0} ", firstChar);
            }
            catch (Exception)
            {
                throw new ArgumentNullException(nameof(firstChar));
            }
        }
    }
}
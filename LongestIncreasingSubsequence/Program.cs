using System;

namespace LongestIncreasingSubsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = new SequenceService();
            string input = args.Length > 0 ? string.Join(" ", args) : "6 1 5 9 2";
            string result = service.GetLongestIncreasingSubsequence(input);

            Console.WriteLine($"Input: {input}");
            Console.WriteLine($"LIS Result: {result}");
        }
    }
}
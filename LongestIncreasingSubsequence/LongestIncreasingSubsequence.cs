namespace LongestIncreasingSubsequence
{
    public class SequenceService
    {
        public string GetLongestIncreasingSubsequence(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            int[] numbers = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            if (numbers.Length == 0)
                return string.Empty;

            int maxLen = 1;
            int bestStart = 0;

            int currentLen = 1;
            int currentStart = 0;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[i - 1])
                {
                    currentLen++;
                }
                else
                {
                    // Strict inequality (>) preserves the EARLIEST sequence on length ties
                    if (currentLen > maxLen)
                    {
                        maxLen = currentLen;
                        bestStart = currentStart;
                    }
                    currentStart = i;
                    currentLen = 1;
                }
            }

            if (currentLen > maxLen)
            {
                maxLen = currentLen;
                bestStart = currentStart;
            }

            return string.Join(" ", numbers.Skip(bestStart).Take(maxLen));
        }
    }
}
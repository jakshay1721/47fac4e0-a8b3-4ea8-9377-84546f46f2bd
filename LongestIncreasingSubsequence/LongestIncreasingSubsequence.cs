using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestIncreasingSubsequence
{
    public class LongestIncreasingSubsequence
    {
        /// <summary>
        /// Finds the longest strictly increasing subsequence in a space-separated string of integers.
        /// If multiple sequences share the maximum length, the earliest one is returned.
        /// </summary>
        /// <param name="input">Space-separated integer string.</param>
        /// <returns>Space-separated string of the longest increasing subsequence.</returns>
        public string GetLongestIncreasingSubsequence(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            int[] numbers = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            if (numbers.Length == 0)
            {
                return string.Empty;
            }

            List<int> lis = FindLIS(numbers);
            return string.Join(" ", lis);
        }

        private List<int> FindLIS(int[] nums)
        {
            int n = nums.Length;

            // dp[i] stores the length of the LIS ending at index i
            int[] dp = new int[n];
            
            // parent[i] stores the previous index in the LIS ending at index i
            int[] parent = new int[n];

            Array.Fill(dp, 1);
            Array.Fill(parent, -1);

            int maxLength = 1;
            int bestEndIndex = 0;

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    // Strictly increasing condition
                    if (nums[i] > nums[j])
                    {
                        if (dp[j] + 1 > dp[i])
                        {
                            dp[i] = dp[j] + 1;
                            parent[i] = j;
                        }
                    }
                }

                // Strictly greater than (>) ensures that if a sequence of the same 
                // maximum length appears later, we keep the earlier sequence (bestEndIndex stays unchanged).
                if (dp[i] > maxLength)
                {
                    maxLength = dp[i];
                    bestEndIndex = i;
                }
            }

            // Reconstruct the sequence from parent pointers
            List<int> result = new List<int>();
            int curr = bestEndIndex;
            while (curr != -1)
            {
                result.Add(nums[curr]);
                curr = parent[curr];
            }

            result.Reverse();
            return result;
        }
    }
}
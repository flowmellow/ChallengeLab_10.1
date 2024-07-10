/*
Question 1:
You are the manager of a basketball team. For the upcoming tournament, you want to choose the team with the highest overall score. The score of the team is the sum of scores of all the players in the team.
However, the basketball team is not allowed to have conflicts. A conflict exists if a younger player has a strictly higher score than an older player. A conflict does not occur between players of the same age.
Given two lists, scores and ages, where each scores[i] and ages[i] represents the score and age of the ith player, respectively, return the highest overall score of all possible basketball teams.
Example 1:
Input: scores = [1,3,5,10,15], ages = [1,2,3,4,5]
Output: 34
Explanation: You can choose all the players.
Example 2:
Input: scores = [4,5,6,5], ages = [2,1,2,1]
Output: 16
Explanation: It is best to choose the last 3 players. Notice that you are allowed to choose multiple people of the same age.
Example 3:
Input: scores = [1,2,3,5], ages = [8,9,10,1]
Output: 6
Explanation: It is best to choose the first 3 players.
*/

namespace ChallengeLab_10._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] scores1 = { 1, 3, 5, 10, 15 };
            int[] ages1 = { 1, 2, 3, 4, 5 };
            int[] scores2 = { 4, 5, 6, 5 };
            int[] ages2 = { 2, 1, 2, 1 };
            int[] scores3 = { 1, 2, 3, 5 };
            int[] ages3 = { 8, 9, 10, 1 };

            Solution solution = new Solution();

            Console.WriteLine(solution.BestTeamsScore(scores1, ages1)); // Output: 34
            Console.WriteLine(solution.BestTeamsScore(scores2, ages2)); // Output: 16
            Console.WriteLine(solution.BestTeamsScore(scores3, ages3)); // Output: 6

        }
    }

    public class Solution
    {
        public int BestTeamsScore(int[] scores, int[] ages)
        {                        
            int n = scores.Length; // initialize n with lenght of array (both scores and ages) for cleaner readability
            var players = new (int score, int age)[n]; //using an array of tuples nambe players. Each tuple contains two integers

            for (int i = 0; i < n; i++) // assigns a tuple to each player from the iput arrays to the players array
            {
                players[i] = (scores[i], ages[i]);
            }

            // sorts the players array by age then by score back to the array.
            players = players.OrderBy(p => p.age).ThenBy(p => p.score).ToArray();

            int[] dp = new int[n]; // An array to capture the best possible team score
            int maxScore = 0; //keep track of the highest score found

            for (int i = 0; i < n; i++) // use a loop to fill the array and iterates through each player i
            {
                dp[i] = players[i].score; // Start with the player's own score
                for (int j = 0; j < i; j++) // iterates through each previous player j
                {
                    if (players[j].score <= players[i].score) // checks if ther is no conflict between j and i
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + players[i].score); // if no conflict update dp[i] to the maximum value between
                                                                           // dp[i] and jp[j]+ player[i].score
                    }
                }
                maxScore = Math.Max(maxScore, dp[i]); //after updating dp[i] and maxScore maximum value is updated
            }

            return maxScore; //returns highest overall score

        }

    }

}

using System;

namespace Assignment_5_3_Placing_Flowers_and_Climbing_Stairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Here we test the flower-planting method with a sample flowerbed.
            // This lets us see if the logic works before turning it in.
            var canPlant = CanPlaceFlowers(new int[] { 1, 0, 0, 0, 1 }, 1);

            // Print the result so we can visually confirm the output.
            Console.WriteLine($"Can place flowers: {canPlant}");

            // Now we test the climbing stairs method with 5 steps.
            // This shows how many different ways you can climb 5 stairs.
            var ways = ClimbStairs(5);

            // Print the result for the stairs problem.
            Console.WriteLine($"Ways to climb stairs: {ways}");
        }

        // ----------------------------
        // METHOD 1: CAN PLACE FLOWERS
        // ----------------------------
        public static bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            // This keeps track of how many flowers we successfully plant.
            var count = 0;

            // Loop through every spot in the flowerbed from left to right.
            for (var i = 0; i < flowerbed.Length; i++)
            {
                // We only care about empty spots (0). If it's 1, skip it.
                if (flowerbed[i] == 0)
                {
                    // Check if the spot to the LEFT is safe.
                    // If we're at the very first spot, it's automatically safe.
                    var emptyLeft = (i == 0) || (flowerbed[i - 1] == 0);

                    // Check if the spot to the RIGHT is safe.
                    // If we're at the last spot, it's automatically safe.
                    var emptyRight = (i == flowerbed.Length - 1) || (flowerbed[i + 1] == 0);

                    // If both sides are safe, we can plant a flower here.
                    if (emptyLeft && emptyRight)
                    {
                        // Mark this spot as planted.
                        flowerbed[i] = 1;

                        // Increase our count of planted flowers.
                        count++;

                        // If we've planted enough flowers, we can stop early.
                        if (count >= n)
                            return true;
                    }
                }
            }

            // After checking all spots, return whether we planted enough.
            return count >= n;
        }

        // ----------------------------
        // METHOD 2: CLIMB STAIRS
        // ----------------------------
        public static int ClimbStairs(int n)
        {
            // If the staircase is only 1 or 2 steps, the answer is the same as n.
            // (1 step = 1 way, 2 steps = 2 ways)
            if (n <= 2)
                return n;

            // This represents the number of ways to reach the step right before the top.
            var oneStepBefore = 2;

            // This represents the number of ways to reach two steps before the top.
            var twoStepsBefore = 1;

            // This will store the number of ways for the current step as we calculate.
            var result = 0;

            // Start calculating from step 3 up to step n.
            for (var i = 3; i <= n; i++)
            {
                // The number of ways to reach this step is the sum of the previous two.
                result = oneStepBefore + twoStepsBefore;

                // Move the window forward: the old "one step before" becomes "two steps before".
                twoStepsBefore = oneStepBefore;

                // And the new result becomes the new "one step before".
                oneStepBefore = result;
            }

            // Return the total number of ways to reach step n.
            return result;
        }
    }
}

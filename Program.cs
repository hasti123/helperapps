using System;
using System.Collections.Generic;
using System.Linq;

namespace PiDay
{
    class Program
    {
        public static void Main()
        {
            var numList = new List<char> {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

            var perms = GeneratePermutations(numList);
            var finalpermlist = perms.Select(perm => string.Join(",", perm.ToArray())).Select(newPermutation => newPermutation.Replace(",", "")).ToList();

            foreach (var combination in from combination in finalpermlist let temp = Works(combination) where temp select combination)
            {
                Console.WriteLine(combination);
                Console.WriteLine("success");
                Console.ReadKey();
            }

            Console.WriteLine("Failure");
            Console.ReadKey();
        }

        private static long BuildNextNumber(string num, int numberSize)
        {
            return long.Parse(num.Substring(0, numberSize));
        }

        private static bool Works(string num)
        {
            for (var i = 1; i <= 10; i++)
            {
                var tempNum = BuildNextNumber(num, i);
                if (tempNum % i != 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static List<List<T>> GeneratePermutations<T>(IReadOnlyList<T> items)
        {
            // Make an array to hold the
            // permutation we are building.
            var currentPermutation = new T[items.Count];

            // Make an array to tell whether
            // an item is in the current selection.
            var inSelection = new bool[items.Count];

            // Make a result list.
            var results = new List<List<T>>();

            // Build the combinations recursively.
            PermuteItems<T>(items, inSelection,
                currentPermutation, results, 0);

            // Return the results.
            return results;
        }

        // Recursively permute the items that are
        // not yet in the current selection.
        private static void PermuteItems<T>(IReadOnlyList<T> items, IList<bool> inSelection, IList<T> currentPermutation, ICollection<List<T>> results, int nextPosition)
        {
            // See if all of the positions are filled.
            if (nextPosition == items.Count)
            {
                // All of the positioned are filled.
                // Save this permutation.
                results.Add(currentPermutation.ToList());
            }
            else
            {
                // Try options for the next position.
                for (var i = 0; i < items.Count; i++)
                {
                    if (!inSelection[i])
                    {
                        // Add this item to the current permutation.
                        inSelection[i] = true;
                        currentPermutation[nextPosition] = items[i];

                        // Recursively fill the remaining positions.
                        PermuteItems<T>(items, inSelection,
                            currentPermutation, results,
                            nextPosition + 1);

                        // Remove the item from the current permutation.
                        inSelection[i] = false;
                    }
                }
            }
        }
    }
}

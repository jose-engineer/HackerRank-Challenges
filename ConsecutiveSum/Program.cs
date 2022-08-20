using System;
using System.Collections.Generic;

namespace ConsecutiveSum {
    //Statement
    //Determine the starting index at which a sequence of consecutive numbers exists whose sum is equal to the target value, given
    //1. an array of numbers
    //2. a target value
    //Example:
    //For input ([0,1,5,5,1,1,2,1,8,6], 7) return 3: The sequence [5,1,1] has a sum of 7 at start index 3.
    //For input ([0,1,5,5,45,1,2,1,2,6], 7) return -1: There is no sequence whose sum is 7.
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(ConsecutiveSumExists(new List<int>() { 0, 1, 5, 5, 1, 1, 2, 1, 8, 6 }, 7)); // Expected: 3
            Console.WriteLine(ConsecutiveSumExists(new List<int>() { 0, 1, 5, 5, 45, 1, 2, 1, 2, 6 }, 7)); // Expected: -1
            Console.WriteLine(ConsecutiveSumExists(new List<int>() { 0, 1, 5, 5, 45, 1, 2, 5, 2, 6 }, 7)); // Expected: 6
            Console.WriteLine(ConsecutiveSumExists(new List<int>() { 6, 1, 5, 5, 45, 1, 2, 5, 2, 6 }, 7)); // Expected: 0
            Console.WriteLine(ConsecutiveSumExists(new List<int>() { 3, 1, 5, 1, 1, 1, 2, 6, 2, 6 }, 7)); // Expected: 1
        }

        public static int ConsecutiveSumExists(List<int> numsArr, int sumValue) {
            
            for (int i = 0; i < numsArr.Count; i++) {

                long sum = 0;
                for (int j = i; j < numsArr.Count; j++) {

                    sum += numsArr[j];
                    if (sum == sumValue) {
                        return i;
                    }

                }                
            }

            return -1;
        }
    }
}

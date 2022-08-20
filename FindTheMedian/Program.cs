using System;
using System.Collections.Generic;

namespace FindTheMedian {
    //The median of a list of numbers is essentially it's middle element after sorting. The same number of elements occur after it
    //as before. Given a list of numbers with an odd number of elements, find the median.
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(findMedian(new List<int> { 0, 1, 2, 4, 6, 5, 3 })); //Expected: 3
            Console.WriteLine(findMedian(new List<int> { 5, 3, 1, 2, 4 })); //Expected: 3
        }

        public static int findMedian(List<int> arr) {
            int[] arr2 = arr.ToArray();
            Array.Sort(arr2);

            int midIndex = arr2.Length / 2; // 7 / 2 = 3.5 returns 3 to variable midIndex
            //int midIndex = (arr2.Length - 1) / 2;

            return arr2[midIndex];
        }
    }
}

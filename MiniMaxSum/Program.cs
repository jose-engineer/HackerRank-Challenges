using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniMaxSum {
    //Given five positive integers, find the minimum and maximum values that can be calculated by summing exactly four of the five integers.
    //Then print the respective minimum and maximum values as a single line of two space-separated long integers.
    //arr= [1,3,5,7,9]
    //The minimum sum is 1 + 3 + 5 + 7 = 16 and the maximum sum is 3 + 5 + 7 + 9 = 24. The function prints 16 24
    class Program {
        static void Main(string[] args) {
            MiniMaxSum(new List<int> { 1, 3, 5, 7, 9 }); //Expected: 16 24
            MiniMaxSum(new List<int> { 1, 2, 3, 4, 5 } ); //Expected: 10 14
            MiniMaxSum(new List<int> { 7, 69, 2, 221, 8974 }); //Expected: 299 9271           
        }

        public static void MiniMaxSum(List<int> arr) {
            long max = arr[0];
            long min = arr[0];
            long total = arr[0];

            for (int i = 1; i < arr.Count; i++) {
                total += arr[i];

                if (arr[i] > max) {
                    max = arr[i];
                }
                if (arr[i] < min) {
                    min = arr[i];
                }
            }

            Console.WriteLine((total - max) + " " + (total - min));
        }        

        public static void MiniMaxSum2(List<int> arr) {
            int[] arr2 = arr.ToArray();
            Array.Sort(arr2);

            long max = 0;
            long min = 0;
            for (int i = 0; i < arr2.Length - 1; i++) {
                max += arr2[i + 1];
                min += arr2[i];
            }

            Console.WriteLine(min + " " + max);
        }

        public static void MiniMaxSum3(List<int> arr) {
            int[] arr2 = arr.ToArray();
            Array.Sort(arr2);

            long max = arr2.Skip(1).Sum(x => (long)x);
            long min = arr2.Take(4).Sum(x => (long)x);

            Console.WriteLine(min + " " + max);
        }

        public static void MiniMaxSum4(List<int> arr) {
            long max = arr[0];
            long min = arr[0];
            long total = 0;

            for (int i = 0; i < arr.Count; i++) {
                total += arr[i];
            }

            for (int i = 1; i < arr.Count; i++) {
                if (arr[i] > max) {
                    max = arr[i];
                }
                if (arr[i] < min) {
                    min = arr[i];
                }
            }

            Console.WriteLine((total - max) + " " + (total - min));
        }

    }
}

using System;

namespace MinimumSwaps
{
    class Program
    {
        //You are given an unordered array consisting of consecutive integers  [1, 2, 3, ..., n] without any duplicates.
        //You are allowed to swap any two elements. Find the minimum number of swaps required to sort the array in ascending order.
        //https://www.hackerrank.com/challenges/minimum-swaps-2/problem
        static void Main(string[] args)
        {            
            Console.WriteLine(minimumSwaps(new int[] { 7, 1, 3, 2, 4, 5, 6 })); // Expected: 5
            Console.WriteLine(minimumSwaps(new int[] { 4, 3, 1, 2 })); // Expected: 3
            Console.WriteLine(minimumSwaps(new int[] { 2, 3, 4, 1, 5 })); // Expected: 3
            Console.WriteLine(minimumSwaps(new int[] { 1, 3, 5, 2, 4, 6, 7 })); // Expected: 3
        }

        static int minimumSwaps(int[] arr) {    // 2 3 4 1 5
                                                // 1 2 3 4 5  
            int count = 0;                      // 0 1 2 3 4 
            for (int i = 0; i < arr.Length; i++) {
                while (arr[i] != i + 1) {
                    int index = arr[i] - 1; // 2 - 1 

                    int temp = arr[i];
                    arr[i] = arr[index];
                    arr[index] = temp;
                    //Swap(arr, i, index);

                    count++;
                }
            }

            return count;
        }

        static void Swap(int[] arr, int index1, int index2) {
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }

    }
}

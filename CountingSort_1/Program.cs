using System;
using System.Collections.Generic;
using System.Linq;

namespace CountingSort_1 {
    //Given a list of integers, count and return the number of times each value appears as an array of integers.
    //100 63 25 73 1 98 73 56 84 86 57 16 83 8 25 81 56 9 53 98 67 99 12 83 89 80 91 39 86 76 85 74 39 25 90 59 10 94 32 44 3 89 30 27 79 46 96 27 32 18 21 92 69 81 40 40 34 68 78 24 87 42 69 23 41 78 22 6 90 99 89 50 30 20 1 43 3 70 95 33 46 44 9 69 48 33 60 65 16 82 67 61 32 21 79 75 75 13 87 70 33
    //0 2 0 2 0 0 1 0 1 2 1 0 1 1 0 0 2 0 1 0 1 2 1 1 1 3 0 2 0 0 2 0 3 3 1 0 0 0 0 2 2 1 1 1 2 0 2 0 1 0 1 0 0 1 0 0 2 1 0 1 1 1 0 1 0 1 0 2 1 3 2 0 0 2 1 2 1 0 2 2 1 2 1 2 1 1 2 2 0 3 2 1 1 0 1 1 1 0 2 2 
    //Returns
    //int[100]: a frequency array

    class Program {
        static void Main(string[] args) {
            List<int> result = countingSort(new List<int> { 100, 63, 25, 73, 1, 98, 73, 56, 84, 86, 57, 16, 83, 8, 25, 81, 56, 9, 53, 98, 67, 99, 12, 83, 89, 80, 91, 39, 86, 76, 85, 74, 39, 25, 90, 59, 10, 94, 32, 44, 3, 89, 30, 27, 79, 46, 96, 27, 32, 18, 21, 92, 69, 81, 40, 40, 34, 68, 78, 24, 87, 42, 69, 23, 41, 78, 22, 6, 90, 99, 89, 50, 30, 20, 1, 43, 3, 70, 95, 33, 46, 44, 9, 69, 48, 33, 60, 65, 16, 82, 67, 61, 32, 21, 79, 75, 75, 13, 87, 70, 33 });
            foreach (var item in result) {
                Console.WriteLine(item);
            }            
        }

        public static List<int> countingSort(List<int> arr) {
            List<int> result = new List<int>();
            Dictionary<int, int> hash = new Dictionary<int, int>();

            for (int i = 0; i < arr.Count; i++) {

                if (!hash.ContainsKey(arr[i])) {
                    hash[arr[i]] = 1;
                } else {
                    hash[arr[i]] += 1;
                }

            }

            for (int i = 0; i < 100; i++) {

                int value = 0;
                if (hash.TryGetValue(i, out value)) {
                    result.Add(value);
                } else {
                    result.Add(0);
                }

            }
            return result;
        }

        public static List<int> countingSort2(List<int> arr) {
            List<int> arr2 = new List<int>(new int[100]);

            for (int i = 0; i < 100; i++) {
                arr2[i] = 0;
            }

            for (int i = 0; i < arr.Count; i++) {
                arr2[arr[i]] += 1;
            }

            return arr2;
        }

        public static List<int> countingSort3(List<int> arr) {            
            int[] arr2 = Enumerable.Repeat(0, arr.Count).ToArray();

            foreach (var item in arr) {
                arr2[item] += 1;
            }

            return arr2.Take(100).ToList();
            //return new List<int>(arr2.Take(100));
        }

    }
}

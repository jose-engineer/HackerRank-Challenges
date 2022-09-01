using System;
using System.Collections.Generic;

namespace Pairs {
    //    Given an array of integers and a target value, determine the number of pairs of array elements that have a difference equal to the
    //    target value.

    //Example
    //k=1
    //arr=[1,2,3,4]
    //There are three values that differ by k=1 : 2-1 = 1, 3-2 = 1, and 4-3 = 1. Return 3.

    //Function Description
    //Complete the pairs function below.
    //pairs has the following parameter(s):

    //int k: an integer, the target difference
    //int arr[n]: an array of integers

    //Returns
    //int: the number of pairs that satisfy the criterion

    //Sample Input
    //STDIN Function
    //-----       --------
    //5 2         arr[] size n = 5, k =2
    //1 5 3 4 2   arr = [1, 5, 3, 4, 2]

    //Sample Output
    //3

    //Explanation
    //There are 3 pairs of integers in the set with a difference of 2: [5,3], [4,2] and[3, 1]. .

//Constraints
//each integer arr[i] will be unique

    class Program {
        static void Main(string[] args) {
            
            Console.WriteLine(pairs(1, new List<int>() { 1, 2, 3, 4 })); //Expected: 3
            Console.WriteLine(pairs(2, new List<int>() { 1, 5, 3, 4, 2 })); //Expected: 3
            Console.WriteLine(pairs(1, new List<int>() { 363374326, 364147530, 61825163, 1073065718, 1281246024, 
                                                        1399469912, 428047635, 491595254, 879792181, 1069262793 })); //Expected: 0
            Console.WriteLine(pairs(2, new List<int>() { 1, 3, 5, 8, 6, 4, 2 })); //Expected: 5
        }

        public static int pairs(int k, List<int> arr) {
            HashSet<int> hSet = new HashSet<int>();
            int count = 0;

            arr.Sort();

            foreach (var item in arr) {
                int complement = item + k;

                if (hSet.Contains(item)) {
                    count++;
                    hSet.Add(complement);
                } else {
                    hSet.Add(complement);
                }

            }

            return count;
        }

        public static int pairs2(int k, List<int> arr) {
            Dictionary<int, string> hMap = new Dictionary<int, string>();
            int count = 0;

            arr.Sort();

            foreach (var item in arr) {
                int complement = item + k;

                if (hMap.ContainsKey(item)) {
                    count++;
                    hMap[complement] = "foo1";
                } else {
                    hMap[complement] = "foo2";
                }
            }

            return count;
        }

    }
}

using System;
using System.Collections.Generic;

namespace LonelyInteger {
    //Given an array of integers, where all elements but one ocurr twice, find the unique element
    //[1, 2, 3, 4, 3, 2, 1], the unique element is 4.
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(lonelyinteger(new List<int>() { 1, 1 })); //Expected: 1
            Console.WriteLine(lonelyinteger(new List<int>() { 1, 1, 2 })); //Expected: 2
            Console.WriteLine(lonelyinteger(new List<int>() { 0, 0, 1, 2, 1 })); //Expected: 2
            Console.WriteLine(lonelyinteger(new List<int>() { 1, 2, 3, 4, 3, 2, 1 })); //Expected: 4
        }

        public static int lonelyinteger(List<int> a) {
            Dictionary<int, int> hash = new Dictionary<int, int>();
            
            for (int i = 0; i < a.Count; i++) {

                if (hash.ContainsKey(a[i])) {
                    hash[a[i]] += 1;
                } else {
                    hash[a[i]] = 1;
                }

            }

            foreach (var item in hash) {
                if (item.Value == 1) {
                    return item.Key;
                }
            }

            return a.Count > 0 ? a[0] : 0;
            //return 0;
        }

        public static int lonelyinteger2(List<int> a) { //Using bit manipulation
            int result = 0;

            foreach (var item in a) {                                
                result ^= item; //XOR operator
                //result = result ^ item;
            }

            return result;
        }
    }
}

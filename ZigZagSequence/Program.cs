using System;

namespace ZigZagSequence {
    //Given an array of n distinct integers, transform the array into a zig zag sequence by permuting the array elements.
    //A sequence will be called a zig zag sequence if the first k elements in the sequence are in increasing order and
    //the last k elements are in decreasing order, where k = (n + 1)/2.
    //You need to find the lexicographically smallest zig zag sequence of the given array.
    //Example:
    //a = [2,3,5,1,4]
    //Now if we permute the array as [1,2,5,4,3], the result is a zig zag sequence.
    class Program {
        static void Main(string[] args) {
            findZigZagSequence(new int[] { 2, 3, 5, 1, 4 }, 5); //Expected 1 2 5 4 3
            findZigZagSequence(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 7); //1 2 3 7 6 5 4
            findZigZagSequence(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 11); //1 2 3 4 5 11 10 9 8 7 6
        }

        public static void findZigZagSequence(int[] a, int n) {
            Array.Sort(a); //1 2 3 4 5 6 7
            int mid = (n + 1) / 2 - 1;

            int temp = a[mid];
            a[mid] = a[n - 1];
            a[n - 1] = temp; //1 2 3 7 5 6 4

            int start = mid + 1;
            int end = n - 2; //You don't toch the last number (n - 1) because it will be the smaller one on the right side

            while (start <= end) {

                temp = a[start];
                a[start] = a[end];
                a[end] = temp;

                start += 1;
                end -= 1;

            }

            for (int i = 0; i < n; i++) {

                if (i > 0) 
                    Console.Write(" ");

                Console.Write(a[i]);                    
            }

            Console.WriteLine();
        }
    }
}

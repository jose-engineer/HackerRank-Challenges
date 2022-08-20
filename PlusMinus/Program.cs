using System;
using System.Collections.Generic;

namespace PlusMinus {
    class Program {
        //Given an array of integers, calculate the ratios of its elements that are positive, negative, and zero.
        //Print the decimal value of each fraction on a new line with  places after the decimal.
        static void Main(string[] args) {
            int[] A = { -4, 3, -9, 0, 4, 1 };
            List<int> A1 = new List<int>() { -4, 3, -9, 0, 4, 1 }; //posRatio = 3/6, negRatio = 2/6, zeroRatio = 1/6
            List<int> A2 = new List<int>() { 1, 2, 3, -1, -2, -3, 0, 0 };

            plusMinus(A1);
            Console.WriteLine();
            plusMinus(A2);
            Console.WriteLine();
        }

        public static void plusMinus(List<int> arr) {
            decimal positive = 0;
            decimal negative = 0;
            decimal zero = 0;

            for (int i = 0; i < arr.Count; i++) {
                if (arr[i] > 0) {
                    positive++;
                } else if (arr[i] < 0) {
                    negative++;
                } else {
                    zero++;
                }
            }

            decimal posRatio = positive / arr.Count;
            decimal negRatio = negative / arr.Count;
            decimal zeroRatio = zero / arr.Count;

            Console.WriteLine(posRatio.ToString("0.000000"));
            Console.WriteLine(negRatio.ToString("0.000000"));
            Console.WriteLine(zeroRatio.ToString("0.000000"));
        }
    }
}

using System;
using System.Collections.Generic;

namespace DiagonalDifference {
    //Given a square matrix, calculate the absolute difference between the sums of its diagonals. For example, the square matrix  is shown below:
    //1 2 3
    //4 5 6
    //9 8 9
    //The left-to-right diagonal = 1 + 5 + 9 = 15 The right to left diagonal = 3 + 5 + 9 = 17 Their absolute difference is |15 - 17| = 2
    //11 2  4
    //4  5  6
    //10 8 -12
    //The left-to-right diagonal = 11 + 5 -12 = 4 The right to left diagonal = 10 + 5 + 4 = 19 Their absolute difference is |4 - 19| = 15    
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(diagonalDifference(new List<List<int>> {  new List<int> { 1, 2, 3 }, 
                                                                        new List<int> { 4, 5, 6 }, 
                                                                        new List<int> { 9, 8, 9 } }));
            Console.WriteLine();
            Console.WriteLine(diagonalDifference(new List<List<int>> {  new List<int> { 11, 2, 4 }, 
                                                                        new List<int> { 4, 5, 6 }, 
                                                                        new List<int> { 10, 8, -12 } }));
        }

        public static int diagonalDifference(List<List<int>> arr) {
            int diag1 = 0;
            int diag2 = 0;
            int size = arr.Count - 1;

            for (int i = 0; i < arr.Count; i++) {
                diag1 += arr[i][i];
                diag2 += arr[size - i][i];
            }

            return Math.Abs(diag1 - diag2);
        }

        // int diag1 = arr[0][0] + arr[1][1] + arr[2][2];
        // int diag2 = arr[2][0] + arr[1][1] + arr[0][2];        

        // int diag1 = arr[0][0] + arr[1][1] + arr[2][2] + arr[3][3];
        // int diag2 = arr[3][0] + arr[2][1] + arr[1][2] + arr[0][3];
        public static int diagonalDifference2(List<List<int>> arr) {
            int diag1 = 0;
            for (int i = 0; i < arr.Count; i++) {
                diag1 += arr[i][i];
            }            

            int diag2 = 0;
            int size = arr.Count - 1;
            for (int i = 0; i < arr.Count; i++) {
                diag2 += arr[size - i][i];
            }            

            return Math.Abs(diag1 - diag2);
        }
    }
}

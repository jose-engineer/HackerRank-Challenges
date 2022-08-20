using System;
using System.Collections.Generic;

namespace FlippingTheMatrix {
    //Sean invented a game involving a 2n x 2n matrix where each cell of the matrix contains an integer.
    //He can reverse any of its rows or columns any number of times.
    //The goal of the game is to maximize the sum of the elements in the n x n submatrix located in the upper-left quadrant of the matrix.
    //Given the initial configurations for n matrices, help Sean reverse the rows and columns of each matrix in the best possible way
    //so that the sum of the elements in the matrix's upper-left quadrant is maximal.
    //Returns -> int: the maximum sum posiible.
    //Sample Input:
    //112 42  83  119   matrix = [[112, 42, 83, 119], [56, 125, 56, 49], [15, 78, 101, 43], [62, 98, 114, 108]]
    //56  125 56  49              
    //15  78  101 43
    //62  98  114 108
    //After reverse colum 2 and row 0, resulting matrix:
    //119 114 42  112   
    //56  125 101 49              
    //15  78  56  43
    //62  98  83  108
    //The sum of values in the n x n submatrix in the upper-left quadrant is 119 + 114 + 56 + 125 = 414.
    //https://www.hackerrank.com/challenges/flipping-the-matrix/problem
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(flippingMatrix(new List<List<int>> {  new List<int> { 112, 42, 83, 119 }, 
                                                                    new List<int> { 56, 125, 56, 49 }, 
                                                                    new List<int> { 15, 78, 101, 43 }, 
                                                                    new List<int> { 62, 98, 114, 108 } })); //Expected: 414
            Console.WriteLine();
            Console.WriteLine(flippingMatrix(new List<List<int>> {  new List<int> { 107, 54, 128, 15 }, 
                                                                    new List<int> { 12, 75, 110, 138 }, 
                                                                    new List<int> { 100, 96, 34, 85 }, 
                                                                    new List<int> { 75, 15, 28, 112 } })); //Expected: 488
        }

        public static int flippingMatrix(List<List<int>> matrix) {
            int n = matrix.Count / 2;
            int sum = 0;

            //Find the 4 swaps for each index in the n*n matrix and add the max
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {

                    int num1 = matrix[i][j];                        //i=0, j=0: m[0][0], i=0, j=1: m[0][1], i=1, j=0: m[1][0], i=1, j=1: m[1][1]
                    int num2 = matrix[i][2 * n - j - 1];            //i=0, j=0: m[0][3], i=0, j=1: m[0][2], i=1, j=0: m[1][3], i=1, j=1: m[1][2]
                    int num3 = matrix[2 * n - i - 1][j];            //i=0, j=0: m[3][0], i=0, j=1: m[3][1], i=1, j=0: m[2][0], i=1, j=1: m[2][1]
                    int num4 = matrix[2 * n - i - 1][2 * n - j - 1];//i=0, j=0: m[3][3], i=0, j=1: m[3][2], i=1, j=0: m[2][3], i=1, j=1: m[2][2]

                                                                                //First iteration with i=0, j=0
                    sum += Math.Max(num1, Math.Max(num2, Math.Max(num3, num4)));//Math.Max(112, Math.Max(119, Math.Max(62, 108))); => 119
                }
            }

            return sum;
        }
        //112 42  83  119
        //56  125 56  49              
        //15  78  101 43
        //62  98  114 108
        //
        //m[0][0] m[0][3] m[3][0] m[3][3]        
        //m[0][1] m[0][2] m[3][1] m[3][2]        
        //m[1][0] m[1][3] m[2][0] m[2][3]        
        //m[1][1] m[1][2] m[2][1] m[2][2]
        //
        //  112     119     62      108     => Max = 119
        //m[0][0] m[0][3] m[3][0] m[3][3]
        //  42      83      98      114     => Max = 114
        //m[0][1] m[0][2] m[3][1] m[3][2]
        //  56      49      15      43      => Max = 56
        //m[1][0] m[1][3] m[2][0] m[2][3]
        //  125     56      78      101     => Max = 125
        //m[1][1] m[1][2] m[2][1] m[2][2]                
    }
}

using System;

namespace MakeBinaryPalindrome {
    //You are given a binary string, s, consisting of characters '0' and '1'. Transform this string into a palindrome by performing some operations.
    //In one operation, swap any two characters, s[i] and s[j]. Determine the minimum number of swaps required to make the string a palindrome.
    //If it is impossible to do so, then return -1.

    //Note: A palindrome is a string that reads the same backward as forward, for example, strings "0", "111", "010", "10101" are palindromes, but
    //strings "001", "10", "11101" are not.

    //Example
    //Let string s="0100101". The following shows the minimum number of steps reuired. It uses 1-based indexing.
    // - Swap characters with indices (4,5). "010 01 01"
    // - Swap characters with indices (1,2). "01 01001"
    // - The binary is now palindromic. The answer is 2 swaps.

    //Sample Case 0
    //s = "101000"
    //Sample Output: 1
    //Explanation:
    //Swap characters at indices (3,6): "10 1 00 0" -> "10 0 00 1"

    //Sample Case 1
    //s = "1110"
    //Sample Output: -1
    //Explanation:
    //there is no way to make s a palindrome.

    class Program {
        static void Main(string[] args) {
            Console.WriteLine(minSwapsRequired("0100101")); //Expected: 2
            Console.WriteLine(minSwapsRequired("101000")); //Expected: 1
            Console.WriteLine(minSwapsRequired("1110")); //Expected: -1
            Console.WriteLine();
            Console.WriteLine(minSwapsRequired("111000")); //Expected: -1
            Console.WriteLine(minSwapsRequired("010")); //Expected: 0
            Console.WriteLine(minSwapsRequired("1110")); //Expected: -1            
            Console.WriteLine(minSwapsRequired("111000")); //Expected: -1
            Console.WriteLine(minSwapsRequired("100")); //Expected: 1
            Console.WriteLine(minSwapsRequired("1001")); //Expected: 0
            Console.WriteLine(minSwapsRequired("0100")); //Expected: -1
            Console.WriteLine(minSwapsRequired("01010")); //Expected: 0
            Console.WriteLine(minSwapsRequired("0010111")); //Expected: 1
            Console.WriteLine(minSwapsRequired("110000110")); //Expected: 1 -> 110000011
            Console.WriteLine(minSwapsRequired("0")); //Expected: 0 
            Console.WriteLine(minSwapsRequired("11100000001000010101001010100001010101010010000011101010000101111011000001111100010001110101111011000011000" +
                "0100110010101111010001111110000000010001111101111011111101111011101010011110101111111110110110010101011000001111011010010111100010" +
                "0000001100000")); //Expected: -1
        }

        //We can resolve two differences with one swap. This means that if we find an even number of differences (as we walk along the binary
        //string from the two ends inwards) there is a solution, and it takes half that number of swaps.
        //If the number of differences is odd, there is still a solution if the size of the input string is odd, because then that middle
        //digit can be swapped with a digit from that last difference, and so get a palindrome.
        //There is however no solution when the number of differences(in this algorithm) is odd and the number of digits in the input is even.
        public static int minSwapsRequired(string s) {
            int start = 0, end = s.Length - 1, count = 0;

            while (start < end) {
                if (s[start] != s[end]) {
                    count++;
                }

                start++;
                end--;
            }

            if (s.Length % 2 == 0 && count % 2 == 1) { //Differences odd and input size even
                return -1;
            } else if (s.Length % 2 == 1 && count % 2 == 1) { //Differences odd and input size odd
                return (count + 1) / 2;
            }

            return count / 2;
        }

        public static int minSwapsRequired2(string s) {
            int count = 0;

            for (int i = 0; i < s.Length / 2; i++) {
                if (s[i] != s[(s.Length - 1) - i]) {
                    count++;
                }
            }

            if (s.Length % 2 == 0 && count % 2 == 1) { //Differences odd and input size even
                return -1;
            } 

            return (count + 1) / 2;
        }

        public static int minSwapsRequired3(string s) {
            int count = 0;

            for (int i = 0, j = s.Length - 1; i < s.Length / 2; i++, j--) {
                if (s[i] != s[j]) {
                    count++;
                }
            }

            if (s.Length % 2 == 0 && count % 2 == 1) { //Differences odd and input size even
                return -1;
            }

            return (count + 1) / 2;
        }


    }
}

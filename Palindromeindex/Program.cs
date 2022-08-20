using System;

namespace PalindromeIndex {
    //Given a string of lowercase letters in the range ascii[a-z], determine the index of a character that can be removed to make
    //the string a palindrome. There may be more than one solution, but any will do. If the word is already a palindrome or there is
    //no solution, return -1. Otherwise, return the index of a character to remove.
    //Example 0
    //s = "bcbc"
    //Either remove 'b' at index 0 or 'c' at index 3.

    //Example 1
    //s = "aaab"
    //Removing 'b' at index 3 results in a palindrome, so return 3.

    //Example 2
    //s = "baa"
    //Removing 'b' at index 0 results in a palindrome, so return 0.

    //Example 3
    //s = "aaa"
    //This string is already a palindrome, so return -1. Removing any one of the characters would result in a palindrome, but this test comes first.
    //https://www.hackerrank.com/challenges/palindrome-index/problem
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(palindromeIndex("step on no pets")); //Exprected: -1
            Console.WriteLine(palindromeIndex("level")); //Exprected: -1
            Console.WriteLine(palindromeIndex("aaa")); //Exprected: -1            
            Console.WriteLine();
            Console.WriteLine(palindromeIndex("lyevel")); //Exprected: 1
            Console.WriteLine(palindromeIndex("leveyl")); //Exprected: 4
            Console.WriteLine(palindromeIndex("bcbc")); //Exprected: 0 or 3
            Console.WriteLine(palindromeIndex("aaab")); //Exprected: 3
            Console.WriteLine(palindromeIndex("baa")); //Exprected: 0           
        }

        public static int palindromeIndex(string s) {
            int left = 0;
            int right = s.Length - 1;

            while (left < right) {

                if (s[left] != s[right]) {

                    if (isPalindrome(s, left + 1, right)) {
                        return left;
                    } else {
                        return right;
                    }

                }

                left++;
                right--;
            }

            return -1;
        }
        public static int palindromeIndex2(string s) {

            for (int i = 0, j = s.Length - 1; i < s.Length / 2; i++, j--) {

                if (s[i] != s[j]) {

                    if (isPalindrome(s, i + 1, j)) {
                        return i;
                    } else {
                        return j;
                    }

                }

            }

            return -1;
        }

        public static bool isPalindrome(string s, int left, int right) {
            while (left < right) {
                if (s[left] != s[right]) {
                    return false;
                }

                left++;
                right--;
            }

            return true;
        }
    }
}

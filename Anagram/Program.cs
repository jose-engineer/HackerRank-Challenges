using System;
using System.Collections.Generic;

namespace Anagram {
    //Two words are anagrams of one another if their letters can be rearranged to form the other word. Given a string, split it into
    //two contiguous substrings of equal length. Determine the minimum number of characters to change to make the two substrings into
    //anagrams of one another.
    //Example:
    //s = abccde
    //Break s into two parts: 'abc' and 'cde'. Note that all letters have been used, the substrings are contiguous and their lengths
    //are equal. Now you can change 'a' and 'b' in the first substring to 'd' and 'e' to have 'dec' and 'cde' which are anagrams.
    //Two changes were necessary.
    //Returns:
    //int: the minimum number of characters to charge or -1
    //https://www.hackerrank.com/challenges/anagram/problem
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(anagram("abccde"));//Expected: 2
            Console.WriteLine(anagram("aaabbb"));//Expected: 3
            Console.WriteLine(anagram("ab"));//Expected: 1
            Console.WriteLine(anagram("abc"));//Expected: -1
            Console.WriteLine(anagram("mnop"));//Expected: 2
            Console.WriteLine(anagram("xyyx"));//Expected: 0
            Console.WriteLine(anagram("xaxbbbxx"));//Expected: 1
            Console.WriteLine();
            Console.WriteLine(anagram("asdfjoieufoa"));//Expected: 3
            Console.WriteLine(anagram("fdhlvosfpafhalll"));//Expected: 5
            Console.WriteLine(anagram("mvdalvkiopaufl"));//Expected: 5

        }

        public static int anagram(string s) {
            if (s.Length % 2 != 0) {
                return -1;
            }

            string str1 = s.Substring(0, s.Length / 2);
            string str2 = s.Substring(s.Length / 2);

            foreach (var item in str2) { //xaxb bbxx
                int index1 = str1.IndexOf(item);//when item = x, index1 = 0
                if (index1 > -1) {
                    str1 = str1.Remove(index1, 1); //Removes only 1 x starting from index1
                }
            }

            return str1.Length;
        }

        public static int anagram2(string s) {
            if(s.Length % 2 != 0) {
                return -1;
            }

            string str1 = s.Substring(0, s.Length / 2);
            string str2 = s.Substring(s.Length / 2);

            List<char> lst = new List<char>();

            foreach (var item in str1) {
                lst.Add(item);
            }

            foreach (var item in str2) {
                if (lst.Contains(item)) { //fdhlvosf pafhalll
                    lst.Remove(item);
                }
            }

            return lst.Count;                        
        }
        
    }
}

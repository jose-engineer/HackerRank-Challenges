using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BalancedStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            // The total count of "a" is equal to the count of "c"
            // The total count of "b" is equal to the count of "d"            

            Console.WriteLine("Is balanced: {0}", IsBalancedString("abcdabcd")); //Expected: True
            Console.WriteLine("Is balanced: {0}", IsBalancedString("cdba")); //Expected: True
            Console.WriteLine("Is balanced: {0}", IsBalancedString("aaccb")); //Expected: False
        }        

        public static bool IsBalancedString(string input) {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++) {
                if (input[i] == 'a' || input[i] == 'b') {
                    stack.Push(input[i]);
                }
            }

            for (int i = 0; i < input.Length; i++) {
                if (input[i] == 'c' || input[i] == 'd') {
                    if (stack.Count > 0) {
                        stack.Pop();
                    } else {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

        public static bool IsBalancedString2(string input)
        {
            //string patt1 = "(([bd]*[ac]){2})*[bd]*";
            //string patt2 = "(([ac]*[bd]){2})*[ac]*";

            //bool matches = Regex.IsMatch(input, patt1) && Regex.IsMatch(input, patt2);

            string pattern = "(?=^(([ac]*[bd]){2})*[ac]*$)(([bd]*[ac]){2})*[bd]*"; // Regex Look ahead Assertions
            bool matches = Regex.IsMatch(input, pattern);

            return matches;
        }        
    }
}

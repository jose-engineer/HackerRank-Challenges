using System;
using System.Collections.Generic;

namespace BalancedBrackets {
    //A bracket is considered to be any one of the following characters: (, ), {, }, [, or ]. Two brackets are considered to be
    //a matched pair if the an opening bracket(i.e., (, [, or {) occurs to the left of a closing bracket(i.e., ), ], or }) of the
    //exact same type. There are three types of matched pairs of brackets: [], {}, and(). A matching pair of brackets is not balanced
    //if the set of brackets it encloses are not matched. For example, {[(])} is not balanced because the contents in between { and }
    //are not balanced. The pair of square brackets encloses a single, unbalanced opening bracket, (, and the pair of parentheses
    //encloses a single, unbalanced closing square bracket, ].
    //By this logic, we say a sequence of brackets is balanced if the following conditions are met:
    //  - It contains no unmatched brackets.
    //  - The subset of brackets enclosed within the confines of a matched pair of brackets is also a matched pair of brackets.
    //
    //Given  strings of brackets, determine whether each sequence of brackets is balanced. If a string is balanced, return YES.
    //Otherwise, return NO.
    //https://www.hackerrank.com/challenges/balanced-brackets/problem
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(isBalanced("{[()]}"));
            Console.WriteLine(isBalanced("{{[[(())]]}}"));
            Console.WriteLine(isBalanced("{{([])}}"));
            Console.WriteLine(isBalanced("{(([])[])[]}"));
            Console.WriteLine(isBalanced("{(([])[])[]}[]"));            

            Console.WriteLine();

            Console.WriteLine(isBalanced("{[(])}"));
            Console.WriteLine(isBalanced("{{)[](}}"));
            Console.WriteLine(isBalanced("{(([])[])[]]}"));            

        }

        public static string isBalanced(string s) {
            if (s[0] == '}' || s[0] == ']' || s[0] == ')') {
                return "NO";
            }

            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> hashMap = new Dictionary<char, char>();

            hashMap.Add('{', '}');   //{[()]}
            hashMap.Add('[', ']');   //{(([])[])[]}
            hashMap.Add('(', ')');   //{[(])}                                

            for (int i = 0; i < s.Length; i++) {
                if (s[i] == '{' || s[i] == '[' || s[i] == '(') {
                    stack.Push(s[i]);
                } else if (s[i] == '}' || s[i] == ']' || s[i] == ')') {

                    if (stack.Count > 0) {

                        char current = stack.Peek();

                        if (s[i] == hashMap[current]) {
                            stack.Pop();
                        } else {
                            return "NO";
                        }

                    } else {
                        return "NO";
                    }

                }
            }

            return stack.Count == 0 ? "YES" : "NO";
        }

    }
}

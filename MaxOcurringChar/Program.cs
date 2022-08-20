using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxOcurringChar
{
    class Program
    {
        //Given a string, return the character that appears the maximum number of times in the string. The string will contain only
        //ASCII characters, from the ranges ('a'-'z', 'A'-'Z', '0'-'9'), and case matters. if there is a tie in the maximum number
        //of times a character appears in the string, return the character that appears first in the string.
        //Example:
        //text = "abbbaacc"
        //Both 'a' and 'b' occur 3 times in text. Since 'a' occurs earlier, 'a' is the answer
        //Example 0:
        //text = "helloworld"
        //Output: l

        static void Main(string[] args)
        {            
            Console.WriteLine(maximumOcurringCharacter("abbbaacc")); // Expected: a
            Console.WriteLine(maximumOcurringCharacter("helloworld")); // Expected: l
            //Console.WriteLine(maximumOcurringCharacter(string.Empty));
        }

        public static char maximumOcurringCharacter(string text) {

            Dictionary<char, int> hashMap = new Dictionary<char, int>();

            foreach (var item in text) {
                if (hashMap.ContainsKey(item)) {
                    hashMap[item]++; // hashMap[item] += 1;                                                            
                } else {
                    hashMap[item] = 1; // hashMap.Add(item, 1);
                }
            }            

            int max = hashMap.Max(x => x.Value);

            foreach (var item in hashMap) {
                if (item.Value == max) {
                    return item.Key;
                }
            }

            return ' ';
        }        

        public static char MaximumOcurring2(string text) {
            return text.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
        }

        public static char maximumOcurringCharacter3(string text) {
            
            Dictionary<char, int> hashMap = new Dictionary<char, int>();

            int max = 0;
            foreach (var item in text) {
                if (hashMap.ContainsKey(item)) {

                    hashMap[item]++;

                    if (hashMap[item] > max) {
                        max = hashMap[item];
                    }

                } else {
                    hashMap[item] = 1;
                }
            }            

            foreach (var item in hashMap) {
                if (item.Value == max) {
                    return item.Key;
                }
            }

            return ' ';
        }

        public static char maximumOcurringCharacter4(string text) {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int max = 0;
            char result = ' ';

            foreach (var item in text) {
                int count = 0;
                dict.TryGetValue(item, out count);
                count++;

                if (count > max) {
                    max = count;
                }
                dict[item] = count;
            }

            foreach (var item in dict) {
                if (item.Value == max) {
                    return item.Key;
                }
            }
            return result;
        }        

        //public static char MaximumOcurringCharacter(string input)
        //{
        //    int mostOccurrence = -1;
        //    char mostOccurringChar = ' ';
        //    foreach (char currentChar in input)
        //    {
        //        int foundCharOccreence = 0;
        //        foreach (char charToBeMatch in input)
        //        {
        //            if (currentChar == charToBeMatch)
        //                foundCharOccreence++;
        //        }
        //        if (mostOccurrence < foundCharOccreence)
        //        {
        //            mostOccurrence = foundCharOccreence;
        //            mostOccurringChar = currentChar;
        //        }
        //    }
        //    return mostOccurringChar;
        //}        

        //public static char MaximumOcurringCharacter(string input)
        //{
        //    char result = ' ';
        //    var res = input.GroupBy(p => p).Select(p => new { Count = p.Count(), Char = p.Key }).GroupBy(p => p.Count, p => p.Char).OrderByDescending(p => p.Key).First();

        //    foreach (var r in res)
        //    {
        //        result = r;
        //    }
        //    return result;
        //}

    }

}

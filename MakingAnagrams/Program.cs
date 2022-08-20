using System;

namespace MakingAnagrams {
    //We consider two strings to be anagrams of each other if the first string's letters can be rearranged to form the second string.
    //In other words, both strings must contain the same exact letters in the same exact frequency. For example, bacdc and dcbac are
    //anagrams, but bacdc and dcbad are not.
    //Alice is taking a cryptography class and finding anagrams to be very useful. She decides on an encryption scheme involving two
    //large strings where encryption is dependent on the minimum number of character deletions required to make the two strings
    //anagrams.Can you help her find this number?
    //Given two strings, s1 and s2, that may not be of the same length, determine the minimum number of character deletions required
    //to make s1 and s2 anagrams. Any characters can be deleted from either of the strings.
    //Example:
    // s1 = abc
    // s2 = amnop
    //The only characters that match are the a's so we have to remove bc from s1 and mnop from s2 for a total of 6 deletions.
    //Returns:
    //int: the minimum number of deletions needed
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(makingAnagrams("abc", "amnop")); //Expected: 6
            Console.WriteLine(makingAnagrams("cde", "abc")); //Expected: 4
            Console.WriteLine(makingAnagrams("absdjkvuahdakejfnfauhdsaavasdlkj", 
                "djfladfhiawasdkjvalskufhafablsdkashlahdfa")); //Expected: 19          
        }

        public static int makingAnagrams(string s1, string s2) { // cde abc            

            foreach (var item in s1) {

                int index2 = s2.IndexOf(item);
                if (index2 >= 0) {
                    s2 = s2.Remove(index2, 1);

                    int index1 = s1.IndexOf(item);
                    if (index1 >= 0) {
                        s1 = s1.Remove(index1, 1);
                    }
                }
            }

            return s1.Length + s2.Length;
        }

        public static int makingAnagrams2(string s1, string s2) //cde abc
        {
            int count = 0;
            int[] s1_freq = new int[26]; // [a, b, c, d, e]
            int[] s2_freq = new int[26]; // [0, 1, 2, 3, 4]

            for (int i = 0; i < s1.Length; i++) {
                char current = s1[i]; // c => index = 2           
                int index = (int)current - (int)'a'; // 2 = 99'c' - 97'a'
                s1_freq[index]++; // s1_freq[2] = 1 => Aumenta en 1 el valor en la psicion 3 s1_freq[2]++
            }

            for (int i = 0; i < s2.Length; i++) {
                char current = s2[i];
                int index = (int)current - (int)'a';
                s2_freq[index]++;
            }

            for (int i = 0; i < 26; i++) {
                int difference = Math.Abs(s1_freq[i] - s2_freq[i]);
                count += difference;
            }

            return count;
        }
    }
}

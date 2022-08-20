using System;
using System.Collections.Generic;
using System.Linq;

namespace GridChallenge {
    //Given a square grid of characters in the range ascii[a-z], rearrange elements of each row alphabetically, ascending.
    //Determine if the columns are also in ascending alphabetical order, top to bottom. Return YES if they are or NO if they are not.
    //Example
    //grid = ['abc','ade','efg']
    //The rows are already in alphabetical order. The columns a a e, b d f and c e g are also in alphabetical order,
    //so the answer would be YES. Only elements within the same row can be rearranged. They cannot be moved to a different row.
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(gridChallenge(new List<string>() { "abc", "abc", "abc" })); //Expected: YES
            Console.WriteLine(gridChallenge(new List<string>() { "ebacd", "fghij", "olmkn", "trpqs", "xywuv" })); //Expected: YES
            Console.WriteLine(gridChallenge(new List<string>() { "abc", "lmp", "qrt" })); //Expected: YES            
            Console.WriteLine(gridChallenge(new List<string>() { "abc", "hjk", "rtv" })); //Expected: YES
            Console.WriteLine(gridChallenge(new List<string>() { "mpxz", "abcd", "wlmf" })); //Expected: NO
        }

        public static string gridChallenge(List<string> grid) {
            List<string> sorted = new List<string>();

            foreach (var item in grid) {
                                                    //var row = item.ToList();
                var row = item.OrderBy(x => x);     //row.Sort();
                sorted.Add(string.Join("", row));   

            }

            for (int i = 1; i < sorted.Count; i++) {
                for (int j = 0; j < sorted[i - 1].Length; j++) {
                    if (sorted[i - 1].ToCharArray()[j] > sorted[i].ToCharArray()[j]) {
                        return "NO";
                    }
                }
            }

            return "YES";
        }
    }
}

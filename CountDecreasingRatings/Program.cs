using System;
using System.Collections.Generic;

namespace CountDecreasingRatings {
    //Amazon Shopping recently launched a new item whose daily customer ratings for n days are represented by the array ratings.
    //They monitor these ratings to identify products that are not performing well. Find the number of groups that can be formed
    //consisting of 1 or more consecutive days such that the ratings continuously decrease over the days.

    //The ratings are consecutively decreasing if it has the form: r,r-1,r-2.. and so on, where r is the rating on the first days
    //of the group being considered.Two groups are considered different if they contain the ratings of different consecutive days.

    //Example
    //ratings = [4, 3, 5, 4, 3]
    //There are 9 periods in which the rating consecutively decreases.
    //5 one day periods: [4], [3], [5], [4], [3]
    //3 two day periods: [4,3], [5,4], [4,3]
    //1 one day periods: [5,4,3]

    //Returns
    //long: the number of valid groups of ratings

    //Sample Case 0
    //ratings = [2, 1, 3]
    //Output: 4
    //Explanation:
    //There are 4 groups of continuosly decreasing ratings: [2], [1], [3], [2,1]

    //Sample Case 1
    //ratings = [4, 2, 3, 1]
    //Output: 4
    //Explanation:
    //The groups [4], [2], [3], [1] are the only groups that qualify.
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(countDecreasingRatings(new List<int> { 4, 3, 5, 4, 3 })); ////Expected: 9
            Console.WriteLine(countDecreasingRatings(new List<int> { 2, 1, 3 })); //Expected: 4
            Console.WriteLine(countDecreasingRatings(new List<int> { 4, 2, 3, 1 })); //Expected: 4
            Console.WriteLine();
            Console.WriteLine(countDecreasingRatings(new List<int> { 2, 1, 3, 4, 1, 2, 1, 5, 4 })); //Expected: 12
            Console.WriteLine(countDecreasingRatings(new List<int> { 5, 4, 1, 7, 8 })); //Expected: 6
            Console.WriteLine(countDecreasingRatings(new List<int> { 5 })); //Expected: 1
            Console.WriteLine();
            Console.WriteLine(countDecreasingRatings(new List<int> { 3, 2, 1, 3, 4, 1, 2, 1, 5, 4 })); //Expected: 15
            Console.WriteLine(countDecreasingRatings(new List<int> { 3, 2, 1, 3, 4, 1, 2, 1, 5, 4, 3 })); //Expected: 18
            Console.WriteLine(countDecreasingRatings(new List<int> { 4, 3, 5, 4, 3, 2 })); //Expected: 6 + 1 + 3 + 3 = 13
                                                                                           //[4], [3], [5], [4], [3], [2] = 6
                                                                                           //[4,3]  = 1
                                                                                           //[5,4], [4,3], [3,2]   = 3
                                                                                           //[5,4,3,2],[5,4,3],[4,3,2]    = 3
        }

        public static long countDecreasingRatings(List<int> ratings) { // 4, 3, 5, 4, 3, 2
            if (ratings.Count == 0) {
                return 0;
            }

            int start = 0, group = 0;

            for (int i = 1; i < ratings.Count; i++) {
                // 0, 1, 2  3  4  5 - indexes
                if ((ratings[i - 1] - ratings[i]) == 1) { //       5, 4, 3, 2
                    group += i - start; //endIndex - startIndex => 3-2 => 4-2 => 5-2 => 1+2+3 = 6
                } else {                //[5,4], [4,3], [3,2]   = 3
                    start = i;          //[5,4,3,2],[5,4,3],[4,3,2]    = 3
                }                       //3 + 3 = 6

            }

            return group + ratings.Count;
        }

        public static long countDecreasingRatings2(List<int> ratings) {

            int groups = 0, start = 0, end = 1;

            while (end < ratings.Count) {
                if (ratings[end - 1] - ratings[end] == 1) {
                    groups += end - start;
                } else {
                    start = end;
                }

                end++;
            }

            return groups + ratings.Count;
        }

        public static long countDecreasingRatings3(List<int> ratings) {

            long mload = 0;
            long result = 0;

            for (int i = 0; i < ratings.Count; i++) {
                if (mload == 0) {
                    mload = 1;
                } else {
                    if (ratings[i - 1] == ratings[i] + 1) {
                        mload++;
                    } else {
                        result += sumOfNNumbers(mload);
                        mload = 1;
                    }
                }
            }
            result += sumOfNNumbers(mload);
            return result;
        }

        private static long sumOfNNumbers(long m) {
            if (m % 2 == 0) {
                return ((m / 2) * (m + 1));
            } else {
                return m * ((m + 1)) / 2;
            }
        }

        public static long countDecreasingRatings4(List<int> ratings) {

            long consec = 0;
            long group = 0;

            for (int i = 1; i < ratings.Count; i++) {
                int prev = ratings[i] + 1;

                if (ratings[i - 1] == prev) {
                    consec++;
                }
            }

            if (consec == 0) {
                return ratings.Count;
            }

            int count = 0;
            for (int i = 1; i < ratings.Count; i++) {

                int prev = ratings[i] + 1;
                if (ratings[i - 1] == prev) {
                    count++;
                    if (count > 1) {
                        group++;
                    }
                    continue;
                } else if (ratings[i - 1] != prev) {
                    count = 0;
                    continue;
                }

            }

            return ratings.Count + consec + group;
        }
    }
}

using System;
using System.Collections.Generic;

namespace NewYearChaos {
    //It is New Year's Day and people are in line for the Wonderland rollercoaster ride. Each person wears a sticker indicating
    //their initial position in the queue from 1 to n. Any person can bribe the person directly in front of them to swap positions,
    //but they still wear their original sticker. One person can bribe at most two others.
    //Determine the minimum number of bribes that took place to get to a given queue order. Print the number of bribes, or,
    //if anyone has bribed more than two people, print Too chaotic.
    //Example:
    // q = [1,2,3,5,4,6,7,8]
    //If person 5 bribes person 4, the queue will look like this: 1,2,3,5,4,6,7,8. Only 1 bribe is required. Print 1.
    // q = [4,1,2,3]
    //Person 4 had to bribe 3 people to get to the current position. Print Too chaotic
    //Returns:
    //No value is returned. Print the minimum number of bribes necessary or Too chaotic if someone has bribed more than 2 people.
    //https://www.hackerrank.com/challenges/new-year-chaos/problem
    class Program {
        static void Main(string[] args) {
            minimumBribes(new List<int>() { 1, 2, 3, 5, 4, 6, 7, 8 });  //Expected: 1
            minimumBribes(new List<int>() { 4, 1, 2, 3 });              //Expected: Too chaotic
            minimumBribes(new List<int>() { 2, 1, 5, 3, 4 });           //Expected: 3
            minimumBribes(new List<int>() { 2, 5, 1, 3, 4 });           //Expected: Too chaotic
            minimumBribes(new List<int>() { 5, 1, 2, 3, 7, 8, 6, 4 });  //Expected: Too chaotic
            minimumBribes(new List<int>() { 1, 2, 5, 3, 7, 8, 6, 4 });  //Expected: 7
            minimumBribes(new List<int>() { 1, 2, 5, 3, 4, 7, 8, 6 });  //Expected: 4
        }

        public static void minimumBribes(List<int> q) {
            int count = 0;

            for (int i = q.Count-1; i >= 0; i--) {    //[1 2 5 3 7 8 6 4]
                                                        // 0 1 2 3 4 5 6 7            
                if (q[i] != i+1) { // 4 != 7 + 1 
                    if (q[i-1] == i+1) {
                        int temp = q[i-1];
                        q[i-1] = q[i];//[1 2 5 3 4 4 6 6]
                        q[i] = temp;    //[1 2 5 3 4 6 6 6]
                        //Swap(q, i-1, i);
                        count += 1;
                    } else if (q[i-2] == i+1) {
                        q[i-2] = q[i-1]; //8 = 6  [1 2 5 3 7 6 6 4]   [1 2 5 3 6 6 4 6]     [1 2 3 3 4 6 6 6]   
                        q[i-1] = q[i]; //6 = 4      [1 2 5 3 7 6 4 4]   [1 2 5 3 6 4 4 6]     [1 2 3 4 4 6 6 6]
                        q[i] = q[i-2]; //4 = 6      [1 2 5 3 7 6 4 6]   [1 2 5 3 6 4 6 6]     [1 2 3 4 3 6 6 6]
                        //Swap(q, i-1, i);
                        //Swap(q, i-2, i);
                        count += 2;
                    } else {
                        Console.WriteLine("Too chaotic");
                        return;
                    }
                }
            }
            Console.WriteLine(count);
        }

        public static void minimumBribes2(List<int> q) {
            int swaps = 0;          //[1 2 5 3 7 8 6 4] - arr
            bool chaotic = false;   // 0 1 2 3 4 5 6 7 - indexes

            for (int i = q.Count - 1; i >= 0; i--) {
                int moves = q[i] - 1 - i; //pattern, example when q[5]: 8-1-5 = 2

                if (moves == 1) {
                    Swap(q, i, i + 1);

                    swaps += 1;
                    i += 1;
                } else if (moves == 2) {
                    Swap(q, i, i + 2);
                    Swap(q, i, i + 1);

                    swaps += 2;
                    i += 2;
                } else if (moves > 2) {
                    chaotic = true;
                    break;
                }
            }

            if (chaotic) {
                Console.WriteLine("Too chaotic");
            } else {
                Console.WriteLine(swaps);
            }
        }

        public static void Swap(List<int> lst, int index1, int index2) {
            int temp = lst[index1];
            lst[index1] = lst[index2];
            lst[index2] = temp;
        }        
    }
}

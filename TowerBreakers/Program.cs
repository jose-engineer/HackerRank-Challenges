using System;

namespace TowerBreakers {
    //https://www.hackerrank.com/challenges/tower-breakers-1/problem
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(towerBreakers(2, 2));//Expected: 2
            Console.WriteLine(towerBreakers(1, 4));//Expected: 1
            Console.WriteLine(towerBreakers(1, 7));//Expected: 1
            Console.WriteLine(towerBreakers(3, 7));//Expected: 1
        }

        public static int towerBreakers(int n, int m) {//n=number of towers, m=height, 
            //If the towers start out at 1 or there are an even number of towers, player 2 will win; else, player 1 wins.
            if (m == 1) {
                return 2;
            } else if (n % 2 == 0) {
                return 2;
            } else {
                return 1;
            }
        }

        public static int towerBreakers2(int n, int m) {
            return (m == 1 || n % 2 == 0 ? 2 : 1);
        }
    }
}

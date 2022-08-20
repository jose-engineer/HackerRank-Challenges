using System;
using System.Text;

namespace RecursiveDigitSum {
    //For example, the super digit of 9875 will be calculated as:
    //super_digit(9875)   	9+8+7+5 = 29 
    //super_digit(29)       2 + 9 = 11
    //super_digit(11)       1 + 1 = 2
    //super_digit(2)        = 2
    //n = 9875
    //k = 4
    //The number p is created by concatenating the string n k times so the initial p = .
    //superDigit(p) = superDigit(9875987598759875)
    //              9+8+7+5+9+8+7+5+9+8+7+5+9+8+7+5 = 116
    //superDigit(p) = superDigit(116)
    //              1+1+6 = 8
    //superDigit(p) = superDigit(8)
    //All of the digits of p sum to 116. The digits of 116 sum to 8. 8 is only one digit, so it is the super digit.
    //Returns:
    //int: the super digit of n repeated k times
    //https://www.hackerrank.com/challenges/recursive-digit-sum/problem
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(superDigit("9875", 4)); //Expected: 8
            Console.WriteLine(superDigit("148", 3)); //Expected: 3
            Console.WriteLine(superDigit("123", 3)); //Expected: 9            
        }

        public static int superDigit(string n, int k) {     
            
            int s = k * oneDigit(n); //s = 8 = 4 * 2, so for larger numbers we will pass n as it is so you can get super_digit(2)
                                     //and then multiply by k to get 8, in this way we avoid time out
            return oneDigit(s.ToString());

        }

        public static int superDigit2(string n, int k) {
            StringBuilder number = new StringBuilder();
            for (int i = 0; i < k % 9; i++) { //modulus 9 means below 10, means one digit
                number.Append(n);
            }

            long result = oneDigit(number.ToString());
            return int.Parse(result.ToString());
        }

        public static int oneDigit(string n) {
            int sum = 0;

            if (n.Length == 1) { //base case, if n is one digit break the recursion
                return Convert.ToInt32(n.ToString());
            }

            for (int i = 0; i < n.Length; i++) {
                sum += Convert.ToInt32(n[i].ToString());
            }

            return oneDigit(sum.ToString());
        }
        
    }
}

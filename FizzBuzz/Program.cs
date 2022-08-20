using System;

namespace FizzBuzz {
    class Program {
        //Given a number n, for each integer i in the range from 1 to n inclusive, print one value per line as follows:
        //If is a multiple of both 3 and 5, print FizzBuzz
        //If is a multiple of 3(but not 5), print Fizz
        //If is a multiple of 5(but not 3), print Buzz
        //If is not a multiple of 3 or 5, print the value of i
        static void Main(string[] args) {
            fizzBuzz(15);
        }

        public static void fizzBuzz(int n) {            

            for (int i = 1; i <= n; i++) {
                if ((i % 3 == 0) && (i % 5 == 0)) {
                    Console.WriteLine("FizzBuzz");
                } else if (i % 3 == 0) {
                    Console.WriteLine("Fizz");
                } else if (i % 5 == 0) {
                    Console.WriteLine("Buzz");
                } else {
                    Console.WriteLine(i.ToString());
                }
            }

        }
    }
}

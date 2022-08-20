using System;
using System.Collections.Generic;

namespace QueueUsingTwoStacks {
    //https://www.hackerrank.com/challenges/queue-using-two-stacks/problem

    class Program {
        static void Main(string[] args) {

            int queries = int.Parse(Console.ReadLine());
            Stack<int> input = new Stack<int>();
            Stack<int> output = new Stack<int>();

            while (queries > 0) {
                string[] splits = Console.ReadLine().Split(' ');
                int type = int.Parse(splits[0]);
                //int value = int.Parse(splits[1]);

                if (type == 1) {
                    input.Push(int.Parse(splits[1]));
                } else if (type == 2) {
                    if (output.Count == 0) {
                        shiftStacks(input, output);
                    }
                    output.Pop();
                } else if (type == 3) {
                    if (output.Count == 0) {
                        shiftStacks(input, output);
                    }
                    Console.WriteLine(output.Peek());
                }

                queries--;
            }

        }

        public static void shiftStacks(Stack<int> input, Stack<int> output) {
            while (input.Count != 0) {
                output.Push(input.Peek()); //output.Push(input.Pop());                
                input.Pop();
            }
        }
    }
}

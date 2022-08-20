using System;
using System.Collections.Generic;

namespace QueueUsingTwoStacks {
    class Program {
        static void Main(string[] args) {
            var numberOfQueries = int.Parse(Console.ReadLine());
            var stack1 = new Stack<int>();
            var stack2 = new Stack<int>();
            var queueFrontStack1 = false;

            for (int i = 0; i < numberOfQueries; i++) {
                var inputSplits = Console.ReadLine().Split(' ');
                var queryType = int.Parse(inputSplits[0]);
                switch (queryType) {
                    case 1:
                        if (stack1.Count == 0 && stack2.Count == 0) {
                            stack1.Push(int.Parse(inputSplits[1]));
                            queueFrontStack1 = true;
                        } else
                            stack2.Push(int.Parse(inputSplits[1]));

                        break;
                    case 2:
                        if (queueFrontStack1 == true) {
                            stack1.Pop();
                            if (stack2.Count != 0 && stack1.Count == 0)
                                queueFrontStack1 = false;
                        } else {
                            if (stack2.Count > 0) {
                                while (stack2.Count > 1)
                                    stack1.Push(stack2.Pop());

                                stack2.Pop();
                                queueFrontStack1 = true;
                            }

                        }
                        break;
                    case 3:
                        if (queueFrontStack1 == true)
                            Console.WriteLine(stack1.Peek());
                        else {
                            if (stack2.Count > 0) {
                                while (stack2.Count > 0)
                                    stack1.Push(stack2.Pop());

                                queueFrontStack1 = true;
                                Console.WriteLine(stack1.Peek());
                            }

                        }
                        break;
                }
            }
        }

        static void Main2(string[] args) {
            int inp = Convert.ToInt32(Console.ReadLine());

            Stack<int> front = new Stack<int>();
            Stack<int> rear = new Stack<int>();
            for (int i = 1; i <= inp; i++) {


                string q = Console.ReadLine();
                string[] n = q.Split(' ');
                int x = Convert.ToInt32(n[0]);
                int y = 0;
                if (n.Length > 1) {
                    y = Convert.ToInt32(n[1]);
                }
                if (x == 1) {

                    rear.Push(y);
                } else {

                    if (front.Count == 0) {
                        while (rear.Count > 0) {
                            front.Push(rear.Peek());
                            rear.Pop();
                        }
                        if (x == 2) {

                            front.Pop();
                        } else if (x == 3) {
                            Console.WriteLine(front.Peek());
                        }
                    } else {
                        if (x == 2) {

                            front.Pop();
                        } else if (x == 3) {
                            Console.WriteLine(front.Peek());
                        }

                    }

                }
            }
        }
    }
}

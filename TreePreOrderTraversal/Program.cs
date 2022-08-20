using System;
using System.Collections.Generic;

namespace TreePreOrderTraversal {
//Complete the preOrder function in the editor below, which has 1 parameter: a pointer to the root of a binary tree. It must print the values
//in the tree's preorder traversal as a single line of space-separated values.

//Input Format
//Our test code passes the root node of a binary tree to the preOrder function.

//Output Format
//Print the tree's preorder traversal as a single line of space-separated values.

    class Program {
        class Node {
            public Node left { get; set; }
            public Node right { get; set; }
            public int data { get; set; }

        }        

        static void Main(string[] args) {
            //     1
            //        2
            //          5
            //       3     6
            //         4

            //Create a small binary tree, it is not a binary search tree because it does not meet the ordering constraint
            Node rootNode = new Node();
            rootNode.data = 1;

            Node NodeTwo = new Node();
            NodeTwo.data = 2;

            Node NodeFive = new Node();
            NodeFive.data = 5;

            Node NodeThree = new Node();
            NodeThree.data = 3;

            Node NodeSix = new Node();
            NodeSix.data = 6;

            Node NodeFour = new Node();
            NodeFour.data = 4;
            
            rootNode.right = NodeTwo;
            NodeTwo.right = NodeFive;
            NodeFive.left = NodeThree;
            NodeFive.right = NodeSix;
            NodeThree.right = NodeFour;

            BinaryTree.preOrder(rootNode); //Expected: 1 2 5 3 4 6 
            Console.WriteLine();
            BinaryTree.preOrder2(rootNode); //Expected: 1 2 5 3 4 6 
            Console.WriteLine();

        }

        class BinaryTree //This class wil hold the traversal, it will display the data from our tree
        {
            //Pre-Order: Root -> Left -> Right
            //In-Order: Left -> Root -> Right
            //Post-Order: Left -> Right -> Root  
            public static void preOrder(Node root) {
                if (root == null) {
                    return;
                }

                Console.Write(root.data + " ");
                preOrder(root.left);
                preOrder(root.right);
            }

            public static void preOrder2(Node root) {
                if (root == null) {
                    return;
                }                

                Stack<Node> stack = new Stack<Node>();
                stack.Push(root);

                while (stack.Count > 0) {
                    Node current = stack.Pop();
                    Console.Write(current.data + " ");

                    if (current.right != null) {
                        stack.Push(current.right);
                    }

                    if (current.left != null) {
                        stack.Push(current.left);
                    }
                }
            }

        }
    }
}

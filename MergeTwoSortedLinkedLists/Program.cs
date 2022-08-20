using System;

namespace MergeTwoSortedLinkedLists {
    //Given pointers to the heads of two sorted linked lists, merge them into a single, sorted linked list.Either head pointer may be null meaning
    //that the corresponding list is empty.

    //Example
    //headA refers to 1 -> 3 -> 7 -> NULL
    //headB refers to 1 -> 2 -> NULL

    //The new list is 1 -> 1 -> 2 -> 3 -> 7 -> NULL

    //Function Description:
    //Complete the mergeLists function in the editor below.
    //mergeLists has the following parameters:

    // -SinglyLinkedListNode pointer headA: a reference to the head of a list
    // -SinglyLinkedListNode pointer headB: a reference to the head of a list

    //Returns:
    //SinglyLinkedListNode pointer: a reference to the head of the merged list
    //Input Format

    //The first line contains an integer t, the number of test cases.

    //The format for each test case is as follows:

    //The first line contains an integer n, the length of the first linked list.
    //The next lines contain an integer each, the elements of the linked list.
    //The next line contains an integer m, the length of the second linked list.
    //The next  lines contain an integer each, the elements of the second linked list.

    //Sample Input
    //1
    //3
    //1
    //2
    //3
    //2
    //3
    //4

    //Sample Output
    //1 2 3 3 4 

    //Explanation
    //The first linked list is: 1 -> 2 -> 3 -> NULL
    //The second linked list is: 3 -> 4 -> NULL

    //Hence, the merged linked list is: 1 -> 2 -> 3 -> 3 -> 4 -> NULL
    class CustomLinkedList {
        SinglyLinkedListNode head;

        public class SinglyLinkedListNode {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int d) {
                data = d;
            }
        }
        
        public void DisplayContents() {
            SinglyLinkedListNode current = head;

            while (current != null) {
                Console.Write(current.data + "->");
                current = current.next;
            }
        }

        class Program {
            static void Main(string[] args) {
                CustomLinkedList linkedList = new CustomLinkedList();

                SinglyLinkedListNode firstNode = new SinglyLinkedListNode(1);
                SinglyLinkedListNode secondNode = new SinglyLinkedListNode(2);
                SinglyLinkedListNode thirdNode = new SinglyLinkedListNode(3);
                //SinglyLinkedListNode fourthNode = new SinglyLinkedListNode(3);
                //SinglyLinkedListNode fifthNode = new SinglyLinkedListNode(11);

                linkedList.head = firstNode;
                firstNode.next = secondNode;
                secondNode.next = thirdNode;
                //thirdNode.next = fourthNode;
                //fourthNode.next = fifthNode;

                CustomLinkedList linkedList2 = new CustomLinkedList();

                SinglyLinkedListNode firstNode2 = new SinglyLinkedListNode(3);
                SinglyLinkedListNode secondNode2 = new SinglyLinkedListNode(4);
                //SinglyLinkedListNode thirdNode2 = new SinglyLinkedListNode(10);
                //SinglyLinkedListNode fourthNode2 = new SinglyLinkedListNode(3);
                //SinglyLinkedListNode fifthNode2 = new SinglyLinkedListNode(11);

                linkedList2.head = firstNode2;
                firstNode2.next = secondNode2;
                //secondNode2.next = thirdNode2;
                //thirdNode2.next = fourthNode2;
                //fourthNode2.next = fifthNode2;

                linkedList.DisplayContents();
                Console.WriteLine();
                linkedList2.DisplayContents();
                linkedList.mergeLists(firstNode, firstNode2); //Expeceted: 1,2,3,3,4
                Console.WriteLine();
                Console.WriteLine();
                linkedList.DisplayContents();                
                Console.WriteLine();
            }
        }

        public SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2) {

        if(head1 == null){
            return head2;
        }
        
        if(head2 == null){
            return head1;
        }
        
        SinglyLinkedListNode head3 = null;
        
        if(head1.data < head2.data)            {
            head3 = head1;
            head1 = head1.next;
        }else{
            head3 = head2;
            head2 = head2.next;
        }
        
        SinglyLinkedListNode current = head3;
        
        while(head1 != null && head2 != null){
            if(head1.data < head2.data){
                current.next = head1;
                head1 = head1.next;
            }else{
                current.next = head2;
                head2 = head2.next;
            }
            
            current = current.next;
        }
        
        if(head1 == null){
            current.next = head2;
        }else{
            current.next = head1;
        }
        
        return head3;
        }

    }
}

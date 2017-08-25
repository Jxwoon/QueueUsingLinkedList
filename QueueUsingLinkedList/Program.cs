using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUsingLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue q = new Queue();

            q.enqueue(5);
            q.enqueue(4);
            q.enqueue(3);
            q.enqueue(2);
            q.enqueue(1);


            q.Print();

            q.dequeue();
            q.Print();

            q.dequeue();
            q.Print();
            q.dequeue();
            q.Print();

            q.enqueue(8);
            q.Print();

        }
    }
    public class Node
    {
        private Node next;
        private int data;
        private Node prev;
        public Node(int data, Node next)
        {
            this.data = data;
            this.next = next;
        }

        public int Data
        {
            get { return this.data; }

        }
        public Node Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

        public Node Prev
        {
            get { return this.prev; }
            set { this.prev = value; }
        }
    }

    public class Linkedlist
    {
        public Node head;
        public Node tail;
        public int count;

        public Linkedlist()
        {
            head = null;
            count = 0;

        }

        public Linkedlist(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Add(count, a[i]);

            }
            Add(4);
            Remove(2);
            Add(1, 4);
        }

        public bool Add(int index, int data)
        {
            if (index < 0 || index > count)
            {
                if (index < 0)
                {
                    Console.WriteLine("Error: You cannot add values with a negative index");

                }
                else
                {
                    Console.WriteLine("Error: You cannot add values with an index that excceeds the length of the linked list");
                }
                Console.ReadLine();
                return false;

            }
            Node current = this.head;


            // assumes that the first reference is empty
            if (current == null)
            {
                this.head = new Node(data, this.head);
                tail = head;

            }
            // Adds value to the beginning of the linked list if the head is already filled
            else if (index == 0 && head != null)
            {
                Node temp = new Node(data, head);
                temp.Next = head;
                head.Prev = temp;
                temp.Prev = null;
                head = temp;
            }


            // adding reference in the midle 
            else
            {
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                Node newLink = new Node(data, current.Next);
                //Sets the nodes to the middle of the linked list
                if (index != count)
                {
                    current.Next = newLink;
                    newLink.Prev = current;
                    newLink.Next = current.Next.Next;
                    Node temp = current.Next.Next;
                    temp.Prev = newLink;
                    current.Next.Next = temp;
                }
                // Sets the nodes to the end of the linkedlist
                else
                {
                    Node temp = new Node(data, tail);
                    tail.Next = temp;
                    temp.Next = null;
                    temp.Prev = tail;
                    tail = temp;
                }
            }

            count++;
            return true;
        }


        // Adds a value to the end of the LinkedList
        public void Add(int data)
        {
            Add(count, data);

        }

        public int Remove(int index)
        {
            Node current = head;
            int result;

            if (isEmpty())
            {
                Console.WriteLine("Error: You cannot remove values in an empty linked list");
                Console.ReadLine();
                return -1;
            }
            if (index < 0 || index > count)
            {
                if (index < 0)
                {
                    Console.WriteLine("Error: You cannot remove values with a negative index");

                }
                else
                {
                    Console.WriteLine("Error: You cannot remove values with an index that excceeds the length of the linked list");
                }
                Console.ReadLine();
                return -1;
            }

            // removing the first reference
            if (index == 0)
            {
                result = current.Data;
                head = current.Next;
                Node temp = current.Next;
                temp.Prev = null;
                current.Next = temp;

            }
            else
            {
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                result = current.Next.Data;
                current.Next = current.Next.Next;



                if (current.Next != null)
                {
                    Node temp = current.Next;
                    temp.Prev = current;
                }

            }
            count--;

            return result;
        }

        public bool isEmpty()
        {
            if (head == null)
            {
                return true;
            }
            return false;
        }
        /*
        public int deleteLast()
        {
            int results = tail.Data;
            Node temp = tail.Prev;
            temp.Next = null;
            tail = temp;

            count--;
            return results;
        }
        */

        public void Print()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.Data + " ");
                temp = temp.Next;
            }
            Console.WriteLine();
        }


    }


    public class Queue
    {

        public Linkedlist queue;
        Node head;
        Node tail;

        public Queue()
        {
            queue = new Linkedlist();
        }


        public void enqueue(int v)
        {
            /*
            Node temp = new Node(v, null);
            if (isEmpty())
            {
                head = temp;
                tail = temp;
            }
            else
            {
                temp = head;
                head = new Node(v, this.head);
                head.Next = temp;

            }
            */

            queue.Add(0, v);

        }
        public int dequeue()
        {
            /*
             * While tail does not equal to null
             * tail is equal to the previous node
             * Thus, prev's node will be set to null
             * 
             *    Node last = head;
              Node prev = null;
              while (last.next != null)
              {
                  prev = last;
                  last = last.next;
             */
            /*
           Node temp = head;
           while(temp.Next.Next != null)
           {

               temp = temp.Next;


           }
           tail = temp;
           int result = temp.Next.Data;
           tail.Next = null;

           return result;
           */
            return queue.Remove(queue.count - 1);
        }

        public bool isEmpty()
        {
            if (head == null)
            {
                return true;
            }
            return false;
        }

        public void Print()
        {
            /*
            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.Data + " ");
                temp = temp.Next;
            }
            Console.WriteLine();
            */

            queue.Print();
        }








    }
}

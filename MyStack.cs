using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures.Stack
{
    public class MyStack<T>
    {
        
        Node<T> stack;

        public void Push(T value)
        {
            Node<T> node = new Node<T>(value);
            node.Next = stack;
            stack = node;
        }

        public void Pop()
        {
            if (stack == null)
            {
                Console.WriteLine("There is no shit to poop");
                return;
            }
            else
            {
                Node<T> node = stack.Next;
                stack = node;
            }
        }

        public void Print()
        {
            if(stack == null)
            {
                Console.WriteLine("Brother, the stack, its empty");
            }

            Node<T> current = stack;
            while (current != null)
            {
                Console.Write(current.Val + " <-");
                current = current.Next;
            }
            Console.WriteLine("Stack ended");
        }

        public void Peek()
        {
            if(stack == null)
            {
                Console.WriteLine("I cant look at nothing");
            }
            Console.WriteLine("The stackmost element is " + stack.Val);
        }


    }

    //Singly linked list node
    public class Node<T>
    {
        public T Val;
        public Node<T> Next;

        public Node(T value)
        {
            this.Val = value;
            Next = null;
        }
    }
}

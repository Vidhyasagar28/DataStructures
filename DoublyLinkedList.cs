using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures.LinkedLists
{
    public class DoublyLinkedList<T>
    {
        DoublyNode<T> head;
        DoublyNode<T> tail;

        public void Add(T Value)
        {
            DoublyNode<T> node = new DoublyNode<T>(Value);
            if (head == null)
                head = node;

            else
            {
                DoublyNode<T> current = head;
                while (current.Next != null)
                    current = current.Next;

                current.Next = node;
                node.Previous = current;
            }

            tail = node;
        }

        public void Remove(T val)
        {
            if(head == null)
            {
                Console.WriteLine("Dude, the first one is that");
                return;
            }
            DoublyNode<T> current = head;
            while(current != null && !current.Value.Equals(val))
            {
                current = current.Next;
            }

            if(current == null)
            {
                Console.WriteLine("Not found anywhere");
                return;
            }
            else
            {
                current.Previous.Next = current.Next;
                current.Next.Previous = current.Previous;
            }
        }

        public void Print()
        {
            DoublyNode<T> current = head;
            if(head == null)
            {
                Console.WriteLine("Nothing to print");
                return;
            }
            else
            {
                while(current != null)
                {
                    if (current.Next != null)
                        Console.Write(current.Value + " <-> ");
                    else
                        Console.WriteLine(current.Value);
                    current = current.Next;
                }
            }

        }

        public void ReversePrint()
        {
            DoublyNode<T> current = tail;
            if (head == null)
            {
                Console.WriteLine("Nothing to print");
                return;
            }
            else
            {
                while (current != null)
                {
                    if (current.Previous != null)
                        Console.Write(current.Value + " <-> ");
                    else
                        Console.WriteLine(current.Value);
                    current = current.Previous;
                }
            }

        }


    }

    public class DoublyNode<T>
    {
        public T Value;
        public DoublyNode<T> Next;
        public DoublyNode<T> Previous;

        public DoublyNode(T Value) { 
            this.Value = Value;
            Next = null;
            Previous = null;
        }
    }
}

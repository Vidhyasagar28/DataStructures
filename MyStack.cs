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

        public T Pop()
        {
            if (stack == null)
            {
                throw new Exception("There is no shit to poop");
            }
            else
            {
                Node<T> node = stack.Next;
                stack = node;
                return node.Val;
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

        public T Peek()
        {
            if (stack == null)
            {
                throw new Exception("I cant look at nothing");
            }
            return stack.Val;
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

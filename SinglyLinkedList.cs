
namespace Data_Structures.LinkedLists
{
    public class MyLinkedList<T>
    {
        private Node<T> head;

        public void Add(T value){
            Node<T> node = new Node<T>(value);
            if(head == null){
                head = node;
                Console.WriteLine("Added head");
                return;
            }
            Node<T> current = head;
            while(current.Next != null)
            {
                current = current.Next;

            }
            current.Next = node;
            Console.WriteLine("next value set");
        }

        public void Remove(T value)
        {
            if (head == null) return;
            if (head.Val.Equals(value))
            {
                head = head.Next;
                Console.WriteLine("Removed head");
                return;
            }
            Node<T> current = head;
            while(current.Next != null && !current.Next.Val.Equals(value))
            {
                current = current.Next;
            }
            if(current.Next != null)
            {
                current.Next = current.Next.Next;
                Console.WriteLine("Removed at a non head spot");
            }
            else
            {
                Console.WriteLine("No value da");
            }
        }

        public void Print()
        {
            if (head == null)
            {
                Console.WriteLine("No Data stepbro");
                return ;
            }
            else
            {
                Node<T> current = head;
                Console.Write("[ ");
                while(current.Next != null)
                {
                    Console.Write(current.Val+" ,");
                    current = current.Next;
                }
                    Console.WriteLine(" "+ current.Val + " ]");
                    Console.WriteLine("End of list");
            }
        }
    }

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

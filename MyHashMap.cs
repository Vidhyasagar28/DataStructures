using System.Security.Cryptography.X509Certificates;

namespace Data_Structures.HashMap
{
    public class MyHashMap<K, V>
    {
        MyLinkedLists<K,V>[] bucket;

        public MyHashMap()
        {
            bucket = new MyLinkedLists<K,V>[10];
        }
        public void Put(K key, V value)
        {
            int index = GetHash(key);
            bucket[index] = new MyLinkedLists<K,V>();
            bucket[index].Insert(key, value);
        }
        public V Get(K key)
        {
            int index = GetHash(key);
            if (bucket[index] != null)
                return bucket[index].Get(key);
            return default;
        }
        public void Remove(K key)
        {
            int index = GetHash(key);
            if (bucket[index] != null)
                bucket[index].Remove(key);
            else
            {
                Console.WriteLine("Ahh nope, no such key");
            }
        }
        private int GetHash(K key)
        {
            int keyy = key.GetHashCode();
            return keyy % 10;
        }
        public void Print()
        {
            for(int i = 0; i<bucket.Length; i++)
            {
                if(bucket[i] != null)
                {
                    Console.Write("-> ");
                    bucket[i].Print();
                    Console.WriteLine();
                }
            }
        }
    }

    public class MyLinkedLists<K, V>
    {
        Node<K, V>? head;

        public void Insert(K key, V value)
        {
            Node<K,V> node = new Node<K,V>(key,value);
            if (head == null) head = node;
            else
            {
                Node<K,V> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = node;
            }       
        }
        public V Get(K key) 
        { 
            Node<K,V> current = GetNode(key);
            return current.Value;        
        }
        Node<K,V> GetNode(K key)
        {
            Node<K, V> current = head;
            while (current != null)
            {
                if (current.key.Equals(key))
                    return current;
                current = current.Next;
            }
            return default;
        }

        public void Print()
        {
            Node<K, V> current = head;
            while (current != null)
            {
                if (current.Next != null)
                    Console.Write(" [ " + current.key + " , " + current.Value + " ] ->");
                else
                    Console.Write(" [ " + current.key + " , " + current.Value + " ]");

                current = current.Next;
            }
        }
        public void Remove(K key)
        {
            Node<K, V> current = GetNode(key);
            current = current.Next;
        }     
    }
    public class Node<K, V>
    {
        public K key;
        public V Value;
        public Node<K, V> Next;
        public Node(K key, V value)
        {
            this.key = key;
            this.Value = value;
            Next = null;
        }
    }

}

namespace Data_Structures.Queue
{
    public class MyQueue<T> 
    {
        T?[] arr;
        int front;
        int back;

        int count;
        int capacity;

        public MyQueue(){
            arr = new T?[5];
            front = 0;
            back = 0;
            count = 0;
            capacity = 5;
        }
        public void Enqueue(T value)
        {
            if (IsFull())
            {
                ResizeArray();
            }

            arr[back] = value;
            back = (back + 1) % capacity;
            count++;
        }
        public void Dequeue()
        {
            if (IsEmpty())
                throw new Exception("Nothing to remove");
            else
            {
                arr[front] = default;
                front = (front + 1) % capacity;
                count--;
            }   
        }
        public bool IsEmpty() =>  count == 0 ? true : false;
        public bool IsFull() => count == capacity ? true : false;
        private void ResizeArray()
        {
            int capacity = arr.Length * 2;
            T?[] newArr = new T?[capacity];

            int c = 0;
            if (front > back)
            {
                for(int i = front, j=0; j<this.capacity - front; i++,j++)
                {
                    newArr[j] = arr[i];
                    c++;
                }
                for(int i = 0; i < back; i++)
                {
                    newArr[c] = arr[i];
                    c++;
                }

            }
            else
            {
                for(int i = 0; i<count; i++)
                {
                    newArr[i] = arr[i];
                    c++;
                }
            }

            this.back = c;
            this.front = 0;
            this.count = c;
            this.capacity = capacity;
            arr = newArr;

        }
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Dude queue is like ur head");
            }
            return arr[front];
        }
        public void Print()
        {
            if (IsEmpty())
            {
                throw new Exception("Dude queue is like ur head");
            }

            if(front <= back)
            {
                for(int i = front; i < back; i++) 
                { 
                    Console.Write(arr[i] + " < ");
                }
            }

            else
            {
                for (int i = front; i < this.capacity; i++)
                {
                    Console.Write(arr[i] + " < ");
                }
                for (int i = 0; i < back; i++)
                {
                    Console.Write(arr[i] + " < ");
                }
            }     
        }
    }
}

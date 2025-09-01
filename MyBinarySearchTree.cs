namespace Data_Structures.Tree
{
    public class MyBinarySearchTree<T> where T : IComparable<T>
    {
        TreeNode<T> root;
        #region Insert
        public void Insert(T value)
        {
            if (root == null)
            {
                root = new TreeNode<T>(value);
            }
            else
            {
                InsertRecursive(root, value);
            }
        }
        void InsertRecursive(TreeNode<T> node, T value)
        {
            if (node.data.CompareTo(value) > 0)
            {
                if (node.left != null)
                {
                    this.InsertRecursive(node.left, value);
                }
                else
                {
                    node.left = new TreeNode<T>(value);
                }
            }
            else if (node.data.CompareTo(value) < 0)
            {
                if (node.right != null)
                {
                    this.InsertRecursive(node.right, value);
                }
                else
                {
                    node.right = new TreeNode<T>(value);
                }
            }
            else
            {
                Console.WriteLine("Data " + value + " already exists, increasing the count");
                node.counter++;
            }

        }
        #endregion

        #region Delete
        public void Remove(T value)
        {
            bool isRemoved = false;
            root =  RemoveRecursive(root, value, ref isRemoved);   
            if(!isRemoved)
                Console.WriteLine("The data, "+value+" is not found. Ill use my dim wit to commit suicide. Very thanks stepBro...");
        }
        TreeNode<T> RemoveRecursive(TreeNode<T> node, T value, ref bool isRemoved)
        {
            if(node == null)
            {
                return null;
            }

            if (node.data.CompareTo(value) > 0)
            {
                node.left = RemoveRecursive(node.left, value, ref isRemoved);
            }
            else if (node.data.CompareTo(value) < 0)
            {
                node.right = RemoveRecursive(node.right, value, ref isRemoved);
            }
            else if(node.data.CompareTo(value) == 0)
            {
                isRemoved = true;
                if (node.counter > 1)
                {
                    Console.WriteLine("The value "+value+", has "+node.counter+" times, and now removed once");
                    node.counter--;
                    return node;
                }

                if (node.left == null && node.right == null)
                {
                    return null;
                }
                else if (node.left == null )
                {
                    node = node.right;
                    return node;
                }
                else if (node.right == null)
                {
                    node = node.left;
                    return node;
                }
                else
                {
                    //two child part
                    node.data = MinNode(node.right).data;
                    node.right = RemoveRecursive(node, node.data, ref isRemoved);
                    return node;

                }
            }
            return node; 
        }
        #endregion

        #region Resources
        TreeNode<T> MinNode(TreeNode<T> node)
        {
            if(node.left == null)
                return node;
            
            else
                return MinNode(node.left);   
        }

        TreeNode<T> MaxNode(TreeNode<T> node)
        {
            if(node.right == null)
                return node;
            else
                return MaxNode(node.right);
        }

        TreeNode<T> GetNode(TreeNode<T> node, T value)
        {
            if(node.data.CompareTo(value) == 0)
                return node;

            if (node.data.CompareTo(value) < 0)
                return node.right != null ? GetNode(node.right, value) : null;
            else
                return node.left != null ? GetNode(node.left, value) : null;
        }

        #endregion 

        #region Print
        public void Print()
        {
            PrintInOrderRecursive(root);
            Console.WriteLine();
        }
        void PrintInOrderRecursive(TreeNode<T> node)
        {
            TreeNode<T> current = node;

            if (current.left != null)
            {
                PrintInOrderRecursive(node.left);
            }

            if (node.counter > 1)
            {
                Console.Write(current.data + " (" + node.counter + "times), ");
            }
            else
            {
                Console.Write(current.data + ", ");
            }

            if (current.right != null)
            {
                PrintInOrderRecursive(node.right);
            }
        }
        #endregion
    }

    public class TreeNode<T> 
    {
        public T data;
        public int counter;
        public TreeNode<T> left;
        public TreeNode<T> right;

        public TreeNode(T value)
        {
            data = value;
            counter = 1;
            left = null;
            right = null;
        }            
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures.Graph
{
    public class GraphNode<T> 
    {

        public T value;
        public int index;
        public bool isVisited = false;

        public List<GraphNode<T>> neighbours = new List<GraphNode<T>> ();

        public GraphNode(T value, int index)
        {
            this.value = value;
            this.index = index;
        }
    }

    public class MyGraph<T> where T : IComparable<T>
    {
        List<GraphNode<T>> graphList = new List<GraphNode<T>>();
        public MyGraph(List<GraphNode<T>> graph)
        {
            graphList = graph;
        }
        public void AddUnDirectedEdge(int i, int j)
        {
            GraphNode<T> first = graphList[i];
            GraphNode<T> second = graphList[j];

            first.neighbours.Add(second);
            second.neighbours.Add(first);
        }
        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0;i<graphList.Count; i++)
            {
                sb.Append(graphList[i].value + ":  ");
                for(int j = 0; j <= graphList[i].neighbours.Count - 1; j++)
                {
                    if (graphList[i].neighbours.Count - 1 == j)
                        sb.Append(graphList[i].neighbours[j].value);
                    else
                        sb.Append(graphList[i].neighbours[j].value  + "-> ");                    
                }
                sb.Append('\n');
            }

            return sb.ToString();
        }
        void BFSVisit(GraphNode<T> node)
        {
            Queue<GraphNode<T>> queue = new Queue<GraphNode<T>>();
            queue.Enqueue(node);
            while(!(queue.Count == 0))
            {
                GraphNode<T> current = queue.Dequeue();
                current.isVisited = true;
                Console.Write("["+current.value + " , "+ current.index+"]  ");
                foreach (GraphNode<T> neigbhorNode in current.neighbours) {
                    if (!neigbhorNode.isVisited)
                    {
                        queue.Enqueue(neigbhorNode);
                        neigbhorNode.isVisited = true;
                    }     
                }
            }
        }
        void DFSVisit(GraphNode<T> node)
        {
            Stack<GraphNode<T>> stack = new Stack<GraphNode<T>>();
            stack.Push(node);
            while (!(stack.Count == 0))
            {
                GraphNode<T> current = stack.Pop();
                current.isVisited = true;
                Console.Write("[" + current.value + " , " + current.index + "]  ");
                foreach (GraphNode<T> neigbhorNode in current.neighbours)
                {
                    if (!neigbhorNode.isVisited)
                    {
                        stack.Push(neigbhorNode);
                        neigbhorNode.isVisited = true;
                    }
                }
            }
        }
        public void BFS()
        {
            foreach (GraphNode<T> node in graphList)
                if(!node.isVisited)
                    BFSVisit(node);
            ResetVisits();
        }
        public void DFS()
        {
            foreach(GraphNode<T> node in graphList)
                if(!node.isVisited)
                    DFSVisit(node);
            ResetVisits();
        }
        void ResetVisits()
        {
            foreach (GraphNode<T> node in graphList)
                node.isVisited = false;
        }
    }


}

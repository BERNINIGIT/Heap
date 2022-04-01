using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public abstract class BinaryHeap
    {
        private readonly List<int> nodes;
        private readonly Func<int, int, bool> compare;
        public int Count { get { return nodes.Count; } }
        public BinaryHeap(Func<int, int, bool> compare)
        {
            this.nodes = new List<int>();
            this.compare = compare;
        }
        protected int? PeekFirst()
        {
            if (nodes.Count == 0)
                return null;
            return nodes[0];
        }
        public void Insert(int node)
        {
            nodes.Add(node);
            if (nodes.Count == 1)
                return;
            int nodeindex = nodes.Count - 1;
            int parentIndex = (nodeindex - 1) / 2;
            while (parentIndex >= 0 && compare(nodes[parentIndex], node))
            {
                Swap(parentIndex, nodeindex);
                nodeindex = parentIndex;
                parentIndex = (nodeindex - 1) / 2;
            }
        }
        protected int? GetFirst()
        {
            if (nodes.Count == 0)
                return null;

            int first = nodes[0];

            if (nodes.Count == 1)
            {
                nodes.RemoveAt(nodes.Count - 1);
                return first;
            }
                
            int end = nodes[nodes.Count - 1];
            nodes.RemoveAt(nodes.Count - 1);
            nodes[0] = end;
            int parentIndex = 0;
            int leftChildIndex = 2 * parentIndex + 1;
            int rightChildIndex = 2 * parentIndex + 2;
            while(
                (leftChildIndex < nodes.Count && compare(nodes[parentIndex], nodes[leftChildIndex])) ||
                (rightChildIndex < nodes.Count && compare(nodes[parentIndex], nodes[rightChildIndex]))
                )
            {
                if (compare(nodes[parentIndex], nodes[leftChildIndex]) && 
                    (rightChildIndex < nodes.Count && compare(nodes[parentIndex], nodes[rightChildIndex])))
                {
                    if(compare(nodes[rightChildIndex], nodes[leftChildIndex]))
                    {
                        Swap(parentIndex, leftChildIndex);
                        parentIndex = leftChildIndex;                        
                    }
                    else
                    {
                        Swap(parentIndex, rightChildIndex);
                        parentIndex = rightChildIndex;
                    }
                    leftChildIndex = 2 * parentIndex + 1;
                    rightChildIndex = 2 * parentIndex + 2;
                    continue;
                }
                if (compare(nodes[parentIndex], nodes[leftChildIndex]))
                {
                    Swap(parentIndex, leftChildIndex);
                    parentIndex = leftChildIndex;
                    leftChildIndex = 2 * parentIndex + 1;
                    rightChildIndex = 2 * parentIndex + 2;
                    continue;
                }
                if (compare(nodes[parentIndex], nodes[rightChildIndex]))
                {
                    Swap(parentIndex, rightChildIndex);
                    parentIndex = rightChildIndex;
                    leftChildIndex = 2 * parentIndex + 1;
                    rightChildIndex = 2 * parentIndex + 2;
                    continue;
                }
            }
            return first;
        }
        private void Swap(int i, int j)
        {
            int aux = nodes[i];
            nodes[i] = nodes[j];
            nodes[j] = aux;
        }
    }
}

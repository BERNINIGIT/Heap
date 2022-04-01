using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class MaxBinaryHeap
    {
        private List<int> nodes;
        public MaxBinaryHeap(List<int> nodes)
        {
            this.nodes = nodes;

        }
        public void Insert(int node)
        {
            nodes.Add(node);
            if (nodes.Count == 1)
                return;
            int nodeindex = nodes.Count - 1;
            int parentIndex = (nodeindex - 1) / 2;
            while (parentIndex >= 0 && node > nodes[parentIndex])
            {
                Swap(parentIndex, nodeindex);
                nodeindex = parentIndex;
                parentIndex = (nodeindex - 1) / 2;
            }
        }
        public int? GetMax()
        {
            if (nodes.Count == 0)
                return null;
            int max = nodes[0];
            int end = nodes[nodes.Count - 1];
            nodes.Insert(end, nodes[nodes.Count - 1]);
            nodes.RemoveAt(nodes.Count - 1);

        }
        private void Swap(int i, int j)
        {
            int aux = nodes[i];
            nodes[i] = nodes[j];
            nodes[j] = aux;
        }
    }
}

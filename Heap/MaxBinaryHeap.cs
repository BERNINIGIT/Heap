using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class MaxBinaryHeap : BinaryHeap
    {
        public MaxBinaryHeap() : base((a, b) => a < b)
        {
            
        }
        public int? GetMax()
        {
            return base.GetFirst();
        }
        public int? Peekmax()
        {
            return base.PeekFirst();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class MinBinaryHeap : BinaryHeap
    {
        public MinBinaryHeap() : base((a, b) => a > b)
        {

        }
        public int? GetMin()
        {
            return base.GetFirst();
        }
        public int? PeekMin()
        {
            return base.PeekFirst();
        }
    }
}

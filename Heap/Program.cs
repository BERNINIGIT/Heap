using System;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            MinBinaryHeap heap = new();
            heap.Insert(4);
            heap.Insert(4);
            heap.Insert(8);
            heap.Insert(4);
            heap.Insert(5);
            heap.Insert(3);
            heap.Insert(1);
            heap.Insert(10);
            heap.Insert(1);
            heap.Insert(3);
            heap.Insert(8);
            heap.Insert(178);
            heap.Insert(2);
            heap.Insert(177);
            heap.Insert(179);
            int? max = 0;
            while(max.HasValue)
            {
                max = heap.GetMin();
                Console.WriteLine(max);
            }
        }
    }
}

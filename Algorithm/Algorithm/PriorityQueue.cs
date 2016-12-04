using System;
using System.Collections.Generic;

namespace Algorithm
{
    class PriorityQueue
    {
        Node[] heap;

        public int Count { get; private set; }
        private PriorityQueue() { }
        public PriorityQueue(int capacity)
        {
            this.heap = new Node[capacity];
        }

        public void Push(Node v)
        {
            if (Count >= heap.Length) Array.Resize(ref heap, Count * 2);
            heap[Count] = v;
            SiftUp(Count++);
        }

        public Node Pop()
        {
            Node v = Top();
            heap[0] = heap[--Count];
            if (Count > 0) SiftDown(0);
            return v;
        }

        public Node Top()
        {
            if (Count > 0) return heap[0];
            throw new InvalidOperationException("优先队列为空");
        }

        void SiftUp(int n)
        {
            Node v = heap[n];
            for (int n2 = n / 2; n > 0 && v.Compare(v, heap[n2]) > 0; n = n2, n2 /= 2) heap[n] = heap[n2];
            heap[n] = v;
        }

        void SiftDown(int n)
        {
            Node v = heap[n];
            for (int n2 = n * 2; n2 < Count; n = n2, n2 *= 2)
            {
                if (n2 + 1 < Count && v.Compare(heap[n2 + 1], heap[n2]) > 0) n2++;
                if (v.Compare(v, heap[n2]) >= 0) break;
                heap[n] = heap[n2];
            }
            heap[n] = v;
        }
    }
}

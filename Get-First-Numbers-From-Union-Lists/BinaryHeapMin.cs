using System.Collections.Generic;
using System.Linq;

namespace Get_First_Numbers_From_Union_Lists
{
    public class BinaryHeapMin
    {
        private List<int> list = new List<int>();
        public int Limit { get; set; }

        private int HeapSize => list.Count;

        public void Add(int value)
        {
            list.Add(value);
            var i = HeapSize - 1;
            var parent = (i - 1) / 2;

            while (i > 0 && list[parent] > list[i])
            {
                var temp = list[i];
                list[i] = list[parent];
                list[parent] = temp;
                i = parent;
                parent = (i - 1) / 2;
            }
        }
        
        public void Heapify(int i)
        {
            while (true)
            {
                var leftChild = 2 * i + 1;
                var rightChild = 2 * i + 2;
                var leastChild = i;

                if (leftChild < HeapSize && list[leftChild] < list[leastChild]) 
                {
                    leastChild = leftChild;
                }

                if (rightChild < HeapSize && list[rightChild] < list[leastChild])
                {
                    leastChild = rightChild;
                }

                if (leastChild == i) 
                {
                    break;
                }

                var temp = list[i];
                list[i] = list[leastChild];
                list[leastChild] = temp;
                i = leastChild;
            }
        }
        
        public void BuildHeap(IEnumerable<int> sourceArray)
        {
            list = sourceArray.ToList();
            for (var i = HeapSize / 2; i >= 0; i--)
            {
                Heapify(i);
            }
        }
        
        public int GetMin()
        {
            var result = list[0];
            list[0] = list[HeapSize - 1];
            list.RemoveAt(HeapSize - 1);
            Heapify(0);
            return result;
        }
        
        public void HeapSort(int[] array)
        {
            BuildHeap(array);
            for (var i = array.Length - 1; i >= 0; i--)
            {
                array[i] = GetMin();
                Heapify(0);
            }
        }
    }
}
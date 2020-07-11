using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Get_First_Numbers_From_Union_Lists
{
    public static class Program
    {
        public static void Main()
        {
            const int n = 3;
            const int k = 3;
            var list = new List<List<int>>();
            var list1 = new List<int>{1, 3, 9};
            var list2 = new List<int>{2, 8, 15};
            var list3 = new List<int>{5, 6, 222};
            var tree = new BinaryHeapMin{Limit = n};
            list.Add(list1);
            list.Add(list2);
            list.Add(list3);
            for (var i = 0; i < k; i++)
            {
                for (var j = 0; j < list[i].Count; j++)
                    tree.Add(list[i][j]);
            }

            for (var i = 0; i < n; i++)
            {
                Console.WriteLine(tree.GetMin());
            }
        }
    }
}
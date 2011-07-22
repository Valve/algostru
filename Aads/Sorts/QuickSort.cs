using System;
using System.Collections.Generic;

namespace Aads.Sorts {
    public class QuickSort {
        public static void Sort<T>(T[] items) where T : IComparable<T> {
            Sort(items, 0, items.Length - 1);
        }

        public static void Sort<T>(T[] items, int p, int r) where T : IComparable<T> {
            if (p >= r) return;
            int q = Partition(items, p, r);
            Sort(items, p, q - 1);
            Sort(items, q + 1, r);
        }


        private static int Partition<T>(T[] items, int p, int r) where T : IComparable<T> {
            T x = items[r];
            int i = p - 1;
            for (int j = p; j < r; j++) {
                if (items[j].CompareTo(x) < 1) {
                    ++i;
                    Swap(items, i, j);
                }
            }
            Swap(items, i + 1, r);
            return i + 1;
        }

        private static void Swap<T>(IList<T> items, int a, int b) {
            T tmp = items[a];
            items[a] = items[b];
            items[b] = tmp;
        }
    }
}

using System;

namespace Aads.Sorts {
    public static class InsertionSort {
        public static void Sort<T>(T[] items) where T:IComparable<T> {
            if (items == null || items.Length == 1) return;
            for (long j = 1; j < items.Length; j++) {
                T key = items[j];
                long i = j - 1;
                while (i >= 0 && items[i].CompareTo(key)>0) {
                    items[i + 1] = items[i];
                    --i;
                    items[i + 1] = key;
                }
            }
        }
    }
}

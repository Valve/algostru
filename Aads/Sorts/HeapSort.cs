using System;
using System.Collections.Generic;


namespace Aads.Sorts {
    public static class HeapSort {
        public static void Sort<T>(T[] items) where T : IComparable<T> {
            if (items == null || items.Length == 1) return;
            BuildMaxHeap(items, items.Length);
            HeapSortCore(items);
        }

        public static void BuildMaxHeap<T>(T[] items, int heapSize) where T : IComparable<T> {
            for (int i = heapSize / 2; i >= 0; i--) {
                MaxHeapify(items, i, heapSize);
            }
        }

        public static void MaxHeapify<T>(T[] items, int index, int heapSize) where T : IComparable<T> {
            int left = index == 0 ? 1 : index * 2;
            int right = index == 0 ? 2 : index * 2 + 1;
            int largest = index;
            if (left < heapSize && items[left].CompareTo(items[largest]) > 0) {
                largest = left;
            }
            if (right < heapSize && items[right].CompareTo(items[largest]) > 0) {
                largest = right;
            }
            if (largest != index) {
                SwapItems(items, index, largest);
                MaxHeapify(items, largest, heapSize);
            }
        }

        private static void SwapItems<T>(IList<T> items, int index1, int index2) {
            T tmp = items[index2];
            items[index2] = items[index1];
            items[index1] = tmp;
        }

        private static void HeapSortCore<T>(T[] items) where T : IComparable<T> {
            for (int i = items.Length - 1; i > 0; i--) {
                SwapItems(items, 0, i);
                MaxHeapify(items, 0, i);
            }
        }
    }
}

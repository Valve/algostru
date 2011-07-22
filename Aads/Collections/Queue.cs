using System;

namespace Aads.Collections {
    public class Queue<T> {
        private T[] _items;
        private int _length;

        public int Length {
            get { return _length; }
        }

        public Queue() {
            _items = new T[16];
            _length = 0;
        }

        public void Enqueue(T item) {
            EnsureCapacity();
            _items[_length] = item;
            ++_length;
        }

        public T Dequeue() {
            if (_length == 0) throw new InvalidOperationException("Queue is empty, can't dequeue");
            T item = ShiftArray(_items);
            --_length;
            return item;
        }

        private void EnsureCapacity() {
            if (_length == _items.Length) {
                DoubleArray();
            }
        }

        private void DoubleArray() {
            var array = new T[_items.Length * 2];
            Array.Copy(_items, array, _items.Length);
            _items = array;
        }

        private T ShiftArray(T[] items) {
            if (items == null || items.Length == 0) {
                throw new InvalidOperationException("Can't shift empty array");
            }
            if (items.Length == 1) {
                T item = items[0];
                items[0] = default(T);
                return item;
            }
            T head = items[0];
            for (int i = 0; i < items.Length - 1; i++) {
                items[i] = items[i + 1];
            }
            return head;
        }

    }
}

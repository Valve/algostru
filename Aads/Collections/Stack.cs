using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aads.Collections {
    public class Stack<T> {
        private T[] _items;
        private int _length;

        public int Length { get { return _length; } }

        public Stack() {
            _items = new T[16];
            _length = 0;
        }

        public void Push(T item) {
            EnsureCapacity();
            _items[_length] = item;
            ++_length;
        }

        public T Pop() {
            if (_length == 0) throw new InvalidOperationException("Stack is empty");
            T item = _items[_length - 1];
            _items[_length - 1] = default(T);
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
    }
}

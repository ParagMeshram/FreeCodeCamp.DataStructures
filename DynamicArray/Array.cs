namespace DynamicArray
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    internal class Array<T> : IEnumerable<T>
    {
        private T[] items;

        public int Capacity { get; private set; }

        public int Count { get; private set; }


        public T this[int index]
        {
            get => this.items[index];
            set => this.items[index] = value;
        }

        public Array(int capacity = 4)
        {
            if (capacity <= 0) throw new ArgumentException($"Invalid argument '{nameof(capacity)}'", nameof(capacity));

            this.Capacity = capacity;
            this.items = new T[capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this.items, this.Count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(T item)
        {
            if (this.Count + 1 > this.Capacity)
            {
                this.Capacity *= 2;
                var temp = new T[this.Capacity];
                this.items.CopyTo(temp, 0);
                this.items = temp;
            }

            this.items[this.Count++] = item;
        }

        public T Remove(int index)
        {
            if (index >= this.Count || index < 0) throw new IndexOutOfRangeException();

            var item = this.items[index];

            Array.Copy(this.items, index + 1, this.items, index, this.Count - 1);

            this.Count--;

            return item;
        }

        public void Clear()
        {
            this.items = new T[this.Capacity];
            this.Count = 0;
        }


        private class Enumerator : IEnumerator<T>
        {
            private readonly T[] items;
            private int current = -1;

            public Enumerator(T[] items, int count)
            {
                this.items = items;
            }

            public T Current => throw new NotImplementedException();

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                this.current = -1;
            }
        }
    }
}
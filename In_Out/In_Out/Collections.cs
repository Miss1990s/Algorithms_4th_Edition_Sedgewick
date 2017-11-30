using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDS
{
    class Collections
    {
        static void main(string[] args)
        {
            Bag<int> testBag = new Bag<int>();
            foreach(var ts in testBag)
            {
                
            }
        }
    }
    /// <summary>
    /// 背包，只增不减，不在乎顺序；
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Bag<T>:IEnumerable<T>
    {
        T[] arr;
        int C;
        public Bag(int length = 8)
        {
            arr = new T[length];
            C = 0;
        }
        public void Add(T item)
        {
            if (C == arr.Length)
            {
                Resize(2*C);
            }
            arr[C++] = item;
        }
        public bool IsEmpty()
        {
            return C == 0;
        }
        public int Size()
        {
            return C;
        }
        private void Resize(int size)
        {
            var newArr = new T[size];
            for (int i = 0; i < C; i++)
            {
                newArr[i] = arr[i];
            }
            arr = newArr;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new BagIterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new BagIterator(this);
        }

        private class BagIterator : IEnumerator<T>
        {
            private Bag<T> bag;
            int index;
            public BagIterator(Bag<T> bag)
            {
                this.bag = bag;
                index = -1;
            }

            public T Current
            {
                get
                {
                    if(index == -1 || index == bag.C)
                    {
                        throw new InvalidOperationException();
                    }
                    return bag.arr[index];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                index++;
                return index < bag.C;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }

    class Stack<T> : IEnumerable<T>
    {
        T[] arr;
        int C;
        public Stack(int length = 8)
        {
            arr = new T[length];
            C = 0;
        }
        public void Push(T item)
        {
            if (C == arr.Length)
            {
                Resize(2*C);
            }
            arr[C++] = item;
        }
        public T Pop()
        {
            if (C > 3 && C < arr.Length / 4)
            {
                Resize(C/2);
            }
            return arr[--C];
        }

        public bool IsEmpty()
        {
            return C == 0;
        }
        public int Size()
        {
            return C;
        }
        private void Resize(int size)
        {
            var newArr = new T[size];
            for (int i = 0; i < C; i++)
            {
                newArr[i] = arr[i];
            }
            arr = newArr;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new StackIterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new StackIterator(this);
        }

        private class StackIterator : IEnumerator<T>
        {
            private Stack<T> bag;
            int index;
            public StackIterator(Stack<T> bag)
            {
                this.bag = bag;
                index = -1;
            }

            public T Current
            {
                get
                {
                    if (index == -1 || index == bag.C)
                    {
                        throw new InvalidOperationException();
                    }
                    return bag.arr[index];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                index++;
                return index < bag.C;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }

    class Queue<T> : IEnumerable<T>
    {
        T[] arr;
        int head, tail;
        public Queue(int capacity = 8)
        {
            arr = new T[capacity];
            head = tail = 0;
        }
        public void Enqueue(T item)
        {
            if (tail == arr.Length)
            {
                tail = 0;
            }
            if (tail == head)
            {
                Resize(2 * arr.Length);
            }
            arr[tail++] = item;
        }
        public T Dequeue()
        {
            if (Size > 3 && Size < arr.Length / 4)
            {
                Resize(arr.Length / 2);
            }
            return arr[head++];
        }

        public bool IsEmpty()
        {
            return head == tail;
        }
        public int Size
        {
            get { return tail > head ? tail - head : tail - head + arr.Length; }
        }
        private void Resize(int size)
        {
            var newArr = new T[size];
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[(i + head) < arr.Length ? i + head : i + head - arr.Length];
            }
            arr = newArr;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new Iterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Iterator(this);
        }

        private class Iterator : IEnumerator<T>
        {
            private Queue<T> bag;
            int index;
            public Iterator(Queue<T> bag)
            {
                this.bag = bag;
                index = bag.head-1;
            }

            public T Current
            {
                get
                {
                    if (index == -1 || index == bag.tail)
                    {
                        throw new InvalidOperationException();
                    }
                    return bag.arr[index];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                ++index;
                int tempTail = bag.head > bag.tail ? bag.tail + bag.arr.Length : bag.arr.Length;
                return index >= bag.head && index<tempTail;
            }

            public void Reset()
            {
                index = bag.head-1;
            }
        }
    }
}

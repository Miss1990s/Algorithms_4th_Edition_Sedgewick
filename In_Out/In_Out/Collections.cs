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
    class Bag<T>:IEnumerable<T>
    {
        T[] arr;
        public Bag(int length = 8)
        {
            arr = new T[length];
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
                    if(index == -1 || index == bag.arr.Length)
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
                return index < bag.arr.Length;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }
}

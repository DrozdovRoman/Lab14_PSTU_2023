using System;
using System.Collections.Generic;
using System.Collections;

namespace MyCollection
{
    public class MyCollection<T> : IList<T> where T: ICloneable
    {
        protected Node<T> head = null;
        protected Node<T> tail = null;
        public int Count { get; protected set; }
        public bool IsReadOnly { get => false; }
        
        public MyCollection()
        {
            Count = 0;
        }
        
        public MyCollection(IEnumerable<T> objects)
        {
            foreach(T elem in objects)
            {
                Add((T)elem.Clone());
            }
        }
        public bool Remove(T data)
        {
            bool flag = false;
            Node<T> current = head;

            while (!(current is null))
            {
                if (current.data.Equals(data))
                {
                    if (current.next is null)
                    {
                        DeleteTail();
                    }
                    else if (current.prev is null)
                    {
                        DeleteHead();
                    }
                    else
                    {
                        current.prev.next = current.next;
                        current.next.prev = current.prev;
                    }
                    current = null;
                    flag = true;
                }
                else
                {
                    current = current.next;
                }
                --Count;
            }
            return flag;
        }

        public int IndexOf(T data)
        {
            int index = -1, currentIndex = 0; 
            foreach (T obj in this)
            {
                if (obj.Equals(data))
                {
                    index = currentIndex;
                    break; 
                }
                ++currentIndex;
            }
            return index;
        }

        public void Insert(int index, T data)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentException(nameof(index));
            }
            Node<T> current = Find(index);
            Node <T> newNode = new Node<T>(data,null,null);
            if (index == 0)
            {
                head.prev = newNode;
                newNode.next = head;
                head = newNode;
            }
            else
            {
                newNode.prev = current.prev;
                newNode.next = current;
                current.prev.next = newNode;
                current.prev = newNode;
            }
            ++Count;
        }

        public virtual void RemoveAt(int index)
        {
            if (Count > 0)
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentException(nameof(index));
                }
                if (index == 0)
                {
                    DeleteHead();
                }
                else if (index == Count - 1)
                {
                    DeleteTail();
                }
                else
                {
                    var current = Find(index);
                    current.prev.next = current.next;
                    current.next.prev = current.prev;
                    --Count;
                }
            }
        }

        public virtual T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                return Find(index).data;
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                Find(index).data = value;
            }
        }
        
        public Node<T> Find(int index)
        {
            bool isNext = index > ((Count - 1) / 2);
            Node<T> current = null;
            
            if (isNext) current = head;
            else current = tail;
            
            if (Count > 0)
            {
                int currentIndex = 0;
                if (!isNext) currentIndex = Count - 1;
                while (currentIndex != index)
                {
                    if (isNext)
                    {
                        current = current.next;
                        currentIndex = currentIndex + 1;
                    }
                    else
                    {
                        current = current.prev;
                        currentIndex = currentIndex - 1;
                    }
                }
            }
            return current;
        }
        
        public virtual void Add(T data)
        {
            if (Count == 0)
            {
                head = new Node<T>(data, null, null);
                tail = head;
            }
            else
            {
                Node<T> newNode = new Node<T>(data, tail, false);
                tail.next = newNode;
                tail = newNode;
            }
            ++Count;
        }
        
        public void Clear()
        {
            Count = 0;
            head = null;
            tail = null;
        }

        public bool Contains(T data)
        {
            bool flag = false;
            foreach (T elem in this)
            {
                if (elem.Equals(data))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException();
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException(nameof(arrayIndex));
            }
            int index = 0;
            foreach (var value in this)
            {
                array[index + arrayIndex] = (T)value.Clone();
                ++index;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;

            while(!(current is null))
            {
                yield return current.data;
                current = current.next;
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public void DeleteHead()
        {
            if(Count>0)
            {
                head = head.next;
                if (!(head is null))
                {
                    head.prev = null;
                }
                --Count;
            }
        }
        public void DeleteTail()
        {
            if (Count > 0)
            {
                tail = tail.prev;
                if (!(tail is null))
                {
                    tail.next = null;
                }
                --Count;
            }
        }
        public override string ToString()
        {
            string str = "";
            foreach(T obj in this)
            {
                str += obj + "\n";
            }
            return str;
        }
    }
}
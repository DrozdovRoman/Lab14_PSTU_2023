using System;

namespace MyCollection
{
    public class Node<T> where T: ICloneable
    {
        public T data;
        public Node<T> next = null;
        public Node<T> prev = null;

        public Node()
        {
            data = default;
        }

        public Node(T data, Node<T> node, bool isNext)
        {
            this.data = data;
            if (isNext)
            {
                next = node;
                prev = null;
            }
            else
            {
                next = null;
                prev = node;
            }
        }

        public Node(T data, Node<T> prev, Node<T> next)
        {
            this.data = data;
            this.prev = prev;
            this.next = next;
        }
    }
}
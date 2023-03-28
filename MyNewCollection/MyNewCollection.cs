using System;
using MyCollection;

namespace MyNewCollection
{
    public class MyNewCollection<T>: MyCollection<T> where T : ICloneable
    {
        public delegate void CollectionHandler(object source, CollectionHandlerEventArgs<T> args);
        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;
        
        public string Name { get; set; }

        public MyNewCollection():base()
        {
            Name = "MyNewCollection";
        }

        public override T this[int index]
        {
            get
            {
                return base[index];
            }
            set
            {
                base[index] = value;
                OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs<T>(Name, "Change", value));
            }
        }
        
        public override void Add(T obj)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs<T>(Name, "Add", obj));
            base.Add(obj);
        }
        
        public override void RemoveAt(int index)
        {
            T obj = this[index];
            if (base.Remove(obj))
            {
                OnCollectionCountChanged(this, new CollectionHandlerEventArgs<T>(Name, "delete", obj));
            }
        }

        public void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs<T> args)
        {
            CollectionReferenceChanged?.Invoke(source, args);
        }

        public void OnCollectionCountChanged(object source, CollectionHandlerEventArgs<T> args)
        {
            CollectionCountChanged?.Invoke(source, args);
        }
    }
}
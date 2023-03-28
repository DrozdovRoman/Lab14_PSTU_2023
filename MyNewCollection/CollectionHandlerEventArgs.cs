using System;

namespace MyNewCollection
{
    public class CollectionHandlerEventArgs<T>: EventArgs
    {
        public string CollectionName { get; }
        public string ActionType { get; }
        public T Reference { get; }

        public CollectionHandlerEventArgs(string collectionName, string action, T reference)
        {
            this.CollectionName = collectionName;
            this.ActionType = action;
            this.Reference = reference;
        }

        public override string ToString()
        {
            return ($"Название коллекции: {CollectionName}\n" +
                    $"Тип действия: {ActionType}\n");
        }
    }
}
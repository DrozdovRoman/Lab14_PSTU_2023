using System;
using System.Collections.Generic;

namespace MyNewCollection
{
    public class JournalEntry
    {
        public string CollectionName { get; }
        public string ChangeType { get; }
        public string ObjectInfo { get; }
        public JournalEntry(string CollectionName, string ChangeType, string ObjectInfo)
        {
            this.ObjectInfo = ObjectInfo;
            this.CollectionName = CollectionName;
            this.ChangeType = ChangeType;
        }
        public override string ToString()
        {
            return $"| Name: {CollectionName} |\n| Type: {ChangeType} |\n{ObjectInfo}";
        }
    }
    
    public class Journal<T>
    {
        public List<JournalEntry> journalOfChange;

        public Journal()
        {
            journalOfChange = new List<JournalEntry>();
        }
        
        public void CollectionCountChanged(object source, CollectionHandlerEventArgs<T> e)
        {

            JournalEntry je = new JournalEntry(e.CollectionName, e.ActionType, e.Reference.ToString());
            
            journalOfChange.Add(je);
            
        }
        
        public void CollectionReferenceChanged(object source, CollectionHandlerEventArgs<T> e)
        {

            JournalEntry je = new JournalEntry(e.CollectionName, e.ActionType, e.Reference.ToString());
            
            journalOfChange.Add(je);
            
        }
    }
}
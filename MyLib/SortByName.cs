using System;
using System.Collections;

namespace MyLib
{
    public class SortByName: IComparer
    {
        int IComparer.Compare(object obj1, object obj2)
        {
            Person s1 = (Person)obj1;
            Person s2 = (Person)obj2;
            return String.Compare(s1.FullName, s2.FullName);
        }
    }
}
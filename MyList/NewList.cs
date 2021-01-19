﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace MyList
{
    public class NewList<T> : IEnumerable<T>, IList<T>
    {
        public T[] NewArray;
        public int Count { get; private set; } = 0;

        public bool IsReadOnly => true;

        public T this[int index] { get => NewArray[index]; set => NewArray[index]=value; }

        public NewList() : this(1) { }

        public NewList(int capacity)
        {
            NewArray = new T[capacity];
        }

        public void Add(T item)
        {
            if (Count >= NewArray.Length)
            {
                Array.Resize(ref NewArray, NewArray.Length * 2);
            }
            NewArray[Count] = item;
            Count++;
        }

        public void Remove(T item) 
        {
            T[] secondArray = new T[Count + 1];

            for (int i = 0; i < Count; i++) 
            {
                secondArray[i] = NewArray[i];
            }

            for(int i = 0; i < Count; i++) 
            {
                if(NewArray[i].Equals(item)) 
                {
                    for (int j = i + 1; j < Count; j++) 
                    {
                        NewArray[j -1] = secondArray[j];
                        Count--;
                    }
                }
            }
        }

        public bool Contains(T item) 
        {
            for(int i = 0; i < Count; i++) 
            {
                if (NewArray[i].Equals(item)) 
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int a = 0; a < Count; a++)
            {
                yield return NewArray[a];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++) 
            {
                if (NewArray[i].Equals(item)) 
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            T[] secondArray = new T[Count];
            for (int j = 0; j < Count; j++) 
            {
                secondArray[j] = NewArray[j];

            }
            Add(item);
            for (int i = 0; i < Count; i++) 
            {
                if (i > index - 1)
                {
                    NewArray[i] = secondArray[i-1];
                }
            }
            NewArray[index-1] = item; 
        }

        public void RemoveAt(int index)
        {
            T[] secondArray = new T[Count + 1];

            for (int i = 0; i < Count; i++)
            {
                secondArray[i] = NewArray[i];
            }

            for (int i = 0; i < Count; i++)
            {
                if (i >= index) 
                {
                    NewArray[i] = secondArray[i + 1];
                }
            }
            Count--;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotImplementedException();
        }
    }
}
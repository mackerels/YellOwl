using System;
using System.Collections.Generic;

namespace YellOwl.Storage
{
    public interface IGenericStorage<T>
    {
        void Add(T value);
        T Find(Func<T, bool> predicate);
        IEnumerable<T> GetAll();
        void Remove(T value);
    }
}
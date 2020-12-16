using System;
using System.Collections.Generic;

namespace eWallet.DAL.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T item);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Remove(T item);
        void Update(T item);
    }
}

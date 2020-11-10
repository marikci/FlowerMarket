using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FlowerMarket.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        T Get(Expression<Func<T, bool>> expression);
        void Insert(T item);
        void Update();
    }
}

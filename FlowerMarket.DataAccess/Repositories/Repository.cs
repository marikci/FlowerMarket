using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FlowerMarket.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlowerMarket.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private FlowerMarketContext _flowerMarketContext;
        private readonly DbSet<T> _dbSet;
        public Repository(FlowerMarketContext flowerMarketContext)
        {
            _flowerMarketContext = flowerMarketContext;
            _dbSet = _flowerMarketContext.Set<T>();
        }

        public void Insert(T item)
        {
            _dbSet.Add(item);
        }

        public void Update()
        {
            _flowerMarketContext.SaveChanges();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing || _flowerMarketContext == null) return;
            _flowerMarketContext.Dispose();
            _flowerMarketContext = null;
        }
    }
}

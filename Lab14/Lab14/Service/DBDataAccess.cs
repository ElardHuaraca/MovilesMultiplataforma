﻿using Lab14.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Lab14.Service
{
    public class DBDataAccess<T> where T : class
    {
        private readonly AppDBContext _context;

        public DBDataAccess() => _context = App.GetContext();

        public bool Create(T entity) 
        {
            bool created;
            try
            {
                _context.Entry(entity).State = EntityState.Added;
                _context.SaveChanges();
                created = true;
            }
            catch (Exception){ throw; }
            return created;
        }
        public IEnumerable<T> Get()
        {
            return _context.Set<T>().AsEnumerable();
        }
        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).AsEnumerable<T>();
        }
        public IEnumerable<T> Get(Expression<Func<T, bool>> whereCondition = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                  string includeProperties = "")
        {
            IQueryable<T> query = _context.Set<T>();

            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public bool Update(T entity) 
        {
            bool state = false;
            try
            {
                _context.Update(entity);
                _context.SaveChanges();
                state = true;
            }
            catch (Exception) { throw; }
            return state;
        }
        public bool Delete(Expression<Func<T, bool>> predicate)
        {
            bool state = false;
            T existing = _context.Set<T>().Where(predicate).FirstOrDefault();
            if (existing != null)
            {
                try
                {
                    _context.Set<T>().Remove(existing);
                    _context.SaveChanges();
                    state = true;
                }
                catch (Exception) { throw; }
            }
            return state;
        }

    }
}

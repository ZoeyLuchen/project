﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;

namespace SexShop.IRepository
{
    public interface IEntityBaseRepository<T>
    {

        IEnumerable<T> GetListBySql(string sql, DbParameter[] paras);

        IEnumerable<T> GetAll();

        int Count();

        IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        T GetSingle(int id);

        T GetSingle(Expression<Func<T, bool>> predicate);

        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        int Add(T entity);

        void BatchAdd(List<T> list);

        void Update(T entity);

        void Delete(T entity);

        void DeleteWhere(Expression<Func<T, bool>> predicate);

        bool Any(Expression<Func<T, bool>> predicate);

        void Commit();
    }
}

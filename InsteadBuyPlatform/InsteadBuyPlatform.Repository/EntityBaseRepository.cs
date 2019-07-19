using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using InsteadBuyPlatform.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using EFCore.BulkExtensions;
using InsteadBuyPlatform.Entity;

namespace InsteadBuyPlatform.Repository
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        public InsteadBuyPlatformDbContext _context;
        #region Properties

        public EntityBaseRepository(InsteadBuyPlatformDbContext context)
        {
            _context = context;
        }

        #endregion
        public virtual IEnumerable<T> GetAll()

        {
            return _context.Set<T>().AsEnumerable();
        }

        public virtual int Count()
        {
            return _context.Set<T>().Count();
        }

        public virtual int Count(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Count(predicate);
        }

        public virtual IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }

        public T GetSingle(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.Where(predicate).FirstOrDefault();
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public virtual int Add(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            var m = _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return m.Entity.Id;
        }

        public virtual void BatchAdd(List<T> list)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                _context.BulkInsert(list);
                transaction.Commit();
            }
        }

        public virtual void Update(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void BatchUpdate(List<T> list)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                _context.BulkUpdate(list);
                transaction.Commit();
            }
        }

        public virtual void Delete(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);
            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }

        public virtual bool Any(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Any(predicate);
        }
        public virtual void Commit()
        {
            _context.SaveChanges();
        }

        public virtual PageModel<T> SearchListByPage(PageInfo pageInfo, Expression<Func<T, bool>> predicate = null)
        {
            int count = 0;
            List<T> list = null;
            if (predicate == null)
            {
                count = _context.Set<T>().Count();
                list = _context.Set<T>().Skip((pageInfo.PageIndex - 1) * pageInfo.PageSize).Take(pageInfo.PageSize).OrderByDescending(e => e.Id).ToList();
            }
            else
            {
                count = _context.Set<T>().Count(predicate);
                list = _context.Set<T>().Where(predicate).Skip((pageInfo.PageIndex - 1) * pageInfo.PageSize).Take(pageInfo.PageSize).OrderByDescending(e => e.Id).ToList();
            }

            PageModel<T> result = new PageModel<T>(list, pageInfo.PageIndex, pageInfo.PageSize, count);

            return result;
        }
    }
}

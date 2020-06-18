using Microsoft.EntityFrameworkCore;
using PrisonService.DA.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrisonService.DA.Repos
{
    public class GenericRepo<T> where T : class
    {
        private PrisonDbContext context;
        private DbSet<T> set;

        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = set;

            if (filter != null)
            {
                query = query.Where(filter);
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

        public virtual T GetByID(object id)
        {
            return set.Find(id);
        }

        public virtual void Insert(T entity)
        {
            set.Add(entity);
        }

        public virtual void Delete(object id)
        {
            for(int i = 0; i<8; i++)
            {
                Console.WriteLine(typeof(T));
            }
            set = context.Set<T>();
            T entityToDelete = set.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                set.Attach(entityToDelete);
            }
            set.Remove(entityToDelete);
        }

        public virtual void Update(T entityToUpdate)
        {
            set.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public GenericRepo(PrisonDbContext context)
        {
            this.context = context;
            set = context.Set<T>();
        }
    }
}

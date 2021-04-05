using Microsoft.EntityFrameworkCore;
using ProjetoAPI02.Repository.Contexts;
using ProjetoAPI02.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoAPI02.Repository.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        private SqlServerContext context;

        public BaseRepository(SqlServerContext context)
        {
            this.context = context;
        }

        public void Insert(T obj)
        {
            context.Entry(obj).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(T obj)
        {
            context.Entry(obj).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return context.Set<T>().Find(id);
        }
    }
}

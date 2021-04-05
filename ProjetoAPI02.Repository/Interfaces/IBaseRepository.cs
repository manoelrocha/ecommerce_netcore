using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI02.Repository.Interfaces
{
    public interface IBaseRepository<T>
        where T : class
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);

        List<T> GetAll();
        T GetById(Guid id);
    }
}

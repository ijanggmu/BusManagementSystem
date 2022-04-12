using System;
using System.Collections.Generic;
using System.Text;

namespace Bus.Repo
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        void SaveChanges();

    }
}

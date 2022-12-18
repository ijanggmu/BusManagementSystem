using System.Collections.Generic;

namespace Bus.Services.Contracts
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        void SaveChanges();

    }
}

using System.Collections.Generic;

namespace Catalog.Infrastructure.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        List<T> Get();

        T GetById(int id);

        void Create(T obj);

        void Edit(T obj);

        void Delete(T obj);
    }
}
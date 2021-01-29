using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Favohit.WebApi.Repository.Interface
{
    interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(Guid id);

        Task<T> Save(T obj);

        Task<T> Remove(T obj);

        Task<T> Update(T obj);
    }
}

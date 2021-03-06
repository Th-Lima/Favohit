﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Favohit.WebApi.Repository.Interface
{
    interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(Guid id);

        Task Save(T obj);

        Task Remove(T obj);

        Task Update(T obj);
    }
}

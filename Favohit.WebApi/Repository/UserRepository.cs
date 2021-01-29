using Favohit.WebApi.Models;
using Favohit.WebApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Favohit.WebApi.Repository
{
    public class UserRepository : IRepository<User>
    {
        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Remove(User obj)
        {
            throw new NotImplementedException();
        }

        public Task<User> Save(User obj)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}

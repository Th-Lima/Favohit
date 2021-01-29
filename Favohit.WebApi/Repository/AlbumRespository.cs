using Favohit.WebApi.Models;
using Favohit.WebApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Favohit.WebApi.Repository
{
    public class AlbumRespository : IRepository<Album>
    {
        public Task<IEnumerable<Album>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Album> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Album> Remove(Album obj)
        {
            throw new NotImplementedException();
        }

        public Task<Album> Save(Album obj)
        {
            throw new NotImplementedException();
        }

        public Task<Album> Update(Album obj)
        {
            throw new NotImplementedException();
        }
    }
}

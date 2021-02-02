using Favohit.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Favohit.WebApi.Repository.Base
{
    public class BaseRepository<T> where T : class
    {
        public DbContext Context { get; set; }
        public DbSet<T> Query { get; set; }

        public BaseRepository(FavohitContext context)
        {
            this.Context = context;
            this.Query = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Query.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await Query.FindAsync(id);
        }

        public async Task Remove(T obj)
        {
            Query.Remove(obj);
            await Context.SaveChangesAsync();
        }

        public async Task Save(T obj)
        {
            Query.Add(obj);
            await Context.SaveChangesAsync();
        }

        public async Task Update(T obj)
        {
            Query.Update(obj);
            await Context.SaveChangesAsync();
        }
    }
}

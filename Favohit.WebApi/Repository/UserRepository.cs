using Favohit.WebApi.Data;
using Favohit.WebApi.Models;
using Favohit.WebApi.Repository.Base;
using Favohit.WebApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favohit.WebApi.Repository
{
    public class UserRepository : BaseRepository<User>, IRepository<User>
    {
        public UserRepository(FavohitContext context) : base(context){}

        public async Task<IList<UserFavoriteMusic>> GetFavoriteMusics(Guid id)
        {
            return await this.Query.Include(x => x.FavoriteMusics) //Carregar a propriedade FavoriteMusic
                .ThenInclude(x => x.Music) //Dentro de FavoriteMusic, carrega Music
                .ThenInclude(x => x.Album) //Dentro de FavoriteMusic, carrega Album
                .Where(x => x.Id == id) //Busca usuário pelo id
                .SelectMany(x => x.FavoriteMusics) //Por fim pedimos somente as músicas favoritas do usuário, FavoriteMusic
                .ToListAsync(); //Transformar em uma lista
        }

        public async Task<User> Authenticated(string email, string password)
        {
            return await this.Query.Include(x => x.FavoriteMusics) //Carregar a propriedade FavoriteMusic
                .ThenInclude(x => x.Music) //Dentro de FavoriteMusic, carrega Music
                .ThenInclude(x => x.Album) //Dentro de FavoriteMusic, carrega Album
                .Where(x => x.Password == password && x.Email == email)
                .FirstOrDefaultAsync();
        }

        public new async Task<User> GetById(Guid id)
        {
            return await this.Query.Include(x => x.FavoriteMusics) //Carregar a propriedade FavoriteMusic
                .ThenInclude(x => x.Music) //Dentro de FavoriteMusic, carrega Music
                .ThenInclude(x => x.Album) //Dentro de FavoriteMusic, carrega Album
                .Where(x => x.Id == id) //Busca usuário pelo id
                .FirstOrDefaultAsync();
        }
    }
}

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
    public class AlbumRepository : BaseRepository<Album>, IRepository<Album>
    {
        public AlbumRepository(FavohitContext context) : base(context){}

        public async Task<IList<Music>> GetMusicFromAlbum(Guid albumId)
        {
            return await this.Query.Include(x => x.Musics)
                .Where(x => x.Id == albumId)
                .SelectMany(x => x.Musics)
                .ToListAsync();
        }

        public async Task<Music> GetMusic(Guid musicId)
        {
            return await this.Query.Include(x => x.Musics)
                .SelectMany(x => x.Musics)
                .FirstOrDefaultAsync(x => x.Id == musicId);
        }
    }
}

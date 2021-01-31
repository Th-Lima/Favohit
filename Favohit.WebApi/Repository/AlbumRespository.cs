using Favohit.WebApi.Data;
using Favohit.WebApi.Models;
using Favohit.WebApi.Repository.Base;
using Favohit.WebApi.Repository.Interface;

namespace Favohit.WebApi.Repository
{
    public class AlbumRespository : BaseRepository<Album>, IRepository<Album>
    {
        public AlbumRespository(FavohitContext context) : base(context){}
    }
}

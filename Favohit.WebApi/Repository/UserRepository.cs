using Favohit.WebApi.Data;
using Favohit.WebApi.Models;
using Favohit.WebApi.Repository.Base;
using Favohit.WebApi.Repository.Interface;

namespace Favohit.WebApi.Repository
{
    public class UserRepository : BaseRepository<User>, IRepository<User>
    {
        public UserRepository(FavohitContext context) : base(context){}
    }
}

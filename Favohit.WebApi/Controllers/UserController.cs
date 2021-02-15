using Favohit.WebApi.Models;
using Favohit.WebApi.Repository;
using Favohit.WebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Favohit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private UserRepository _userRepository { get; set; }
        private AlbumRepository _albumRepository { get; set; }

        public UserController(UserRepository userRepository, AlbumRepository albumRepository)
        {
            _userRepository = userRepository;
            _albumRepository = albumRepository;
        }
        
        [HttpPost("authenticate")]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var password64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(model.Password));
                var user = await _userRepository.Authenticated(model.Email, password64);

                if(user == null)
                {
                    return UnprocessableEntity(new
                    {
                        Message = "Email ou Senha inválido"
                    });
                }

                return Ok(user);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User();
            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(model.Password));
            user.Photo = $"https://robohash.org/{Guid.NewGuid()}.png?bgset=any";

            await _userRepository.Save(user);

            return Created($"{user.Id}", user);
        }


        [HttpGet("{id}/favorite-music")]
        public async Task<IActionResult> GetFavoriteMusic(Guid id)
        {
            return Ok(await _userRepository.GetFavoriteMusics(id));
        }


        [HttpPost("{id}/favorite-music/{musicId}")]
        public async Task<IActionResult> SaveUserFavoriteMusic(Guid id, Guid musicId)
        {
            var music = await _albumRepository.GetMusic(musicId);
            var user = await _userRepository.GetById(id);

            user.AddFavoriteMusic(music);

            await _userRepository.Update(user);

            return Ok(user);
        }

        [HttpDelete("{id}/favorite-music/{musicId}")]
        public async Task<IActionResult> RemoveUserFavoriteMusic(Guid id, Guid musicId)
        {
            var music = await _albumRepository.GetMusic(musicId);
            var user = await _userRepository.GetById(id);

            user.RemoveFavoriteMusic(music);

            await _userRepository.Update(user);

            return Ok(user);
        }
    }
}

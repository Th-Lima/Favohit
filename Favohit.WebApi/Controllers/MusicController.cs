using Favohit.WebApi.Models;
using Favohit.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Favohit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private AlbumRepository _repository { get; set; }
        
        public MusicController(AlbumRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(Guid id)
        {
            var music = await _repository.GetMusicFromAlbum(id);

            return Ok(music);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var music = await _repository.GetMusic(id);

            return Ok(music);
        }

        [HttpPost("{albumId}")]
        public async Task<IActionResult> Post(Guid albumId, Music music)
        {
            //Get album
            var album = await _repository.GetById(albumId);
            
            //Adding music in album
            album.Musics.Add(music);

            //Update album model
            await _repository.Update(album);

            return Ok();
        }
    }
}

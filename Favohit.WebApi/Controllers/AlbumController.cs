using Favohit.WebApi.Models;
using Favohit.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Favohit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : Controller
    {
        private AlbumRepository _repository { get; set; }

        public AlbumController(AlbumRepository respository)
        {
            _repository = respository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbum(Guid id)
        {
            var result = await _repository.GetById(id);
            
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Album album)
        {
            await _repository.Save(album);

            return Created($"/{album.Id}", album);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var album = await _repository.GetById(id);

            await _repository.Remove(album);

            return NoContent();
        }
    }
}

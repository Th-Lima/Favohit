using Favohit.WebApi.Models;
using Favohit.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
            var albumDuplicated = _repository.Query.Where(x => x.Name == album.Name && x.Band == album.Band).ToList();

            if (albumDuplicated != null && albumDuplicated.Count > 0)
            {
                return BadRequest(new
                {
                    Message = "Album já existe"
                });
            }
            
            if (ModelState.IsValid)
            {
                await _repository.Save(album);
                return Created($"/{album.Id}", album);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var album = await _repository.GetById(id);

            await _repository.Remove(album);

            return Ok("Deletado com sucesso");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favohit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new 
            {
                Id = Guid.NewGuid(),
                Titlle = "Teste",
                Description = "Teste 0001"
            });
        }
    }
}

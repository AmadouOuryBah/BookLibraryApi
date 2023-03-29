using Library.BusinessLayer.DTO_s;
using Library.BusinessLayer.Requests;
using Library.BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Presentation.Controllers
{
    [ApiController]
    [Route("genres")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GenreDto>> Add([FromBody] GenreRequest genreRequest, CancellationToken cancellation)
        {
            return Ok(await _genreService.AddAsync(genreRequest, cancellation));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GenreDto>> Update([FromRoute] int id, [FromBody] GenreRequest genreRequest,
            CancellationToken cancellation)
        {
            return Ok(await _genreService.UpdateAsync(id, genreRequest, cancellation));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GenreDto>> GetAll(CancellationToken cancellation)
        {
            return Ok(await _genreService.GetAllAsync(cancellation));
        }

    }
}

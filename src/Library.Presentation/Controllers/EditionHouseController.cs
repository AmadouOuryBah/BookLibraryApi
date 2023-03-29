using Library.BusinessLayer.DTO_s;
using Library.BusinessLayer.Requests;
using Library.BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Presentation.Controllers
{
    [ApiController]
    [Route("EditionHouses")]
    public class EditionHouseController : ControllerBase
    {
        private readonly IEditionHouseService _editionHouseService;

        public EditionHouseController(IEditionHouseService editionHouseService)
        {
            _editionHouseService = editionHouseService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EditionHouseDto>> Add([FromBody] EditionHouseRequest editionHouseRequest, CancellationToken cancellation)
        {
            return Ok(await _editionHouseService.AddAsync(editionHouseRequest, cancellation));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EditionHouseDto>> GetAll(CancellationToken cancellation)
        {
            return Ok(await _editionHouseService.GetAllAsync(cancellation));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EditionHouseDto>> Update([FromRoute]int id, [FromBody] EditionHouseRequest editionHouseRequest,
            CancellationToken cancellation)
        {
            return Ok(await _editionHouseService.UpdateAsync(id, editionHouseRequest, cancellation));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> Delete([FromRoute] int id, CancellationToken cancellation)
        {
            return Ok(await _editionHouseService.DeleteAsync(id, cancellation));
        }        
    }
}

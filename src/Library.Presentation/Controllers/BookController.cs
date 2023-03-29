using Library.BusinessLayer.DTO_s;
using Library.BusinessLayer.Requests;
using Library.BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Presentation.Controllers
{
    [ApiController]
    [Route("Books")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookDto>> GetBooks(CancellationToken cancellation)
        {
            return Ok(await _bookService.GetAllAsync(cancellation));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookDto>> Add([FromBody] BookRequest book, CancellationToken cancellation)
        {
            return Ok(await _bookService.AddAsync(book, cancellation));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookDto>> Update([FromRoute] int id,
            [FromBody] BookRequest book,
            CancellationToken cancellation)
        {

            return Ok(await _bookService.UpdateAsync(id, book, cancellation));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> Delete([FromRoute] int id, CancellationToken cancellation)
        {
            return Ok(await _bookService.DeleteAsync(id, cancellation));
        }
    }
}

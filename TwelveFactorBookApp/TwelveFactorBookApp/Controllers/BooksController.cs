using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwelveFactorBookApp.Models;
using TwelveFactorBookApp.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TwelveFactorBookApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;
        private readonly ILogger<BooksController> logger;

        public BooksController(IBookRepository bookRepository, ILogger<BooksController> logger)
        {
            this.bookRepository = bookRepository;
            this.logger = logger;
        }

        // GET: api/<BooksController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await bookRepository.GetBooksAsync();

            if (books is null)
            {
                this.logger.LogWarning("No books were avaible at the time of the call.");
                return BadRequest();
            }

            return Ok(books);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await bookRepository.GetBookByIdAsync(id);

            if (book is null)
            {
                this.logger.LogInformation($"Book with ID {id} doesn´t exist.");
                return NotFound();
            }

            return Ok(book);
        }

        // POST api/<BooksController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            var successful = await this.bookRepository.AddBookAsync(book);

            if (successful)
            {
                return Ok();
            }

            this.logger.LogWarning("Book couldn´t be added:", book);
            return BadRequest("An error occurred");
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var successful = await this.bookRepository.DeleteBookAsync(id);
            if (successful)
            {
                return Ok();
            }

            this.logger.LogWarning($"Book couldn´t be deleted with ID {id}");
            return BadRequest("An error occurred");
        }
    }
}

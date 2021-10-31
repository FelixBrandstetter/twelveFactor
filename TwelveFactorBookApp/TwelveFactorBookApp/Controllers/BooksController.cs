using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
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

        public BooksController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        // GET: api/<BooksController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            Log.Information("This is a test");
            var books = await bookRepository.GetBooksAsync();

            if (books is null)
            {
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

            return BadRequest("An error occurred");
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public  async Task<IActionResult> Delete(int id)
        {
            var successful = await this.bookRepository.DeleteBookAsync(id);
            if (successful)
            {
                return Ok();
            }
            return BadRequest("An error occurred");
        }
    }
}

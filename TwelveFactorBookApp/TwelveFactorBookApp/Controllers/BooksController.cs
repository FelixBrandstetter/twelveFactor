using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = bookRepository.GetBooks();

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
        public ActionResult<Book> Get(int id)
        {
            var book = bookRepository.GetBookById(id);

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
        public IActionResult AddBook([FromBody] Book book)
        {
            var successful = this.bookRepository.AddBook(book);

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
        public IActionResult Delete(int id)
        {
            var successful = this.bookRepository.DeleteBook(id);

            if (successful)
            {
                return Ok();
            }

            return BadRequest("An error occurred");
        }
    }
}

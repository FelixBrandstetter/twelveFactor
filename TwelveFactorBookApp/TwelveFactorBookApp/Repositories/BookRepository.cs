using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwelveFactorBookApp.DBContexts;
using TwelveFactorBookApp.Models;

namespace TwelveFactorBookApp.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext context;

        public BookRepository(BookContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddBookAsync(Book book)
        {
            _ = await context.AddAsync(book);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await context.Books.FindAsync(id);
            context.Books.Remove(book);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await context.Books.FindAsync(id);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await context.Books.ToListAsync();
        }
    }
}

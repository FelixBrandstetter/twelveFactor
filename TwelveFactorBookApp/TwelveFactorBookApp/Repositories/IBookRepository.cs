using System.Collections.Generic;
using System.Threading.Tasks;
using TwelveFactorBookApp.Models;

namespace TwelveFactorBookApp.Repositories
{
    public interface IBookRepository
    {
        Task<bool> AddBookAsync(Book book);
        Task<bool> DeleteBookAsync(int id);
        Task<Book> GetBookByIdAsync(int id);
        Task<IEnumerable<Book>> GetBooksAsync();
    }
}
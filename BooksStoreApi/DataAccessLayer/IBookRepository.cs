using BooksStoreApi.Models;

namespace BooksStoreApi.DataAccessLayer;

public interface IBookRepository
{
    Task<List<Book>> GetAllRecords();
    Task<Book> GetBookById(string id);
    Task<String> InsertBook(Book book);
}
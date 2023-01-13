
using BooksStoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BooksStoreApi.DataAccessLayer;

public class BookRepository:IBookRepository
{
     
       private readonly IConfiguration _configuration;

       private readonly MongoClient _mongoClient;

       private readonly IMongoCollection<Book> _mongoCollection;

       public BookRepository(IConfiguration configuration){

         _configuration = configuration;
          _mongoClient = new MongoClient(_configuration["DatabaseSetting:ConnectionString"]);

          var _MongoDatabase = _mongoClient.GetDatabase(_configuration["DatabaseSetting:DatabaseName"]);

          _mongoCollection = _MongoDatabase.GetCollection<Book>(_configuration["DatabaseSetting:CollectionName"]);
     }

    public async Task<List<Book>> GetAllRecords()
    {
        List<Book> books = new List<Book>();
        books = await _mongoCollection.Find(x => true).ToListAsync();
        return books;
    }

    public async Task<Book> GetBookById(string id)
    {
        Book book = await _mongoCollection.Find(x=>x.Id==id).FirstOrDefaultAsync();
        return book;
    }

    public async Task<String> InsertBook(Book book)
    {
        try{
               await _mongoCollection.InsertOneAsync(book);
               
        }catch(Exception ex)
        {
            return "Exception Occured: "+ex.Message;
        }

        return "Data Inserted Successfully";
    }


    
}
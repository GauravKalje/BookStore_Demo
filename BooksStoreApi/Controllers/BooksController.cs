
using Microsoft.AspNetCore.Mvc;

using BooksStoreApi.Models;
using BooksStoreApi.DataAccessLayer;

namespace BooksStoreApi.Controllers;

[ApiController]
[Route("api/[controller]/[Action]")]
public class BooksController: ControllerBase
{
    
    private readonly IBookRepository _bookRepository;

    public BooksController(IBookRepository booksRepository){
        _bookRepository = booksRepository;
    }
    
    [HttpGet]
    public async Task<List<Book>> GetAllBooks(){
       // return await _bookService.GetAsync();

       return await _bookRepository.GetAllRecords();

    }
    
    [HttpPost]
    public async Task<IActionResult> InsertBook(Book book){

          string responce = await _bookRepository.InsertBook(book);
          return Ok(responce);

    }

    [HttpGet]
    public async Task<IActionResult> GetBookById([FromQuery] string Id){

       
       var responce = await _bookRepository.GetBookById(Id);

       if(responce is null){
             return NotFound("No Book Found with this Id");
       }

       return Ok(responce);
       
    }
}
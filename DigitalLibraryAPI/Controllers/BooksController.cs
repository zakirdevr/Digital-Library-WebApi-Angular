using DigitalLibraryAPI.Models;
using DigitalLibraryAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository = null;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromBody] BookModel bookModel)
        {
            int id = await _bookRepository.AddBookAsync(bookModel);
            return CreatedAtAction(nameof(GetBookById), new {id=id, 
                controller="Books" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook ([FromRoute] int id, 
            [FromBody] BookModel bookModel) 
        {
            await _bookRepository.UpdateBookAsync(id, bookModel);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookPatch([FromRoute] int id,
                                             [FromBody] JsonPatchDocument bookModel)
        {
            await _bookRepository.UpdateBookPatchAsync(id, bookModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
            return Ok();
        }
    }
}

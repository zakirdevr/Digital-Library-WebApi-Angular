using DigitalLibraryAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalLibraryAPI.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBookByIdAsync(int bookId);
        Task<int> AddBookAsync(BookModel bookModel);
        Task UpdateBookAsync(int bookId, BookModel bookModel);
        Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel);
        Task DeleteBookAsync(int bookId);
    }
}

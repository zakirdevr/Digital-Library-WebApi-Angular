using AutoMapper;
using DigitalLibraryAPI.Data;
using DigitalLibraryAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalLibraryAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _bookContext = null;
        private readonly IMapper _mapper = null;
        public BookRepository(BookContext bookContext, IMapper mapper)
        {
            _bookContext = bookContext;
            _mapper = mapper;
        }

        //GET
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            //var records =await  _bookContext.Books.Select(x=> new BookModel() {
            //   Id= x.Id,
            //   Title=x.Title,
            //   Description=x.Description
            //}).ToListAsync();

            //return records;

            var records = await _bookContext.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(records);
        }

        //GET single item
        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            //var record = await _bookContext.Books
            //.Where(x=> x.Id==bookId)
            //.Select(x => new BookModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description
            //}).FirstOrDefaultAsync();

            //return record;

            var record = await _bookContext.Books.FindAsync(bookId);
            return _mapper.Map<BookModel>(record);
        }

        //POST
        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                Title = bookModel.Title,
                Description = bookModel.Description,
                Author=bookModel.Author,
                TotalPage=bookModel.TotalPage
            };

            await _bookContext.Books.AddAsync(book);
            await _bookContext.SaveChangesAsync();
            
            return book.Id;
        }

        //PUT
        public async Task UpdateBookAsync(int bookId, BookModel bookModel)
        {
            //var book = await _bookContext.Books.FindAsync(bookId);
            //if(book != null)
            //{
            //    book.Title = bookModel.Title;
            //    book.Description = bookModel.Description;
            //    await _bookContext.SaveChangesAsync();
            //}


            var book = new Books()
            {
                Id= bookId,
                Title = bookModel.Title,
                Description = bookModel.Description,
                Author = bookModel.Author,
                TotalPage = bookModel.TotalPage
            };

            _bookContext.Books.Update(book);
            await _bookContext.SaveChangesAsync();


        }

        //PATCH
        public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
        {
            var book = await _bookContext.Books.FindAsync(bookId);
            if(book != null)
            {
                bookModel.ApplyTo(book);
                await _bookContext.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int bookId)
        {
            //var book = await _bookContext.Books.Where(x => x.Title == "").FirstOrDefaultAsync();
            var book = new Books() { Id = bookId };
            
            _bookContext.Books.Remove(book);
            await _bookContext.SaveChangesAsync();

        }
    }
}

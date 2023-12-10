using Microsoft.EntityFrameworkCore;
using MyLibrary.Models;

namespace MyLibrary.Data.Services
{
    public class BookService : IBookServices
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public object Books { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add(Books Book)
        {
            _context.Books.Add(Book);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var result = _context.Books.FirstOrDefault(x => x.Id == Id);
            _context.Books.Remove(result);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Books>> GetAll()
        {
            var result = await _context.Books.ToListAsync();
            return result;
        }

        public IEnumerable<string> GetBooksBySearchString(string searchString)
        {
            throw new NotImplementedException();
        }

        public string? GetBooksBysearchString(string searchsearchString)
        {
            throw new NotImplementedException();
        }

        public Books GetById(int Id)
        {
           var result = _context.Books.FirstOrDefault(x => x.Id == Id);
            return result;
        }

        public Books Update(int Id, Books newBook)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Books books)
        {
            _context.Update(books);
            _context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
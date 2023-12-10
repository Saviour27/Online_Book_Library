using MyLibrary.Models;
using System.Security.Cryptography;

namespace MyLibrary.Data.Services
{
    public interface IBookServices
    {
        object Books { get; set; }

        Task <IEnumerable<Books>> GetAll();

        Books GetById(int Id);

        void Add(Books Book);

        void Delete(int Id);

        Task UpdateAsync(Books books);
    }
}
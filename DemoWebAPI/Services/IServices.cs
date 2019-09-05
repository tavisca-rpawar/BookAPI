using DemoWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPI.Services
{
    public interface IServices
    {
        List<Book> GetBook();
        Book GetBookById(int id);
        void AddBook(Book newBook);
        void UpdateBook(int id, Book newBook);
        void DeleteBookByID(int id);
    }
}

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
        int AddBook(Book newBook);
        int UpdateBook(int id, Book newBook);
        int DeleteBookByID(int id);
    }
}

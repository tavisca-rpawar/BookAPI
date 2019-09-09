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
        Response GetBookById(int id);
        Response AddBook(Book newBook);
        Response UpdateBook(int id, Book newBook);
        Response DeleteBookByID(int id);
    }
}

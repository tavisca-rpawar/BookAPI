using System;
using System.Collections.Generic;
using System.Linq;
using DemoWebAPI.MyData;
using System.Threading.Tasks;
using DemoWebAPI.Model;

namespace DemoWebAPI.Services
{
    public class BookServices : IServices
    {
        BookData bookData = new BookData();
        public List<Book> GetBook()
        {
            return bookData.GetBook();
        }
        public Book GetBookById(int id)
        {
            List<Book> books = bookData.GetBook();
            return books.Where(book => book.Id == id).FirstOrDefault();
        }
        public void AddBook(Book newBook)
        {
            bookData.AddBook(newBook);
        }
        public void UpdateBook(int id,Book newBook)
        {
            int i;
            List<Book> books = bookData.GetBook();
            for(i = 0; i<books.Count; i++)
            {
                if(books[i].Id == id)
                    bookData.UpdateById(i, newBook);
            }         
        }

        public void DeleteBookByID(int id)
        {
            int i;
            List<Book> books = bookData.GetBook();
            for (i = 0; i < books.Count; i++)
            {
                if (books[i].Id == id)
                    bookData.DeleteById(books[i]);
            }
        }
        
    }
}

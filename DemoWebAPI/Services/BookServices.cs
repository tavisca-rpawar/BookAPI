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
        public int AddBook(Book newBook)
        {
            List<Book> books = bookData.GetBook();
            if (newBook.Id < 0)
                return -1;
            if (books.Where(book => book.Id == newBook.Id).FirstOrDefault() != null)
                return 0;
            bookData.AddBook(newBook);
            return 1;
        }
        public int UpdateBook(int id,Book newBook)
        {
            int i;
            if (id < 0 || newBook.Id < 0)
                return -1;
            List<Book> bookList = bookData.GetBook();
            for (i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].Id == id)
                {
                    bookData.UpdateById(i, newBook);
                    return 1;
                }
            }
            return 0;      
        }

        public int DeleteBookByID(int id)
        {
            int i;
            if (id < 0)
                return -1;
            List<Book> books = bookData.GetBook();
            for (i = 0; i < books.Count; i++)
            {
                if (books[i].Id == id)
                {
                    bookData.DeleteById(books[i]);
                    return 1;
                }
            }
            return 0;
        }
        
    }
}

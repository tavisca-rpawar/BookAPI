using System;
using System.Collections.Generic;
using System.Linq;
using DemoWebAPI.MyData;
using System.Threading.Tasks;
using DemoWebAPI.Model;
using System.Text.RegularExpressions;

namespace DemoWebAPI.Services
{
    public class BookServices : IServices
    {
        private BookData bookData = new BookData();
        private bool checkBookDetails(string input)
        {
            string pattern = "^[a-zA-Z ]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }

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
            List<Book> bookList = bookData.GetBook();
            if (newBook.Id < 0)
                return -1;
            if (bookList.Where(book => book.Id == newBook.Id).FirstOrDefault() != null)
                return 0;
            bookData.AddBook(newBook);
            return 1;
        }
        public int UpdateBook(int id,Book newBook)
        {           
            if (id < 0 || newBook.Id < 0)
                return -1;
            List<Book> bookList = bookData.GetBook();
            var index = bookList.IndexOf(bookList.Find((book) => book.Id == id));
            if (index == -1)
                return 0;      
            bookData.UpdateById(id, newBook);
            return 1;    
        }

        public int DeleteBookByID(int id)
        {
            if (id < 0)
                return -1;
            List<Book> bookList = bookData.GetBook();
            var index = bookList.IndexOf(bookList.Find((book) => book.Id == id));
            if (index == -1)
                return 0;
            bookData.DeleteById(bookList[id]);
            return 1;  
        }
        
    }
}

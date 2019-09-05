using DemoWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPI.MyData
{
    public class BookData
    {

        static List<Book> bookList = new List<Book>();
        public void AddBook(Book newBook)
        {
            bookList.Add(newBook);
        }
        public List<Book> GetBook()
        {
            return bookList;
        }
        public void UpdateById(int index, Book newBook)
        {
            bookList[index] = newBook;
        }
        public void DeleteById(Book book)
        {
            bookList.Remove(book);
        }
    }
}

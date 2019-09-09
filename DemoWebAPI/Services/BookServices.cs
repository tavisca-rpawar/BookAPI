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
        private Response response = new Response();

        private string Format(string input)
        {
            input = input.Replace("\t", " ");
            while (input.IndexOf("  ") >= 0)
            {
                input = input.Replace("  ", " ");
            }
            return input;
        }
        private bool isInputStringValid(string input)
        {
            input = Format(input);
            string pattern = "^[a-zA-Z ]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }
        private string ValidateId(int id)
        {
            List<Book> bookList = bookData.GetBook();
            if (id < 0)
                return "Id should not be negative";
            if (bookList.Where(book => book.Id == id).FirstOrDefault() != null)
                return "Id Already exists";
            
            return null;
        }
        private bool isPriceValid(double price)
        {
            if (price < 0)
                return false;
            return true;
        }
        private bool ValidateBookDetails(Book book)
        {
            if(ValidateId(book.Id) !=null )
                response.AddErrors(ValidateId(book.Id) );

            if (isInputStringValid(book.Title) == false)
                response.AddErrors("Title is Invalid ");

            if (isInputStringValid(book.Author) == false)
                response.AddErrors("Author name is Invalid ");

            if (isInputStringValid(book.Category) == false)
                response.AddErrors("Category is Invalid ");

            if (isPriceValid(book.Price) == false)
                response.AddErrors("Price should not be negative ");

            if (response.getErrorList().Count > 0)
                return true;
            return false;
        }
        public List<Book> GetBook()
        {
            return bookData.GetBook();
        }
        public Response GetBookById(int id)
        {
            List<Book> bookList = bookData.GetBook();
            if (id < 0)
                response.AddErrors("Id should not be negative");
            else
            {
                var book = bookList.Where(x => x.Id == id).FirstOrDefault();
                if (book == null)
                    response.AddErrors("Invalid Id");
                else
                    response.book = book;
            }  
            return response;
        }
        public Response AddBook(Book newBook)
        {
            if(ValidateBookDetails(newBook) == false)
            {
                bookData.AddBook(newBook);
                response.book = newBook;
            }
            return response;
        }
        public Response UpdateBook(int id,Book newBook)
        {
            List<Book> bookList = bookData.GetBook();
            if (id < 0)
                response.AddErrors("Id should not be negative");
            else
            {
                if (ValidateBookDetails(newBook) == false || (response.getErrorList().Count == 1 && response.getErrorList().Contains("Id Already exists")))
                {
                    var index = bookList.IndexOf(bookList.Find((book) => book.Id == id));
                    if (index == -1)
                        response.AddErrors("Invalid Id");
                    else
                    {
                        bookData.UpdateById(index, newBook);
                        response.book = newBook;
                    }
                }
            }
            return response;
        }

        public Response DeleteBookByID(int id)
        {
            List<Book> bookList = bookData.GetBook();
            var index = bookList.IndexOf(bookList.Find((book) => book.Id == id));
            if (index == -1)
                response.AddErrors("Id desnot Exist");
            else
            {
                //response.book = bookList[index];
                bookData.DeleteById(bookList[index]);
            }
            return response;  
        }
        
    }
}

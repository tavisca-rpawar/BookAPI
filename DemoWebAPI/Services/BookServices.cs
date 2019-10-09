using System;
using System.Collections.Generic;
using System.Linq;
using DemoWebAPI.MyData;
using System.Threading.Tasks;
using DemoWebAPI.Model;
using System.Text.RegularExpressions;
using FluentValidation.Results;

namespace DemoWebAPI.Services
{
    public class BookServices : IServices
    {
        private BookData bookData = new BookData();
        private Response response = new Response();
        BookValidation validator = new BookValidation();
        ValidationResult validationResult;
        bool success;
        //var validator = new BookValidator();
        //ValidationResult validationResult = validator.Validate(book);
        //bool success = validationResult.IsValid;
        private string ValidateId(int id)
        {
            List<Book> bookList = bookData.GetBook();
            if (bookList.Where(book => book.Id == id).FirstOrDefault() != null)
                return "Id Already exists";
            return null;
        }
        public List<Book> GetBook()
        {
            return bookData.GetBook();
        }
        public Response GetBookById(int id)
        {
            List<Book> bookList = bookData.GetBook();
            var book = bookList.Where(x => x.Id == id).FirstOrDefault();
            if (book == null)
                response.AddErrors("Invalid Id");
            else
                response.book = book;
            return response;
        }
        public Response AddBook(Book newBook)
        {
            validationResult = validator.Validate(newBook);
            success = validationResult.IsValid;
            if (ValidateId(newBook.Id) == null || success == false)
            {
                bookData.AddBook(newBook);
                response.book = newBook;
            }
            else
                response.AddErrors(ValidateId(newBook.Id));
            return response;
        }
        public Response UpdateBook(int id, Book newBook)
        {
            validationResult = validator.Validate(newBook);
            success = validationResult.IsValid;
            if(success == false)
            {
                List<Book> bookList = bookData.GetBook();
                var index = bookList.IndexOf(bookList.Find((book) => book.Id == id));
                if (index == -1)
                    response.AddErrors("Invalid Id");
                else
                {
                    bookData.UpdateById(index, newBook);
                    response.book = newBook;
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

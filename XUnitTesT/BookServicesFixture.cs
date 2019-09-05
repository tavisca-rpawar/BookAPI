using System;
using Xunit;
using DemoWebAPI.Services;
using DemoWebAPI.Model;
using System.Collections.Generic;

namespace XUnitTest
{
    public class BookServicesFixture
    {
        BookServices bookServices = new BookServices();
        Book expected = new Book { Id = 0, Title = "The Monk Who sold his Ferrari", Author = "Robin Sharma", Category = "Fiction" };
        [Fact]
        public void GetBook_should_return_list_of_books_test()
        {
            bookServices.AddBook(expected);
            Assert.Contains(expected, bookServices.GetBook());
        }
        [Fact]
        public void GetBookById_should_return_book_with_specific_id_test()
        {
            int id = 0;
            bookServices.AddBook(expected);
            Book actual = bookServices.GetBookById(id);
            Assert.Equal(expected, actual);
            
        }
        [Fact]
        public void AddBook_should_add_book_in_bookData_test()
        {
            bookServices.AddBook(expected);
            Assert.Contains(expected, bookServices.GetBook());
        }
        [Fact]
        public void UpdatedBook_should_update_book_in_bookData_test()
        {
            int id = 0;
            bookServices.AddBook(expected);
            bookServices.UpdateBook(id, expected);
            Assert.Contains(expected, bookServices.GetBook());
        }
        [Fact]
        public void DeleteBookByID_should_delete_book_from_bookData_test()
        {
            int id = 0;
            bookServices.AddBook(expected);
            bookServices.DeleteBookByID(id);
            Assert.Null(bookServices.GetBookById(id));
        }
    }
}

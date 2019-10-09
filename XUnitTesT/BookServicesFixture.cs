using System;
using Xunit;
using DemoWebAPI.Services;
using DemoWebAPI.Model;
using System.Collections.Generic;
using DemoWebAPI;
using FluentAssertions;

namespace XUnitTest
{
    public class BookServicesFixture
    {
        private BookServices bookService = new BookServices();
        [Fact]
        public void GetBookById_should_return_book_with_specific_id_test()
        {
            var id = 201;
            var actual = bookService.GetBookById(id).book;
            var expected = bookService.GetBook().Find((book) => book.Id == id);
            actual.Should().BeEquivalentTo(expected);
        }
        [Fact]
        public void GetBookById_with_negative_id_test()
        {
            var id = -300;
            var response = bookService.GetBookById(id); ;
            var actual = response.getErrorList();
            var expected = new List<string>() { "Id should not be negative" };
            actual.Should().BeEquivalentTo(expected);
        }
        [Fact]
        public void GetBookById_with_invalid_id_test()
        {
            var id = 400;
            var response = bookService.GetBookById(id); ;
            var actual = response.getErrorList();
            var expected = new List<string>() { "Invalid Id" };
            actual.Should().BeEquivalentTo(expected);
        }
        [Fact]
        public void AddBook_should_add_book_in_bookData_test()
        {
            var actual = new Book(203, "the cllimex", "Alex", "Fiction", 500);
            bookService.AddBook(actual);
            var expected = bookService.GetBook();
            expected.Should().ContainEquivalentOf(actual);
        }
        
        [Fact]
        public void AddBook_with_invalid_inputs_should_return_list_of_errors_test()
        {
            var newBook = new Book(-1, "", "", "", -111);
            var response = bookService.AddBook(newBook);
            var actual = response.getErrorList();
            var expected = new List<string>() { "Id should not be negative",
                                                         "Title is Invalid ",
                                                        "Author name is Invalid ",
                                                        "Category is Invalid ",
                                                        "Price should not be negative "};
            actual.Should().BeEquivalentTo(expected);
        }
        [Fact]
        public void UpdatedBook_should_update_book_in_bookData_test()
        {
            int id = 101;
            int newId = 100;
            var updatedBook = new Book(newId, "Randomness", "Katoch", "Action", 0);
            bookService.UpdateBook(id, updatedBook);
            var expected = bookService.GetBookById(newId).book;
            var actual = updatedBook;
            actual.Should().BeEquivalentTo(expected);
        }
        [Fact]
        public void UpdatedBook_with_invalid_id_test()
        {
            int id = 101;
            int newId = 20;
            var updatedBook = new Book(newId, "Randomness", "Katoch", "Action", 0.99);
            var response = bookService.UpdateBook(id, updatedBook);
            var expected = response.getErrorList();
            var actual = new List<string>() { "Invalid Id" };
            actual.Should().BeEquivalentTo(expected);
        }
        [Fact]
        public void UpdatedBook_with_negative_id_test()
        {
            int id = 101;
            int newId = -200;
            var updatedBook = new Book(newId, "Randomness", "Katoch", "Action", 0.99);
            var response = bookService.UpdateBook(id, updatedBook);
            var expected = response.getErrorList();
            var actual = new List<string>() { "Id should not be negative" };
            actual.Should().BeEquivalentTo(expected);
        }

     
    }
}

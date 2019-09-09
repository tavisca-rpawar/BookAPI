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
        BookServices bookService = new BookServices();
        [Fact]
        public void GetBook_should_return_list_of_books_test()
        {
            var actual = bookService.GetBook();
            var expected = new List<Book> {new Book(101,"the monk who sold his ferrari","Robin Sharma","Non Fiction",200),
                                            new Book(201,"the cllimex","Alex","Fiction",500)};
            actual.Should().BeEquivalentTo(expected);
            
        }
        [Fact]
        public void AddBook_should_add_book_in_bookData_test()
        {
        }
        //    [Fact]
        //    public void AddBook_should_add_book_in_bookData_test()
        //    {
        //        var expected = 1;
        //        Add_books_in_list();
        //        var newBook = new Book(3, "Random", "Katoch", "Action",0);
        //        var actual =  bookServices.AddBook(newBook);
        //        Assert.Equal(expected, actual);
        //    }
        //[Fact]
        //public void AddBook_should_add_book_in_bookData_test()
        //{
        //    Add_books_in_list();
        //    var actual = new Book(3, "Random", "Katoch", "Action", 0);
        //    var expected = bookList;
        //    Assert.Contains(expected, actual);

        //}
        //{
        //    BookServices bookServices = new BookServices();
        //    List<Book> bookList = new List<Book>() { new Book( 0, "The Monk Who sold his Ferrari", "Robin Sharma", "Fiction" ,200),
        //                                             new Book( 1, "Revolution 2020", "Chetan Bhagat", "Fiction",600 ),
        //                                             new Book( 2, "Twilight", "Myle", "action",70 )};

        //    [Fact]
        //    public void GetBook_should_return_list_of_books_test()
        //    {
        //        Add_books_in_list();
        //        var actual = bookServices.GetBook();
        //        var expected = bookList;
        //        Assert.Equal(expected, actual);
        //    }
        //    [Fact]
        //    public void GetBook_should_return_empty_list_when_list_is_empty_test()
        //    {
        //        var actual = bookServices.GetBook();
        //        var expected = new List<Book>();
        //        Assert.Equal(expected, actual);
        //    }
        //    [Fact]
        //    public void GetBookById_should_return_book_with_specific_id_test()
        //    {
        //        var id = 2;
        //        Add_books_in_list();
        //        var actual = bookServices.GetBookById(id);
        //        var expected = bookList;
        //        Assert.Equal(expected.Find((book) => book.Id == id), actual);

        //    }
        //    [Fact]
        //    public void GetBookById_with_negative_Id_test()
        //    {
        //        var id = -1;
        //        Add_books_in_list();
        //        var actual = bookServices.GetBookById(id);
        //        Assert.Null(actual);
        //    }
        //    [Fact]
        //    public void GetBookById_with_invalid_Id_test()
        //    {
        //        var id = 20;
        //        Add_books_in_list();
        //        var actual = bookServices.GetBookById(id);
        //        Assert.Null(actual);
        //    }
        //    [Fact]
        //    public void AddBook_should_add_book_in_bookData_test()
        //    {
        //        var expected = 1;
        //        Add_books_in_list();
        //        var newBook = new Book(3, "Random", "Katoch", "Action",0);
        //        var actual =  bookServices.AddBook(newBook);
        //        Assert.Equal(expected, actual);
        //    }
        //    [Fact]
        //    public void AddBook_with_negative_id_test()
        //    {
        //        var expected = -1;
        //        Add_books_in_list();
        //        var newBook = new Book(-1, "Random", "Katoch", "Action",0);
        //        var actual = bookServices.AddBook(newBook);
        //        Assert.Equal(expected, actual);
        //    }
        //    [Fact]
        //    public void AddBook_with_already_existing_id_test()
        //    {
        //        var expected = 0;
        //        Add_books_in_list();
        //        var newBook = new Book(1, "Random", "Katoch", "Action",0);
        //        var actual = bookServices.AddBook(newBook);
        //        Assert.Equal(expected, actual);
        //    }

        //    [Fact]
        //    public void UpdatedBook_should_update_book_in_bookData_test()
        //    {
        //        int id = 2;
        //        Add_books_in_list();
        //        var updatedBook = new Book(id, "Randomness", "Katoch", "Action",0);
        //        var actual = bookServices.UpdateBook(id, updatedBook);
        //        var expected = 1;
        //        Assert.Equal(expected, actual);
        //    }
        //    [Fact]
        //    public void UpdatedBook_with_invalid_id_test()
        //    {
        //        int id = 20;
        //        Add_books_in_list();
        //        var updatedBook = new Book(2, "Randomness", "Katoch", "Action", 0.99);
        //        var actual = bookServices.UpdateBook(id, updatedBook);
        //        var expected = 0;
        //        Assert.Equal(expected, actual);
        //    }
        //    [Fact]
        //    public void UpdatedBook_with_negative_id_test()
        //    {
        //        int id = -10;
        //        Add_books_in_list();
        //        var updatedBook = new Book(2, "Randomness", "Katoch", "Action", 0.88);
        //        var actual = bookServices.UpdateBook(id, updatedBook);
        //        var expected = -1;
        //        Assert.Equal(expected, actual);
        //    }
    }
}

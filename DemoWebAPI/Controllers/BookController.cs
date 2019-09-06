using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebAPI.MyData;
using DemoWebAPI.Services;
using DemoWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        BookServices bookService = new BookServices();
        // GET: api/Home
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            List<Book> bookList = bookService.GetBook();
            if(bookList == null)
            {
                return NoContent();
            }
            return Ok(bookList);
        }
        // GET: api/Home/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<IEnumerable<Book>> Get(int id)
        {
            Book book = bookService.GetBookById(id);
            if (book == null)
                return NoContent();
            return Ok(book);
        }

        // POST: api/Home
        [HttpPost]
        public ActionResult<string> Post([FromBody] Book book)
        {
            var status = bookService.AddBook(book);
            if (status == -1)
                return BadRequest("Negative Id cannot be accepted");
            if (status == 0)
                return BadRequest("Id Already exists");

            return "Sucessfully Added in BookData having ID:" + book.Id;
            
        }

        // PUT: api/Home/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] Book newBook)
        {
            var status = bookService.UpdateBook(id, newBook);
            if(status == -1)
                return BadRequest("Negative Id cannot be accepted");
            if (status == 0)
                return BadRequest("Id Doesnot exist");
            return "Sucessfully Udated having ID:" + newBook.Id;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            var status = bookService.DeleteBookByID(id);
            if (status == -1)
                return BadRequest("Negative Id is not available");
            if (status == 0)
                return BadRequest("Id Doesnot exist");
            return "Sucessfully Deleted having ID:" + id;
        }
    }
}

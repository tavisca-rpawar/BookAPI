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
            if (bookList == null)
            {
                return NoContent();
            }
            return Ok(bookList);
        }
        // GET: api/Home/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<IEnumerable<Book>> Get(int id)
        {
            var response = bookService.GetBookById(id);
            if (response.getErrorList().Count > 0)
                return BadRequest(response.getErrorList());
            return Ok(response.book);
        }

        // POST: api/Home
        [HttpPost]
        public ActionResult<IEnumerable<string>> Post([FromBody] Book book)
        {
            var response = bookService.AddBook(book);
            if (response.getErrorList().Count > 0)
                return BadRequest(response.getErrorList());
            return Ok("Books Added Successfully having ID : " + response.book.Id);
        }

        // PUT: api/Home/5
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<string>> Put(int id, [FromBody] Book newBook)
        {
            var response = bookService.UpdateBook(id, newBook);
            if (response.getErrorList().Count > 0)
                return BadRequest(response.getErrorList());
            return Ok("Books Updated Successfully having ID : " + response.book.Id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<string>> Delete(int id)
        {
            var response = bookService.DeleteBookByID(id);
            if (response.getErrorList().Count > 0)
                return BadRequest(response.getErrorList());
            return Ok("Books Deleted Successfully having ID : " +id);
        }
    }
}

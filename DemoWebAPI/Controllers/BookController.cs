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
        public Book Get(int id)
        {
            return bookService.GetBookById(id);
        }

        // POST: api/Home
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            bookService.AddBook(value);
        }

        // PUT: api/Home/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book newBook)
        {
            bookService.UpdateBook(id, newBook);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bookService.DeleteBookByID(id);
        }
    }
}

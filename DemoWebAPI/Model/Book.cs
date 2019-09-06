using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPI.Model
{

    public class Book
    {
        public Book(int Id, string Title, string Author, string Category)
        {
            this.Id = Id;
            this.Title = Title;
            this.Author = Author;
            this.Category = Category;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
    }
}

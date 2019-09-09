using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPI.Model
{

    public class Book
    {
        public Book(int Id, string Title, string Author, string Category, double Price)
        {
            this.Id = Id;
            this.Title = Title;
            this.Author = Author;
            this.Category = Category;
            this.Price = Price;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }

    }
}

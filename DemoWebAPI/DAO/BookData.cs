using DemoWebAPI.Model;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace DemoWebAPI.MyData
{
    public class BookData
    {

        public List<Book> BookList { get; set; }
        public string _jsonFilePath = @".\JSON\BookList.json";
        private void JsonSerializer()
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            using (StreamWriter stream = new StreamWriter(_jsonFilePath))
            using (JsonWriter writer = new JsonTextWriter(stream))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();
                writer.WritePropertyName("BookList");
                jsonSerializer.Serialize(writer, BookList);
                writer.WriteEndObject();
            }
        }
        private void JsonDeserializer()
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            using (StreamReader reader = File.OpenText(_jsonFilePath))
            {
                BookData bookData = (BookData)jsonSerializer.Deserialize(reader, typeof(BookData));
                if (bookData != null)
                    BookList = bookData.BookList;
            }
        }
        public void AddBook(Book newBook)
        {
            JsonDeserializer();
            if (BookList == null)
                BookList = new List<Book>();
            BookList.Add(newBook);
            JsonSerializer();
        }
        public List<Book> GetBook()
        {
            JsonDeserializer();
            return BookList;
        }
        public void UpdateById(int index, Book newBook)
        {
            BookList[index] = newBook;
            JsonSerializer();
        }
        public void DeleteById(Book book)
        {
            BookList.Remove(book);
            JsonSerializer();
        }
    }
}

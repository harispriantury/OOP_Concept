using EnigpusApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigpusApp.Services.Inventory
{
    public class InventoryServiceImpl : InventoryService
    {
        private List<Book> books = new List<Book>();
        public InventoryServiceImpl()
        {
            Magazine magazine = new Magazine("code1", "Kenanglah Aku", 2022, "Asrin");
            Magazine magazine2 = new Magazine("code2", "Kenanglah Dia", 2023, "Asrin Asrin");
            books.Add(magazine);
            books.Add (magazine2);
        }
        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void DeleteBook(string id)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllBook()
        {
            return books;
        }

        public List<Book> SearchBook(string title)
        {
            List<Book> list = new List<Book>();
            list = books.FindAll(x => x.getTitle().Equals(title));
            return list;
        }

        public Book updateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}

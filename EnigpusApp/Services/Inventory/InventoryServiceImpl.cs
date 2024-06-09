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
            Magazine magazine = new Magazine("code1", "Judi", 2022, "Asrin");
            Novel novel = new Novel("code2", "Slot", "Jihad",2023, "solehudin");
            books.Add(magazine);
            books.Add (novel);
        }
        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void DeleteBook(Book book)
        {
            books.Remove(book);
        }

        public List<Book> GetAllBook()
        {
            return books;
        }

        public Book SearchBook(string title)
        {
            Book? book = books.Find(x => x.getTitle().ToLower() == title.ToLower());
            return book;
        }

        public void updateBook(Book book)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].getTitle() == book.getTitle())
                {
                    books[i] = book;
                }
            }
        }

        
    }
}

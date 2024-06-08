using EnigpusApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigpusApp.Services.Inventory
{
    public interface InventoryService
    {
        void AddBook(Book book);
        List<Book> SearchBook(String title);
        List<Book> GetAllBook();
        Book updateBook(Book book);
        void DeleteBook(String id);

    }
}

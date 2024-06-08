using EnigpusApp.Models;
using EnigpusApp.Services.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace EnigpusApp.Views
{
    public class StartUpMenu
    {
        private InventoryServiceImpl _inventoryService;
        public StartUpMenu(InventoryServiceImpl inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public void Start()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("<---------------------------------------------------->");
                Console.WriteLine("<---------------------------------------------------->");
                Console.WriteLine("<----------------- Welcome To Enigpus --------------->");
                Console.WriteLine("< 1. See List of all Books                           >");
                Console.WriteLine("< 2. Search Books by Title                           >");
                Console.WriteLine("< 3. Add New Book                                    >");
                Console.WriteLine("< 4. Update Book                                     >");
                Console.WriteLine("< 5. Delete Book                                     >");
                Console.WriteLine("< 6. Exit                                            ");
                Console.WriteLine("<----------------------------------------------------->");
                Console.Write("< Select Menu : ");
                var code = Console.ReadLine();
                if (code != null && code != "") {
                    switch (code.Trim())
                    {
                        case "1":
                            GetAllBooks(); break;
                        case "2":
                            SearchBookByTitle(code); break;
                        case "3":
                            AddNewBook(); break;
                        //case "4":
                        //    UpdateBookByTitle(code); break;
                        //case "5":
                        //    DeleteBook(code); break;
                        case "6":
                            Console.WriteLine("See yuuuu");
                            isRunning = false; break;
                        default:
                            Console.WriteLine("its wrong choice");
                            break;




                    }
                }
               
            }
        }

        private void GetAllBooks()
        {
            List<Book> books = _inventoryService.GetAllBook();
            if (books.Count > 0)
            {
                Print(books);
            }
            else
            {
                Console.WriteLine("Inventory is empty");
            }

        }

        private void SearchBookByTitle(String title)
        {
            Console.Write("Input Title : ");
            string input = Console.ReadLine();
            List<Book> filtered = _inventoryService.SearchBook(input.Trim());
            if (filtered.Count > 0)
            {
                Print(filtered);
            }
            else
            {
                Console.WriteLine("Inventory with name " + input + " is not found !");
            }

        }

        private void AddNewBook()
        {

            Console.WriteLine("< 1. Magazine                          >");
            Console.WriteLine("< 2. Novel                             >");
            Console.Write("Select Type : ");
            var choise = Console.ReadLine();
            switch (choise.Trim())
            {
                case "1":
                    Console.Write("Input code :");
                    var code = Console.ReadLine();
                    Console.Write("Input Title :");
                    var title = Console.ReadLine();
                    Console.Write("Input Published Year :");
                    var publishedYear = Console.ReadLine();
                    int intYear = 0;
                    Console.Write("Input Publisher :");
                    var publisher = Console.ReadLine();

                    if (code == "" || title == "" || publishedYear == "" || publisher == "")
                    {
                        Console.WriteLine("input wrong validation");
                        return;
                    }
                    Magazine magazine = new Magazine(code, title, (int.TryParse(publishedYear, out intYear) == true ? intYear : 0), publisher);
                    _inventoryService.AddBook(magazine);
                    break;
                default:
                    Console.WriteLine("input is wrong format");
                    return;
            }

        }

        private void UpdateBook(Book book)
        {
            _inventoryService.updateBook(book);
        }

        private void DeleteBook(String code) {
            _inventoryService.DeleteBook(code);
        }

        private void Print(List<Book> books)
        {
            Console.WriteLine();
            int i = 1;
            foreach (var item in books)
            {
                Console.WriteLine(i + ". " + item.getTitle());
                i++;
            }
            Console.WriteLine();
        }

    } 
}

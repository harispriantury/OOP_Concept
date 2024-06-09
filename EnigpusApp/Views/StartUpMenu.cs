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
                var codeOption = Console.ReadLine();
                if (codeOption != null && codeOption!= "") {
                    switch (codeOption.Trim())
                    {
                        case "1":
                            GetAllBooks(); break;
                        case "2":
                            SearchBookByTitle(); break;
                        case "3":
                            AddNewBook(); break;
                        case "4":
                            UpdateBook(); break;
                        case "5":
                            DeleteBook(); break;
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

        private void SearchBookByTitle()
        {
            Console.Write("Input Title : ");
            string input = Console.ReadLine();
            Book filtered = _inventoryService.SearchBook(input.Trim());
            if (filtered != null)
            {
                List<Book> books = new List<Book> { filtered };
                Print(books);
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
                    CreateMagazine();
                    break;
                case "2":
                    CreateNovel();
                    break;
                default:
                    Console.WriteLine("input is wrong format");
                    return;
            }

        }

        private void CreateMagazine()
        {
            Console.WriteLine("Input Magazine");
            Console.Write("Input code :");
            string code = Console.ReadLine();
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
            Console.WriteLine("Success Created New Magazine");

        }

        private void CreateNovel()
        {
            Console.WriteLine("Input Novel");
            Console.Write("Input code :");
            string code = Console.ReadLine();
            Console.Write("Input Title :");
            var title = Console.ReadLine();
            Console.Write("Input Published Year :");
            string publishedYear = Console.ReadLine();
            int intYear = 0;
            Console.Write("Input Publisher :");
            var publisher = Console.ReadLine();
            Console.Write("Input Writer :");
            var writer = Console.ReadLine();

            if (code == "" || title == "" || publishedYear == "" || publisher == "" || writer == "")
            {
                Console.WriteLine("input wrong validation");
                return;
            }
            Novel novel = new Novel(code, title, publisher, (int.TryParse(publishedYear, out intYear) == true ? intYear : 0), writer);
            _inventoryService.AddBook(novel);
            Console.WriteLine("Success Created New novel");
        }

        private void UpdateBook()
        {

            Console.WriteLine("Update Book");
            Console.Write("Input Title :");
            string searchTitle = Console.ReadLine();
            Book? data = _inventoryService.SearchBook(searchTitle);
            if (data == null) {
                Console.WriteLine("Book not found");
                return;
            }

            if (data.GetType() == typeof(Magazine))
            {
                Magazine selected = (Magazine)data;
                Console.WriteLine("Update Magazine");
                Console.Write("Input Title :");
                var title = Console.ReadLine();
                Console.Write("Input Published Year :");
                var publishedYear = Console.ReadLine();
                int intYear = 0;
                Console.Write("Input Publisher :");
                var publisher = Console.ReadLine();

                if (title == "" || publishedYear == "" || publisher == "")
                {
                    Console.WriteLine("input update wrong validation");
                    return;
                }
                selected.Title = title;
                selected.Publisher = publisher;
                if (int.TryParse(publisher, out intYear)) { 
                     selected.PublishYear = intYear;
                }
                _inventoryService.updateBook(selected);
                Console.WriteLine("Success Update Magazine");

            }
            else
            {
                Novel selected = (Novel)data;
                Console.WriteLine("Update Novel");
                Console.Write("Input Title :");
                var title = Console.ReadLine();
                Console.Write("Input Published Year :");
                var publishedYear = Console.ReadLine();
                int intYear = 0;
                Console.Write("Input Publisher :");
                var publisher = Console.ReadLine();
                Console.Write("Input writer :");
                var writer = Console.ReadLine();

                if (title == "" || publishedYear == "" || publisher == "" || writer == "")
                {
                    Console.WriteLine("input update wrong validation");
                    return;
                }
                selected.Title = title;
                selected.Publisher = publisher;
                selected.writer = writer;
                if (int.TryParse(publisher, out intYear))
                {
                    selected.publishYear = intYear;
                }
                _inventoryService.updateBook(selected);
                Console.WriteLine("Success Update Novel");

            }
        }

        private void DeleteBook() {
            Console.Write("Input title you want to delete :");
            var title = Console.ReadLine();

            Book book = _inventoryService.SearchBook(title);
            if (book == null)
            {
                Console.WriteLine("book not found");
                return;
            }
            Console.Write("Are You sure want to delete this book y/n ? ");
            string confirm = Console.ReadLine();
            switch (confirm.ToLower().Trim())
            {
                case "y":
                    _inventoryService.DeleteBook(book);
                    Console.WriteLine("Success delete book");
                    break;
                case "n":
                    return;
                    break;
                default:
                    Console.WriteLine("wrong choice");
                    return;
                    break;
            }
        }

        private void Print(List<Book> books)
        {
            Console.WriteLine();
            int i = 1;
            foreach (var item in books)
            {
                if (item.GetType() == typeof(Magazine))
                {
                    Magazine magazine = (Magazine)item;
                    Console.WriteLine(i + ". Type : " + "Magazine");
                    Console.WriteLine("Title : " + magazine.getTitle());
                    Console.WriteLine("Code : " + magazine.Code);
                    Console.WriteLine("Title : " + magazine.Title);
                    Console.WriteLine("Publish Year :" + magazine.PublishYear);
                    Console.WriteLine("Publisher :" + magazine.Publisher);
                }
                else
                {
                    Novel novel = (Novel)item;
                    Console.WriteLine(i + ". Type : " + "Novel");
                    Console.WriteLine("Title : " + novel.getTitle());
                    Console.WriteLine("Code : " + novel.Code);
                    Console.WriteLine("Title : " + novel.Title);
                    Console.WriteLine("Publish Year :" + novel.publishYear);
                    Console.WriteLine("Publisher :" + novel.Publisher);
                    Console.WriteLine("Writer :" + novel.writer);
                }
                i++;
                Console.WriteLine("<------------------------------------------------------>");
            }
            Console.WriteLine();
        }

    } 
}

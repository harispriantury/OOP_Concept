

using EnigpusApp.Models;
using EnigpusApp.Services.Inventory;
using EnigpusApp.Views;

public class Program
{
    public static void Main(string[] args)
    {
        InventoryServiceImpl service = new InventoryServiceImpl();
        StartUpMenu startUpMenu = new StartUpMenu(service);
        startUpMenu.Start();
    }
}
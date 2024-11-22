// See https://aka.ms/new-console-template for more information
using System;

namespace MenuOptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please select a menu option: help, add, delete, edit, find, list");
            Console.Write("Enter your option: ");
            string userOption = Console.ReadLine().ToLower(); // Convert to lowercase for easier matching

            // Call the menu options method
            ShowMenuOption(userOption);

            // Wait for user to press a key before closing
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        // Method to handle menu options
        static void ShowMenuOption(string option)
        {
            switch (option)
            {
                case "help":
                    Console.WriteLine("Help: This menu allows you to manage your items. You can add, delete, edit, find, or list items.");
                    break;

                case "add":
                    Console.WriteLine("Add: You have chosen to add a new item.");
                    break;

                case "delete":
                    Console.WriteLine("Delete: You have chosen to delete an item.");
                    break;

                case "edit":
                    Console.WriteLine("Edit: You have chosen to edit an existing item.");
                    break;

                case "find":
                    Console.WriteLine("Find: You have chosen to find an item.");
                    break;

                case "list":
                    Console.WriteLine("List: You have chosen to list all items.");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose one of the following: help, add, delete, edit, find, list.");
                    break;
            }
        }
    }
}
using System;
using Gruppuppgiftdatabaser;

namespace Gruppuppgiftdatabaser
{
    public class Program
    {
        static void Main()
        {
            // Skapa en instans av DatabaseService för att använda dess metoder
            var databaseService = new DatabaseService();
            Console.WriteLine("Library Management System");

            while (true)
            {
                Console.WriteLine("\n1. View Books");
                Console.WriteLine("2. Borrow Book");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        databaseService.ListBooks();
                        break;
                    case "2":
                        Console.Write("Enter User ID: ");
                        int userID = GetValidIntegerInput();
                        Console.Write("Enter Book ID: ");
                        int bookID = GetValidIntegerInput();
                        databaseService.BorrowBook(userID, bookID);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        // Hjälpmetod för att få ett giltigt heltalsinmatning
        private static int GetValidIntegerInput()
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || input <= 0)
            {
                Console.Write("Invalid input. Please enter a positive number: ");
            }
            return input;
        }
    }
}
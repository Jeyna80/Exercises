// See https://aka.ms/new-console-template for more information
using System;

namespace VatCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Displaying the menu
            Console.WriteLine("Welcome to the VAT Calculator!");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Music (6% VAT)");
            Console.WriteLine("2. Food (12% VAT)");
            Console.WriteLine("3. Alcohol (25% VAT)");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice (1-4): ");

            // Read user input
            string input = Console.ReadLine();
            int choice;

            // Try to parse the input to an integer
            if (int.TryParse(input, out choice))
            {
                Console.Write("Enter the price (before VAT): ");
                string priceInput = Console.ReadLine();
                decimal price;

                if (decimal.TryParse(priceInput, out price))
                {
                    // Using a switch statement to handle the user's choice
                    switch (choice)
                    {
                        case 1: // Music
                            decimal musicVat = price * 0.06m;
                            decimal musicTotal = price + musicVat;
                            Console.WriteLine($"The total price for Music including 6% VAT is: {musicTotal:C}");
                            break;

                        case 2: // Food
                            decimal foodVat = price * 0.12m;
                            decimal foodTotal = price + foodVat;
                            Console.WriteLine($"The total price for Food including 12% VAT is: {foodTotal:C}");
                            break;

                        case 3: // Alcohol
                            decimal alcoholVat = price * 0.25m;
                            decimal alcoholTotal = price + alcoholVat;
                            Console.WriteLine($"The total price for Alcohol including 25% VAT is: {alcoholTotal:C}");
                            break;

                        case 4: // Exit
                            Console.WriteLine("Exiting the program");
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please select a number between 1 and 3.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid price. Please enter a valid number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                
            }

            // Wait for user to press a key before closing
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
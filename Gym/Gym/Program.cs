// See https://aka.ms/new-console-template for more information
using System;

namespace GymMembershipCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your age: ");
            string ageInput = Console.ReadLine();
            int age;

            // Validate the age input
            if (int.TryParse(ageInput, out age) && age > 0)
            {
                Console.Write("Do you want a premium membership? (yes/no): ");
                string premiumInput = Console.ReadLine();
                bool isPremium = premiumInput.Equals("yes", StringComparison.OrdinalIgnoreCase);

                // Calculate the price based on age and premium membership
                decimal totalPrice = CalculateMembershipPrice(age, isPremium);
                Console.WriteLine($"The total amount payable for your gym membership is: {totalPrice:C}");
            }
            else
            {
                Console.WriteLine("Invalid age input. Please enter a positive integer for your age.");
            }

            // Wait for user to press a key before closing
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        // Method to calculate the membership price
        static decimal CalculateMembershipPrice(int age, bool isPremium)
        {
            decimal basePrice;

            // Determine the base price based on age
            if (age < 19 || age > 64)
            {
                basePrice = 2200;
            }
            else
            {
                basePrice = 3100;
            }

            // Add premium charge if applicable
            if (isPremium)
            {
                basePrice += 300;
            }

            return basePrice;
        }
    }
}

// See https://aka.ms/new-console-template for more information
using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the first number: ");
            double number1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the second number: ");
            double number2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the operation (add, subtract, multiply, divide): ");
            string operation = Console.ReadLine().ToLower();

            // Get the result from the calculator method
            double result = Calculate(operation, number1, number2);

            // Output the result
            Console.WriteLine($"The result of {operation}ing {number1} and {number2} is: {result}");

            // Wait for user to press a key before closing
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        // Calculator method that performs mathematical operations
        static double Calculate(string operation, double num1, double num2)
        {
            double result = 0;

            switch (operation)
            {
                case "add":
                    result = num1 + num2;
                    break;

                case "subtract":
                    result = num1 - num2;
                    break;

                case "multiply":
                    result = num1 * num2;
                    break;

                case "divide":
                    // Check for division by zero
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                        return double.NaN; // Return NaN to indicate an error
                    }
                    break;

                default:
                    Console.WriteLine("Invalid operation. Please use add, subtract, multiply, or divide.");
                    return double.NaN; // Return NaN if the operation is invalid
            }

            return result; // Return the result of the operation
        }
    }
}

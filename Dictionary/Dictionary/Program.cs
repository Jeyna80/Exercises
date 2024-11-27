using System;
using System.Collections.Generic;

public class UserAuth
{
    // Dictionary to store username and password pairs
    private Dictionary<string, string> users = new Dictionary<string, string>();

    // Register a new user
    public void Register(string username, string password)
    {
        if (users.ContainsKey(username))
        {
            Console.WriteLine("User already exists.");
            return;
        }

        // Store the username and password in the dictionary
        users.Add(username, password); // In real applications, hash the password before storing!
        Console.WriteLine("User registered successfully.");
    }

    // Log in an existing user
    public bool Login(string username, string password)
    {
        if (users.TryGetValue(username, out var storedPassword))
        {
            if (storedPassword == password) // In real applications, compare hashed passwords!
            {
                Console.WriteLine("Login successful.");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid password.");
                return false;
            }
        }
        else
        {
            Console.WriteLine("User not found.");
            return false;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        UserAuth userAuth = new UserAuth();

        while (true)
        {
            Console.WriteLine("\n1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            var option = Console.ReadLine();
            if (option == "1")
            {
                Console.Write("Enter username: ");
                var username = Console.ReadLine();
                Console.Write("Enter password: ");
                var password = Console.ReadLine();
                userAuth.Register(username, password);
            }
            else if (option == "2")
            {
                Console.Write("Enter username: ");
                var username = Console.ReadLine();
                Console.Write("Enter password: ");
                var password = Console.ReadLine();
                userAuth.Login(username, password);
            }
            else if (option == "3")
            {
                Console.WriteLine("Exiting...");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Try again.");
            }
        }
    }
}















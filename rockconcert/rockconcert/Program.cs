using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Venue
{
    public string Name { get; set; }
    public int Capacity { get; set; }
}

class Concert
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public Venue Venue { get; set; }
    public double Prices { get; set; }
    public int AvailableTickets { get; set; }
   }

class TicketSystem
{
    private List<Venue> venues = new List<Venue>();
    private List<Concert> concerts = new List<Concert>();
    private const string FILE_NAME = "concerts.txt";

    public void Run()
    {
        LoadData();
        while (true)
        {
            DisplayMenu();
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddConcert();
                    break;
                case "2":
                    ViewConcerts();
                    break;
                case "3":
                    UpdateConcert();
                    break;
                case "4":
                    DeleteConcert();
                    break;
                case "5":
                    Prices();
                    break;
                case "6":
                    BookTicket();
                    break;
                case "7":
                    SaveData();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    public class ConcertManager
    {
        public List<Performer> GetPerformers()
        {
            return new List<Performer>
        {
            new Performer { Name = "Metallica", Genre = "Rock" },
            new Performer { Name = "Manowar", Genre = "Rock" },
            new Performer { Name = "TypeONegative", Genre = "Rock" },
            new Performer { Name = "Disturbed", Genre = "Rock" },
            new Performer { Name = "Wasp", Genre = "Rock" },

        }
    }
        public void DisplayMenu()
        {
            Console.WriteLine("\nConcert Ticket System");
            Console.WriteLine("1. Add Concert");
            Console.WriteLine("2. View Concerts");
            Console.WriteLine("3. Update Concert");
            Console.WriteLine("4. Delete Concert");
            Console.WriteLine("5. Prices");
            Console.WriteLine("6. Book Ticket");
            Console.WriteLine("7. Save Concert/Exit");
            Console.Write("Enter your choice: ");
        }
        public class TicketManager
        {
            public Dictionary<string, decimal> Prices { get; set; }

            public TicketManager()
            {
                Prices = new Dictionary<string, decimal>
        {
           
        };
            }

         public void DisplayMenu()
            {
                Console.WriteLine("Ticket Prices:");
                foreach (var price in Prices)
                {
                    Console.WriteLine($"{price.Key}: ${price.Value}");
                }
            }
        }


        private void AddConcert()
        {
            Console.Write("Enter concert name: ");
            string name = Console.ReadLine();
            Console.Write("Enter concert date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.WriteLine("Invalid date format.");
                return;
            }
            Console.Write("Enter venue name: ");
            string venueName = Console.ReadLine();
            Console.Write("Enter venue capacity: ");
            if (!int.TryParse(Console.ReadLine(), out int capacity))
            {
                Console.WriteLine("Invalid capacity.");
                return;
            }

            Venue venue = venues.FirstOrDefault(v => v.Name == venueName);
            if (venue == null)
            {
                venue = new Venue { Name = venueName, Capacity = capacity };
                venues.Add(venue);
            }


        }
        Concert concert = new Concert
        {
            Name = name,
            Date = date,
            Venue = venue,
            AvailableTickets = capacity,
            Price = double price
        };

        concerts.Add(concert);
        Console.WriteLine("Concert added successfully.");
    }

    private void ViewConcerts()
    {
        if (concerts.Count == 0)
        {
            Console.WriteLine("No concerts available.");
            return;
        }

        foreach (var concert in concerts)
        {
            Console.WriteLine($"Name: {concert.Name}, Date: {concert.Date:yyyy-MM-dd}, Venue: {concert.Venue.Name}, Available Tickets: {concert.AvailableTickets},concert.Price}");
        }
    }

    private void UpdateConcert()
    {
        Console.Write("Enter concert name to update: ");
        string name = Console.ReadLine();
        Concert concert = concerts.FirstOrDefault(c => c.Name == name);
        if (concert == null)
        {
            Console.WriteLine("Concert not found.");
            return;
        }

        Console.Write("Enter new date (yyyy-MM-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime newDate))
        {
            concert.Date = newDate;
        }
        Console.Write("Enter new available tickets: ");
        if (int.TryParse(Console.ReadLine(), out int newTickets))
        {
            concert.AvailableTickets = newTickets;
        }
        Console.WriteLine("Concert updated successfully.");
    }
    private void SaveConcert()
    {
        Console.Write("Enter concert name to save: ");
        string name = Console.ReadLine();
        Concert concert = concerts.FirstOrDefault(c => c.Name == name);
        if (concert == null)
        {
            Console.WriteLine("Concert saved.");
            return;
        }
        concerts.Save(concert);
        Console.WriteLine("Concert saved successfully.");
    }
    private void DeleteConcert()
    {
        Console.Write("Enter concert name to delete: ");
        string name = Console.ReadLine();
        Concert concert = concerts.FirstOrDefault(c => c.Name == name);
        if (concert == null)
        {
            Console.WriteLine("Concert not found.");
            return;
        }
        concerts.Remove(concert);
        Console.WriteLine("Concert deleted successfully.");
    }
    private void Prices
         Console.Write("Enter price: ");if (!double.TryParse(Console.ReadLine(), out double price))

         Console.Write($"Enter new price: (current: {concert.Price:C}): ");
        if (!double.TryParse(Console.ReadLine(), out double price)) concert.Price = price;
    }
   
    private void BookTicket()
    {
        Console.Write("Enter concert name: ");
        string name = Console.ReadLine();
        Concert concert = concerts.FirstOrDefault(c => c.Name == name);
        if (concert == null)
        {
            Console.WriteLine("Concert not found.");
            return;
        }
        if (concert.AvailableTickets == 0)
        {
            Console.WriteLine("Sorry, no tickets available.");
            return;
        }
        concert.AvailableTickets--;
        Console.WriteLine("Ticket booked successfully.");
    }

    private void LoadData()
    {
        if (File.Exists(FILE_NAME))
        {
            string[] lines = File.ReadAllLines(FILE_NAME);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 5)
                {
                    Venue venue = new Venue { Name = parts[2], Capacity = int.Parse(parts[4]) Price = parts[5]};
                    Concert concert = new Concert
                    {
                        Name = parts[0],
                        Date = DateTime.Parse(parts[1]),
                        Venue = venue,
                        AvailableTickets = int.Parse(parts[3]),
                        TicketPrices = ticketprices(parts[5])
                    };

                    concerts.Add(concert);
                    if (!venues.Any(v => v.Name == venue.Name))
                    {
                        venues.Add(venue);
                    }
                }
            }
        }
    }
public static void LoadFromFile()
{
    if (!File.Exists(@"Concerts.txt"))
    {
        Console.WriteLine("No saved concerts found.");
        return;
    }

    concerts.Clear();
    foreach (var line in File.ReadAllLines(@"Concerts.txt"))
    {
        var parts = line.Split('|');
        concerts.Add(new Concert
        {
            Id = int.Parse(parts[0]),
            Location = parts[1],
            Performer = parts[2],
            DateAndTime = DateTime.Parse(parts[3]),
            Capacity = int.Parse(parts[4]),
            Price = double.Parse(parts[5]),
    private void SaveData()
    {
        using (StreamWriter writer = new StreamWriter(FILE_NAME))
        {
        foreach (var concert in concerts)
        {
            writer.WriteLine($"{concert.Name}|{concert.Date:yyyy-MM-dd}|{concert.Venue.Name}|{concert.AvailableTickets}|{concert.Venue.Capacity}|{concert.TicketPrices"});
            
        Console.WriteLine("Data saved successfully.");
        }
}

            Concert myConcert = new Concert
            {
                Name = "Summer Fest 2024",
                Date = new DateTime(2024, 7, 15),
                Performers = new List<string> { "John Doe", "Jane Smith", "The Band" }
            };

            SaveConcertToFile(myConcert, "concerts.txt");
class Program
{
    static void Main(string[] args)
    {
        TicketSystem system = new TicketSystem();
        system.Run();
    }
}
    
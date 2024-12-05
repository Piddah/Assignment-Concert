namespace AssignmentConcert;

public class Concert
{
    private static int _nextId = 1;
    public int Id { get; private set; }
    public string Artist { get; private set; }
    public string Location { get; private set; }
    public DateTime Date { get; private set; }
    public int Tickets { get; private set; }

    private static readonly List<Concert> concerts =
    [
        new(
            "Ed Sheeran",
            "Malmö, Swedbank Stadion",
            new DateTime(2025, 05, 22, 19, 00, 00),
            20000
        ),
        new(
            "Vibrasphere",
            "Göteborg, Trädgårn",
            new DateTime(2025, 04, 11, 21, 00, 0),
            5000
        ),
        new(
            "Birdy",
            "Göteborg, Concert Hall",
            new DateTime(2025, 06, 05, 20, 30, 0),
            8000
        ),
        new(
            "Band of Horses",
            "Malmö, Babel",
            new DateTime(2025, 03, 17, 19, 30, 0),
            700
        )
    ];

    public Concert(string artist, string location, DateTime date, int tickets)
    {
        Id = _nextId++;
        Artist = artist;
        Location = location;
        Date = date;
        Tickets = tickets;
    }

    public static void ListConcerts()
    {
        foreach (var concert in concerts)
        {
            Console.WriteLine($"ID: {concert.Id}");
            Console.WriteLine($"Artist: \t{concert.Artist}");
            Console.WriteLine($"Location: \t{concert.Location}");
            Console.WriteLine($"Date: \t\t{concert.Date}");
            Console.WriteLine($"Tickets: \t{concert.Tickets}");
            Console.WriteLine();
        }
    }

    public static void AddConcert()
    {
        string artist = GetValidInput("Enter Artist name: ");
        string location = GetValidInput("Enter Location: ");
        DateTime date = GetValidDate("Enter Date and Time (yyyy-MM-dd HH:mm): ");
        int tickets = GetValidTickets("Enter Number of Tickets: ");

        Concert newConcert = new Concert(artist, location, date, tickets);
        concerts.Add(newConcert);

        Console.WriteLine($"\nConcert '{artist}' was successfully added!\n");
    }

    public static void EditConcert()
    {
        int id = GetValidId("\nPlease enter the 'Id' of the concert you want to edit: ");

        var concert = concerts.FirstOrDefault(concert => concert.Id == id);
        if (concert != null)
        {
            string artist = GetValidInput("Enter Artist name: ");
            string location = GetValidInput("Enter Location: ");
            DateTime date = GetValidDate("Enter Date and Time (yyyy-MM-dd HH:mm): ");
            int tickets = GetValidTickets("Enter Number of Tickets: ");

            concert.Artist = artist;
            concert.Location = location;
            concert.Date = date;
            concert.Tickets = tickets;

            Console.WriteLine($"\nConcert with id:{id} has been succesfully updated.\n");
        }
        else Console.WriteLine("\nConsert not found.\n");
    }

    public static void DeleteConcert()
    {
        int id = GetValidId("\nEnter the Id of the concert you wish to delete: ");

        if (id != -1)
        {
            concerts.RemoveAll(concert => concert.Id == id);
            Console.WriteLine($"\nConcert with id:{id} was succesfully been deleted.\n");
        }
        else
            Console.WriteLine("\nDeletion was either cencelled or id was not found.\n");
    }

    private static string GetValidInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()!;

            if (!string.IsNullOrWhiteSpace(input))
                return input;

            Console.WriteLine("\nInput cannot be empty.\n");
        }
    }

    private static DateTime GetValidDate(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime date))
                return date;

            Console.WriteLine("\nInvalid date format. Please use 'yyyy-MM-dd HH:mm'.\n");
        }
    }

    private static int GetValidTickets(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int tickets) && tickets > 0)
                return tickets;

            Console.WriteLine("\nInvalid number of tickets. Please enter a positive number.\n");
        }
    }

    private static int GetValidId(string prompt)
    {
        bool exit = false;
        do
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (concerts.Any(x => x.Id == id))
                    return id;
            }
            else
            {
                Console.WriteLine("\nThat is not a valid id.");
                Console.WriteLine("Type \"exit\" to cancel or any key to try again.");
                string? input = Console.ReadLine();

                if (input != null && input == "exit")
                    exit = true;
            }
        } while (!exit);
        return -1;
    }
}


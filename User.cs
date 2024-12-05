using System.Text.RegularExpressions;

namespace AssignmentConcert;

public class User
{
    private static int _nextId = 1;
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    private string Password { get; set; }

    private static readonly List<User> users = new();

    public User(string firstName, string lastName, string password)
    {
        Id = _nextId++;
        FirstName = firstName;
        LastName = lastName;
        Password = password;
    }

    public static User CreateAccount()
    {
        string firstName = CreateValidName("Enter first name: ");
        string lastName = CreateValidName("Enter last name: ");
        string password = CreateValidPassword("Enter a password: ");

        users.Add(new User(firstName, lastName, password));

        Console.Clear();
        Console.WriteLine("New account was succsesfully created.\n");

        return new User(firstName, lastName, password);
    }

    private static void LogInSuccess()
    {
        Console.Clear();
        Console.WriteLine("\nYou have logged in.\n");
        Menu.ConcertMenu();
    }

    public static void LogIn()
    {
        string[] fullName = GetValidName("Please enter your Full name: ").Split();
        string password = GetValidPassword("Please enter Password: ");
        string firstName = fullName[0];
        string lastName = fullName[1];

        if (users.Any(x => x.FirstName == firstName && x.LastName == lastName && x.Password == password))
        {
            LogInSuccess();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Login failed.\n");
        }
    }

    private static string CreateValidName(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? name = Console.ReadLine();
            Regex regex = new("^[a-öA-Ö\\s-]+$");

            if (string.IsNullOrEmpty(name))
                Console.WriteLine("Name cant be empty.");

            else if (!regex.IsMatch(name))
                Console.WriteLine("Invalid characters used.");

            else return (char.ToUpper(name[0]) + name.Substring(1).ToLower()).Trim();
        }
    }

    private static string CreateValidPassword(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? password = Console.ReadLine();

            if (!string.IsNullOrEmpty(password))
            {
                if (password.Length < 6)
                    Console.WriteLine("Password needs to be at least 6 characters.");

                else if (!password.Any(char.IsDigit) || !password.Any(char.IsUpper))
                    Console.WriteLine("Password needs at least one digit and one large letter.");

                else return password;
            }
        }
    }

    private static string GetValidName(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? name = Console.ReadLine();

            if (!string.IsNullOrEmpty(name) && name.Length > 2 && name.Trim().Contains(' '))
            {
                return name.Trim();
            }
            else Console.WriteLine("Invalid name");
        }
    }

    private static string GetValidPassword(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? password = Console.ReadLine();

            if (!string.IsNullOrEmpty(password))
                return password;

            else Console.WriteLine("Password can not be empty.");
        }
    }
}



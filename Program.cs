using AssignmentConcert;

List<string> signIn =
[
    "1. Log In",
    "2. Create Account",
    "3. Exit"
];

Console.Clear();
Console.WriteLine("Welcome to Ticket Master");
Console.WriteLine();
try
{
    SignIn();
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex);
}

void SignIn()
{
    bool exit = false;
    string? menuSelection;

    do
    {
        foreach (var item in signIn)
            Console.WriteLine(item);

        menuSelection = Console.ReadLine();
        Console.WriteLine();

        if (menuSelection != null)
            menuSelection = menuSelection.ToLower().Trim();

        switch (menuSelection)
        {
            case "1":
                User.LogIn();
                break;

            case "2":
                var user = User.CreateAccount();
                break;

            case "3":
                exit = true;
                break;

            case "exit":
                exit = true;
                break;

            default:
                Console.Clear();
                Console.WriteLine("\nChoose an option from the menu.\n");
                break;
        }

    } while (!exit);

}

Console.WriteLine("\nGoodbye!\n");




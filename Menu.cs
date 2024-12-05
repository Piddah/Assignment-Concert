using System;

namespace AssignmentConcert;

public class Menu
{
    private static readonly List<string> concertMenu =
[
    "1. Availible Concerts",
    "2. Add new Concert,",
    "3. Edit Concert",
    "4. Delete Concert",
    "5. Exit"
];

    public static void ConcertMenu()
    {
        bool exit = false;
        string? menuSelection;

        do
        {
            foreach (var item in concertMenu)
                Console.WriteLine(item);

            menuSelection = Console.ReadLine();

            if (menuSelection != null)
                menuSelection = menuSelection.ToLower().Trim();

            switch (menuSelection)
            {
                case "1":
                    Concert.ListConcerts();
                    break;

                case "2":
                    Concert.AddConcert();
                    break;

                case "3":
                    Concert.EditConcert();
                    break;

                case "4":
                    Concert.DeleteConcert();
                    break;

                case "5":
                    exit = true;
                    break;

                case "exit":
                    exit = true;
                    break;

                default:
                    exit = true;
                    break;
            }

        } while (exit == false);

        Console.Clear();
    }


}

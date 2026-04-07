using System;
using System.Collections.Generic;

class Program
{
    private static List<Activity> _activities = new List<Activity>();
    private static Dictionary<string, int> _activityLog = new Dictionary<string, int>();

    static void Main()
    {
        _activities.Add(new BreathingActivity());
        _activities.Add(new ReflectionActivity());
        _activities.Add(new ListingActivity());

        _activityLog["Breathing"] = 0;
        _activityLog["Reflection"] = 0;
        _activityLog["Listing"] = 0;

        bool running = true;

        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunActivity(0);
                    break;
                case "2":
                    RunActivity(1);
                    break;
                case "3":
                    RunActivity(2);
                    break;
                case "4":
                    DisplayStatistics();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("\nThank you for using the Mindfulness Program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    System.Threading.Thread.Sleep(2000);
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║     MINDFULNESS PROGRAM MENU           ║");
        Console.WriteLine("╠════════════════════════════════════════╣");
        Console.WriteLine("║ 1. Breathing Activity                  ║");
        Console.WriteLine("║ 2. Reflection Activity                 ║");
        Console.WriteLine("║ 3. Listing Activity                    ║");
        Console.WriteLine("║ 4. View Activity Statistics            ║");
        Console.WriteLine("║ 5. Exit                                ║");
        Console.WriteLine("╚════════════════════════════════════════╝");
        Console.Write("\nSelect an option (1-5): ");
    }

    static void RunActivity(int activityIndex)
    {
        Activity activity = _activities[activityIndex];
        activity.Run();
        
        _activityLog[activity.Name]++;
        
        Console.WriteLine("\nPress enter to return to the menu.");
        Console.ReadLine();
    }

    static void DisplayStatistics()
    {
        Console.Clear();
       
        Console.WriteLine("ACTIVITY STATISTICS");
       
        
        int totalActivities = 0;
        foreach (var entry in _activityLog)
        {
            Console.WriteLine($"{entry.Key,-20} {entry.Value,15} times ");
            totalActivities += entry.Value;
        }
        
        
        Console.WriteLine($" Total Activities Completed: {totalActivities,21} ");
       
        
        Console.WriteLine("\nPress enter to return to the menu.");
        Console.ReadLine();
    }
}

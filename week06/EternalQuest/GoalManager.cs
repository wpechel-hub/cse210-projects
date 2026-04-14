using System;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
    }

    public void Start()
    {
        string menuChoice = string.Empty;

        while (menuChoice != "6")
        {
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            menuChoice = Console.ReadLine();

            Console.WriteLine();

            switch (menuChoice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Level: {_level}");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int index = 0; index < _goals.Count; index++)
        {
            Console.WriteLine($"{index + 1}. {_goals[index].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int index = 0; index < _goals.Count; index++)
        {
            Console.WriteLine($"{index + 1}. {_goals[index].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string goalType = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string shortName = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        switch (goalType)
        {
            case "1":
                newGoal = new SimpleGoal(shortName, description, points);
                break;

            case "2":
                newGoal = new EternalGoal(shortName, description, points);
                break;

            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int targetCount = int.Parse(Console.ReadLine());

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());

                newGoal = new ChecklistGoal(shortName, description, points, targetCount, bonus);
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        _goals.Add(newGoal);
        Console.WriteLine("Goal created successfully!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available to record.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int index = 0; index < _goals.Count; index++)
        {
            Console.WriteLine($"{index + 1}. {_goals[index].GetShortName()}");
        }

        Console.Write("Which goal did you accomplish? ");
        int goalNumber = int.Parse(Console.ReadLine());

        if (goalNumber < 1 || goalNumber > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal selectedGoal = _goals[goalNumber - 1];
        int earnedPoints = selectedGoal.RecordEvent();

        _score += earnedPoints;

        if (earnedPoints > 0)
        {
            Console.WriteLine($"Congratulations! You have earned {earnedPoints} points!");
            CheckLevelUp();
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score);
            outputFile.WriteLine(_level);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(fileName);

        _goals.Clear();

        if (lines.Length >= 2)
        {
            _score = int.Parse(lines[0]);
            _level = int.Parse(lines[1]);
        }

        for (int index = 2; index < lines.Length; index++)
        {
            string[] parts = lines[index].Split("|");
            string goalType = parts[0];

            if (goalType == "SimpleGoal")
            {
                string shortName = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                bool isComplete = bool.Parse(parts[4]);

                _goals.Add(new SimpleGoal(shortName, description, points, isComplete));
            }
            else if (goalType == "EternalGoal")
            {
                string shortName = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                _goals.Add(new EternalGoal(shortName, description, points));
            }
            else if (goalType == "ChecklistGoal")
            {
                string shortName = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                int bonus = int.Parse(parts[4]);
                int targetCount = int.Parse(parts[5]);
                int amountCompleted = int.Parse(parts[6]);

                _goals.Add(new ChecklistGoal(shortName, description, points, targetCount, bonus, amountCompleted));
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }

    private void CheckLevelUp()
    {
        int newLevel = (_score / 1000) + 1;

        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"Awesome! You leveled up! You are now Level {_level}!");
        }
    }
}
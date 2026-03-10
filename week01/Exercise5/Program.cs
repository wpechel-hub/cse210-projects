using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMsg();

        string userName = userNames();
        int userNumber = userNumbers();

        int sNumber = sqNumber(userNumber);

        DisplayResult(userName, sNumber);
    }

    static void DisplayWelcomeMsg()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string userNames()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int userNumbers()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    static int sqNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}
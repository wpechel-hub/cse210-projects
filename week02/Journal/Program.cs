using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            Console.Write("Choose an option: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);

                Console.Write("> ");
                string response = Console.ReadLine();

                string date = DateTime.Now.ToShortDateString();

                Entry entry = new Entry();
                entry._date = date;
                entry._promptText = prompt;
                entry._entryText = response;

                journal.AddEntry(entry);
            }

            else if (choice == 2)
            {
                journal.DisplayAll();
            }

            else if (choice == 3)
            {
                Console.Write("File name: ");
                string file = Console.ReadLine();
                journal.LoadFromFile(file);
            }

            else if (choice == 4)
            {
                Console.Write("File name: ");
                string file = Console.ReadLine();
                journal.SaveToFile(file);
            }
        }
    }
}
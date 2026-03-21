using System;

public class Entry
{
    public string Date;
    public string PromptText;
    public string EntryText;

    public void Display()
    {
        Console.WriteLine($"{Date} - {PromptText}");
        Console.WriteLine(EntryText);
    }
}
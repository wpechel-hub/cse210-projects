using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord today?",
        "What was the strongest emotion I felt today?",
        "If I could redo something today what would it be?"
        "What moment today made me feel grateful?",
        "What challenge did I face today and how did I handle it?",
        "What is something small that made today better?",
        "What is one thing I accomplished today that I am proud of?",
        "What lesson did today teach me?",
        "What was the most peaceful moment of my day?",
        "What act of kindness did I give or receive today?",
        "What surprised me the most today?",
        "What is one thing I would like to improve tomorrow?",
        "What memory from today do I want to remember in the future?"   
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}
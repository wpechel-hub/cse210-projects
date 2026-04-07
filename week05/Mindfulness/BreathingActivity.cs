using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        int breathDuration = 4;

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("\nBreathe in...");
            ShowCountDown(breathDuration);
            
            if (DateTime.Now >= endTime)
                break;
                
            Console.WriteLine("\nBreathe out...");
            ShowCountDown(breathDuration);
        }

        DisplayEndingMessage();
    }
}

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new RunningActivity("04 Nov 2025", 30, 3.0));
        activities.Add(new CyclingActivity("10 Nov 2025", 30, 6.0));
        activities.Add(new SwimmingActivity("15 Nov 2025", 30, 20));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
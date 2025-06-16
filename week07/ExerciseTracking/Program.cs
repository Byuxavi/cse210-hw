using System;
using System.Collections.Generic;

namespace ExerciseTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Activity> activities = new List<Activity>();

            Running runningActivity = new Running("03 Nov 2022", 30, 4.8);
            activities.Add(runningActivity);

            Cycling cyclingActivity = new Cycling("05 Nov 2022", 45, 25.0);
            activities.Add(cyclingActivity);

            Swimming swimmingActivity = new Swimming("07 Nov 2022", 35, 40);
            activities.Add(swimmingActivity);

            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}
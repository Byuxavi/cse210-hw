/*
 * Creative features that exceed core requirements:
 * 1. Session Logging: Automatically records each completed activity with timestamp, 
 *    activity type, and duration to a log file (session_log.txt) for tracking 
 *    mindfulness practice history.
 * 2. Dynamic Prompt/Question Selection: Activities avoid repeating prompts and 
 *    questions within the same session, providing more varied experiences.
 * 3. Enhanced User Interface: Clear visual separators and better formatting 
 *    for improved user experience.
 */

using System;

class Program
{
    static void Main(string[] args)
    {
        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("=== Mindfulness Program ===");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine("===========================");
            Console.Write("Select an option: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                new BreathingActivity().Run();
            }
            else if (choice == "2")
            {
                new ReflectionActivity().Run();
            }
            else if (choice == "3")
            {
                new ListingActivity().Run();
            }
        }

        Console.WriteLine("Thank you for using the program. Take care!");
    }
}
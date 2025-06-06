using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt peace this month?",
        "Who are some of your personal heroes?"
    };

    private List<string> _questions = new List<string>
    {
        "Why is this important to you?",
        "How does this make you feel?",
        "How can you use this strength?",
        "What can you do to appreciate this more?",
        "How has this influenced your life?"
    };

    public ListingActivity() : base("Listing Activity",
        "This activity helps you reflect on the good things in your life by listing as many as you can.")
    {
    }

    public void Run()
    {
        Start();

        List<string> availablePrompts = new List<string>(_prompts);
        List<string> availableQuestions = new List<string>(_questions);
        Random randomGenerator = new Random();

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        
        string selectedPrompt = availablePrompts[randomGenerator.Next(availablePrompts.Count)];
        Console.WriteLine($"--- {selectedPrompt} ---");
        availablePrompts.Remove(selectedPrompt);

        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder the following questions:");
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        
        while (DateTime.Now < endTime)
        {
            if (availableQuestions.Count == 0)
            {
                availableQuestions = new List<string>(_questions);
            }

            string selectedQuestion = availableQuestions[randomGenerator.Next(availableQuestions.Count)];
            Console.WriteLine($"> {selectedQuestion}");
            availableQuestions.Remove(selectedQuestion);
            
            PauseWithSpinner(5);
            Console.WriteLine();
        }

        End();
    }
}
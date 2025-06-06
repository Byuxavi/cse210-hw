using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What did you learn about yourself?",
        "How can you keep this in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", 
        "This activity helps you reflect on times when you have shown strength and resilience.")
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
using System;
using System.Threading;

public class Activity
{
    protected int _duration;
    protected string _name;
    protected string _description;

    public Activity(string name, string description)
    {
        this._name = name;
        this._description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        PauseWithSpinner(3);
    }

    public void End()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        PauseWithSpinner(2);
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        
        // Log the completed session
        SessionLogger.LogSession(_name, _duration);
        
        PauseWithSpinner(3);
    }

    protected void PauseWithSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int spinnerIndex = 0;
        
        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[spinnerIndex % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            spinnerIndex++;
        }
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
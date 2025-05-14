using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Tag { get; set; }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Tag: {Tag}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine();
    }

    public string ToFileFormat()
    {
        return $"{Date}|{Prompt}|{Response}|{Tag}";
    }

    public static Entry FromFileFormat(string line)
    {
        var parts = line.Split('|');
        return new Entry
        {
            Date = parts[0],
            Prompt = parts[1],
            Response = parts[2],
            Tag = parts.Length > 3 ? parts[3] : ""
        };
    }
}

using System;
using System.IO;

public static class SessionLogger
{
    private static readonly string _logFilePath = "session_log.txt";

    public static void LogSession(string activityName, int durationInSeconds)
    {
        string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | Activity: {activityName} | Duration: {durationInSeconds} seconds";
        
        try
        {
            File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error logging session: {ex.Message}");
        }
    }
}
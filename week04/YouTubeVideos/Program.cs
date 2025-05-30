using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("FC Barcelona vs Real Madrid - Match Highlights", "LaLiga Official", 600);
        video1.AddComment(new Comment("Carlos", "Amazing match, Barça played great!"));
        video1.AddComment(new Comment("Marta", "What a goal in the second half."));
        video1.AddComment(new Comment("LeoFan", "Visca Barça!"));
        videos.Add(video1);

        Video video2 = new Video("Top 10 Lionel Messi Goals", "FIFA Channel", 480);
        video2.AddComment(new Comment("Jorge", "He’s not human!"));
        video2.AddComment(new Comment("Elena", "The goat 🐐"));
        video2.AddComment(new Comment("Max", "I could watch this all day."));
        videos.Add(video2);

        Video video3 = new Video("Incredible Champions League Goals", "UEFA", 530);
        video3.AddComment(new Comment("Anna", "These goals bring back memories."));
        video3.AddComment(new Comment("Tom", "What a compilation!"));
        video3.AddComment(new Comment("Nina", "That volley at 2:45 was insane!"));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}


using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>();

            
            Video video1 = new Video("C# Basic", "Exploring C#", 1200);
            video1.AddComment(new Comment("Taylor", "Great explanation!"));
            video1.AddComment(new Comment("Jefferson", "Very helpful for beginners."));
            video1.AddComment(new Comment("User123", "Looking forward to more tutorials."));
            videos.Add(video1);

            
            Video video2 = new Video("C# in 30 minutes", "CodePower", 2400);
            video2.AddComment(new Comment("David", "Challenging but rewarding."));
            video2.AddComment(new Comment("Cecilia", "Excellent deep dive into the topic."));
            video2.AddComment(new Comment("CrazyDev", "Could use more examples."));
            video2.AddComment(new Comment("Beatriz", "Learned a lot!"));
            videos.Add(video2);

           
            Video video3 = new Video("C# Pascal Code", "SimplifyDev", 1800);
            video3.AddComment(new Comment("Robert", "Solid advice."));
            video3.AddComment(new Comment("William", "Will apply these tips to my projects."));
            videos.Add(video3);

            Console.WriteLine("\n--- YouTube Videos Information ---\n");

            foreach (Video video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
                Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
                Console.WriteLine("Comments:");
                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($"  - {comment.CommenterName}: {comment.CommentText}");
                }
                Console.WriteLine();
            }
        }
    }
}

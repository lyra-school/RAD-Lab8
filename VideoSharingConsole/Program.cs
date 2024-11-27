namespace VideoSharingConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataPopulator();
        }

        public static void DataPopulator()
        {
            VideoSharingContext db = new VideoSharingContext();

            VideoSharingPlatform.Creator c1 = new VideoSharingPlatform.Creator
            {
                Handle = "MrsYeast",
                Tag = "yeast"
            };

            VideoSharingPlatform.Creator c2 = new VideoSharingPlatform.Creator
            {
                Handle = "JoanSewerNose",
                Tag = "sewer"
            };

            VideoSharingPlatform.Creator c3 = new VideoSharingPlatform.Creator
            {
                Handle = "Partybolt",
                Tag = "bolt12"
            };

            VideoSharingPlatform.Creator c4 = new VideoSharingPlatform.Creator
            {
                Handle = "EpicReactionz",
                Tag = "react"
            };

            db.Creator.Add(c1);
            db.Creator.Add(c2);
            db.Creator.Add(c3);
            db.Creator.Add(c4);

            VideoSharingPlatform.Statistics s1 = new VideoSharingPlatform.Statistics
            {
                TargetAudience = "Preteens, early teens",
                AverageViewsPerHour = 124901.23,
                AverageCommentsPerHour = 145.2,
                AveragePercentageWatchtime = 0.55
            };

            VideoSharingPlatform.Statistics s2 = new VideoSharingPlatform.Statistics
            {
                TargetAudience = "Preteens, early teens",
                AverageViewsPerHour = 124825.002,
                AverageCommentsPerHour = 33.3,
                AveragePercentageWatchtime = 0.23
            };

            VideoSharingPlatform.Statistics s3 = new VideoSharingPlatform.Statistics
            {
                TargetAudience = "Late teens",
                AverageViewsPerHour = 2678.23,
                AverageCommentsPerHour = 14.1,
                AveragePercentageWatchtime = 0.88
            };

            VideoSharingPlatform.Statistics s4 = new VideoSharingPlatform.Statistics
            {
                TargetAudience = "Late teens",
                AverageViewsPerHour = 1378.23,
                AverageCommentsPerHour = 23.8,
                AveragePercentageWatchtime = 0.69
            };

            VideoSharingPlatform.Statistics s5 = new VideoSharingPlatform.Statistics
            {
                TargetAudience = "Young adult",
                AverageViewsPerHour = 2555.25,
                AverageCommentsPerHour = 12.12,
                AveragePercentageWatchtime = 0.90
            };

            VideoSharingPlatform.Statistics s6 = new VideoSharingPlatform.Statistics
            {
                TargetAudience = "Young adult",
                AverageViewsPerHour = 6799.0,
                AverageCommentsPerHour = 21.5,
                AveragePercentageWatchtime = 0.6
            };

            VideoSharingPlatform.Statistics s7 = new VideoSharingPlatform.Statistics
            {
                TargetAudience = "Preteens",
                AverageViewsPerHour = 123456.123,
                AverageCommentsPerHour = 30.3,
                AveragePercentageWatchtime = 0.25
            };

            VideoSharingPlatform.Statistics s8 = new VideoSharingPlatform.Statistics
            {
                TargetAudience = "Preteens",
                AverageViewsPerHour = 654321.321,
                AverageCommentsPerHour = 30.3,
                AveragePercentageWatchtime = 0.52
            };

            db.Statistics.Add(s1);
            db.Statistics.Add(s2);
            db.Statistics.Add(s3);
            db.Statistics.Add(s4);
            db.Statistics.Add(s5);
            db.Statistics.Add(s6);
            db.Statistics.Add(s7);
            db.Statistics.Add(s8);

            VideoSharingPlatform.Video v1 = new VideoSharingPlatform.Video
            {
                Title = "$1 Baking Challenge vs $1,000,000 Baking Challenge",
                Category = "Reality",
                Description = "like and subscribe",
                Views = 1000000,
                LengthInSeconds = 1200,
                Creator = c1,
                Statistics = s1
            };

            VideoSharingPlatform.Video v2 = new VideoSharingPlatform.Video
            {
                Title = "Giving $100,000,000 Away To A Poor Bakery",
                Category = "Reality",
                Description = "like and subscribe",
                Views = 9999999,
                LengthInSeconds = 1200,
                Creator = c1,
                Statistics = s2
            };

            VideoSharingPlatform.Video v3 = new VideoSharingPlatform.Video
            {
                Title = "Four Days at Frank's [1]",
                Category = "Gaming",
                Description = "Hit that notification bell",
                Views = 69420,
                LengthInSeconds = 1780,
                Creator = c2,
                Statistics = s3
            };

            VideoSharingPlatform.Video v4 = new VideoSharingPlatform.Video
            {
                Title = "Martian: Desolation [4]",
                Category = "Gaming",
                Description = "Brand new horror game that just came out",
                Views = 4444444,
                LengthInSeconds = 2541,
                Creator = c2,
                Statistics = s4
            };

            VideoSharingPlatform.Video v5 = new VideoSharingPlatform.Video
            {
                Title = "Hanging out and chilling",
                Category = "Casual",
                Description = "Find my other VODs on this channel",
                Views = 592032,
                LengthInSeconds = 6000,
                Creator = c3,
                Statistics = s5
            };

            VideoSharingPlatform.Video v6 = new VideoSharingPlatform.Video
            {
                Title = "Layers of Ogre",
                Category = "Gaming",
                Description = "onions have layers. this game doesn't",
                Views = 359640,
                LengthInSeconds = 3402,
                Creator = c3,
                Statistics = s6
            };

            VideoSharingPlatform.Video v7 = new VideoSharingPlatform.Video
            {
                Title = "Reacting to reaction streamer reacting to a reaction of reaction to...",
                Category = "Casual",
                Description = "Suggest more things for me to react to!",
                Views = 2000000,
                LengthInSeconds = 4020,
                Creator = c4,
                Statistics = s7
            };

            VideoSharingPlatform.Video v8 = new VideoSharingPlatform.Video
            {
                Title = "BLOODY MARY RITUAL AT 3 AM (GONE WRONG) ft. Some Dude",
                Category = "Casual",
                Description = "Suggest more things for me to react to!",
                Views = 3000000,
                LengthInSeconds = 4020,
                Creator = c4,
                Statistics = s8
            };

            db.Video.Add(v1);
            db.Video.Add(v2);
            db.Video.Add(v3);
            db.Video.Add(v4);
            db.Video.Add(v5);
            db.Video.Add(v6);
            db.Video.Add(v7);
            db.Video.Add(v8);

            VideoSharingPlatform.CollaborativeEvent e1 = new VideoSharingPlatform.CollaborativeEvent
            {
                Name = "INSANE GIVEAWAY",
                Description = "Giving away Gucci flour to people who buy MrsYeast's branded spatula",
                Date = DateTime.Now,
                Creators = [c1, c4]
            };

            VideoSharingPlatform.CollaborativeEvent e2 = new VideoSharingPlatform.CollaborativeEvent
            {
                Name = "Streamer Get-Together",
                Description = "Your favourite streamers all in one place",
                Date = DateTime.Now,
                Creators = [c2, c3, c4]
            };

            db.CollaborativeEvent.Add(e1);
            db.CollaborativeEvent.Add(e2);

            db.SaveChanges();
        }
    }
}

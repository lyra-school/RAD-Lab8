using VideoSharingConsole;
using VideoSharingPlatform;

namespace DemonstrationConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VideoSharingContext context = new VideoSharingContext();

            Console.WriteLine("-- Get Videos From Creator --");
            Console.WriteLine("This function lists all of MrsYeast's videos\n");
            List<Video> videos = VideoSharingQuery.GetVideosFromCreator(context, 1);

            foreach(Video v in videos)
            {
                Console.WriteLine("TITLE: " + v.Title);
                Console.WriteLine("CATEGORY: " + v.Category);
                Console.WriteLine("DESCRIPTION: " + v.Description);
                Console.WriteLine("VIEWS: " + v.Views);
                Console.WriteLine("LENGTH IN SECONDS: " + v.Views + "\n");
            }
            
            Console.WriteLine("-- Get Statistics From Video --");
            Console.WriteLine("This function lists statistics from one of EpicReactionz's videos\n");
            List<Statistics> stats = VideoSharingQuery.GetStatisticsFromVideo(context, 8);

            foreach (Statistics s in stats)
            {
                Console.WriteLine("TARGET AUDIENCE: " + s.TargetAudience);
                Console.WriteLine("AVERAGE VIEWS PER HOUR: " + s.AverageViewsPerHour);
                Console.WriteLine("AVERAGE COMMENTS PER HOUR: " + s.AverageCommentsPerHour);
                Console.WriteLine("AVERAGE PERCENTAGE WATCHTIME: " + (s.AveragePercentageWatchtime * 100) + "%\n");
            }

            Console.WriteLine("-- Get Videos With Over Million Views --");
            Console.WriteLine("This function lists ALL videos that reached >=1000000 views\n");
            List<Video> videos2 = VideoSharingQuery.GetVideosOverMillionViews(context);

            foreach (Video v in videos2)
            {
                Console.WriteLine("TITLE: " + v.Title);
                Console.WriteLine("CATEGORY: " + v.Category);
                Console.WriteLine("DESCRIPTION: " + v.Description);
                Console.WriteLine("VIEWS: " + v.Views);
                Console.WriteLine("LENGTH IN SECONDS: " + v.LengthInSeconds + "\n");
            }

            Console.WriteLine("-- Get All Events By Creator --");
            Console.WriteLine("This function lists all events that a given creator (EpicReactionz) participates in\n");
            List<CollaborativeEvent> collabs  = VideoSharingQuery.GetAllEventsByCreator(context, 4);

            foreach (CollaborativeEvent c in collabs)
            {
                Console.WriteLine("NAME: " + c.Name);
                Console.WriteLine("DESCRIPTION: " + c.Description);
                Console.WriteLine("DATE: " + c.Date.ToString() + "\n");
            }

            Console.WriteLine("-- List All Creator Names --");
            Console.WriteLine("This function lists all creator names within the database\n");
            List<string> handles = VideoSharingQuery.ListAllCreatorNames(context);

            foreach (string s in handles)
            {
                Console.WriteLine("CREATOR: " + s + "\n");
            }

            Console.WriteLine("-- Get Creator --");
            Console.WriteLine("This function gets everything about a single creator\n");
            Creator creator = VideoSharingQuery.GetCreator(context, 3);

            Console.WriteLine("HANDLE: " + creator.Handle);
            Console.WriteLine("TAG: " + creator.Tag);
            
        }
    }
}

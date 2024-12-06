using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoSharingPlatform;

namespace VideoSharingConsole
{
    public class VideoSharingQuery
    {
        public static List<VideoSharingPlatform.Video> GetVideosFromCreator(VideoSharingContext db, int creatorId)
        {
            IEnumerable<VideoSharingPlatform.Video> query = from v in db.Video
                                                            where v.Creator.ID == creatorId
                                                            select v;
            return query.ToList();
        }

        public static List<VideoSharingPlatform.Statistics> GetStatisticsFromVideo(VideoSharingContext db, int videoId)
        {
            IEnumerable<VideoSharingPlatform.Statistics> query = from v in db.Video
                                                                 from s in db.Statistics
                                                                 where v.StatisticsID == s.ID
                                                                 select s;
            return query.ToList();
        }

        public static List<VideoSharingPlatform.Video> GetVideosOverMillionViews(VideoSharingContext db)
        {
            IEnumerable<VideoSharingPlatform.Video> query = from v in db.Video
                                                            where v.Views >= 1000000
                                                            select v;
            return query.ToList();
        }

        public static List<CollaborativeEvent> GetAllEventsByCreator(VideoSharingContext db, int creatorId)
        {
            IEnumerable<CollaborativeEvent> query = from e in db.CollaborativeEvent
                                                    from c in e.Creators
                                                    where c.ID == creatorId
                                                    select e;
            return query.ToList();
        }

        public static List<string> ListAllCreatorNames(VideoSharingContext db)
        {
            IEnumerable<string> query = from c in db.Creator
                                        select c.Handle;
            return query.ToList();
        }

        public static Creator GetCreator(VideoSharingContext db, int id)
        {
            IEnumerable<Creator> query = from c in db.Creator
                                         where c.ID == id
                                         select c;
            return query.ToList()[0];
        }
    }
}

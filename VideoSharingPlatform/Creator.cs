namespace VideoSharingPlatform
{
    public class Creator
    {
        public int ID { get; set; }

        public string? OwnerID { get; set; }
        public string Handle { get; set; }
        public string Tag { get; set; }

        public virtual ICollection<CollaborativeEvent> Events { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}

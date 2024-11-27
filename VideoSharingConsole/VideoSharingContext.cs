using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VideoSharingPlatform;

namespace VideoSharingConsole
{
    public class VideoSharingContext : DbContext
    {
        public VideoSharingContext() { }
        public VideoSharingContext(DbContextOptions<VideoSharingContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=VideoSharing");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Video>().HasOne(v => v.Statistics).WithOne(s => s.Video).HasForeignKey<Statistics>(s => s.ID);
        }

        public DbSet<VideoSharingPlatform.Creator> Creator { get; set; } = default!;
        public DbSet<VideoSharingPlatform.Video> Video { get; set; } = default!;
        public DbSet<VideoSharingPlatform.CollaborativeEvent> CollaborativeEvent { get; set; } = default!;
        public DbSet<VideoSharingPlatform.Statistics> Statistics { get; set; } = default!;
    }
}

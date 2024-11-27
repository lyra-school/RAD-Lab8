using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoSharingPlatform
{
    public class Statistics
    {
        public int ID { get; set; }
        public string TargetAudience { get; set; }
        public double AverageViewsPerHour { get; set; }
        public double AverageCommentsPerHour {  get; set; }
        public double AveragePercentageWatchtime {  get; set; }

        public virtual Video Video { get; set; }
    }
}

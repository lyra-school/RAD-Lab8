using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoSharingPlatform
{
    public class Video
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Views { get; set; }
        public int LengthInSeconds {  get; set; }
        public int StatisticsID { get; set; }

        public virtual Creator Creator { get; set; }
        public virtual Statistics Statistics { get; set; }
    }
}

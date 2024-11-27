using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoSharingPlatform
{
    public class CollaborativeEvent
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date {  get; set; }

        public virtual ICollection<Creator> Creators { get; set; }
    }
}

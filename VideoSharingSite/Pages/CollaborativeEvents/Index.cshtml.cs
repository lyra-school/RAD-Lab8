using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VideoSharingConsole;
using VideoSharingPlatform;

namespace VideoSharingSite.Pages.CollaborativeEvents
{
    public class IndexModel : PageModel
    {
        private readonly VideoSharingConsole.VideoSharingContext _context;

        public IndexModel(VideoSharingConsole.VideoSharingContext context)
        {
            _context = context;
        }

        public IList<CollaborativeEvent> CollaborativeEvent { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CollaborativeEvent = await _context.CollaborativeEvent.ToListAsync();
        }
    }
}

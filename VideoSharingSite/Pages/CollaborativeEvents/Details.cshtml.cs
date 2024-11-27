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
    public class DetailsModel : PageModel
    {
        private readonly VideoSharingConsole.VideoSharingContext _context;

        public DetailsModel(VideoSharingConsole.VideoSharingContext context)
        {
            _context = context;
        }

        public CollaborativeEvent CollaborativeEvent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collaborativeevent = await _context.CollaborativeEvent.FirstOrDefaultAsync(m => m.ID == id);
            if (collaborativeevent == null)
            {
                return NotFound();
            }
            else
            {
                CollaborativeEvent = collaborativeevent;
            }
            return Page();
        }
    }
}

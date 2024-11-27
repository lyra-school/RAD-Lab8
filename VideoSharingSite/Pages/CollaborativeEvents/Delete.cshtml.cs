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
    public class DeleteModel : PageModel
    {
        private readonly VideoSharingConsole.VideoSharingContext _context;

        public DeleteModel(VideoSharingConsole.VideoSharingContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collaborativeevent = await _context.CollaborativeEvent.FindAsync(id);
            if (collaborativeevent != null)
            {
                CollaborativeEvent = collaborativeevent;
                _context.CollaborativeEvent.Remove(CollaborativeEvent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

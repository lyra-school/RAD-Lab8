using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VideoSharingConsole;
using VideoSharingPlatform;

namespace VideoSharingSite.Pages.CollaborativeEvents
{
    public class EditModel : PageModel
    {
        private readonly VideoSharingConsole.VideoSharingContext _context;

        public EditModel(VideoSharingConsole.VideoSharingContext context)
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

            var collaborativeevent =  await _context.CollaborativeEvent.FirstOrDefaultAsync(m => m.ID == id);
            if (collaborativeevent == null)
            {
                return NotFound();
            }
            CollaborativeEvent = collaborativeevent;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CollaborativeEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollaborativeEventExists(CollaborativeEvent.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CollaborativeEventExists(int id)
        {
            return _context.CollaborativeEvent.Any(e => e.ID == id);
        }
    }
}

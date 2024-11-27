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

namespace VideoSharingSite.Pages.Videos
{
    public class EditModel : PageModel
    {
        private readonly VideoSharingConsole.VideoSharingContext _context;

        public EditModel(VideoSharingConsole.VideoSharingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Video Video { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video =  await _context.Video.FirstOrDefaultAsync(m => m.ID == id);
            if (video == null)
            {
                return NotFound();
            }
            Video = video;
           ViewData["StatisticsID"] = new SelectList(_context.Statistics, "ID", "TargetAudience");
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

            _context.Attach(Video).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoExists(Video.ID))
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

        private bool VideoExists(int id)
        {
            return _context.Video.Any(e => e.ID == id);
        }
    }
}

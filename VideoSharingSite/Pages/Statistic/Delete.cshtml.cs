using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VideoSharingConsole;
using VideoSharingPlatform;

namespace VideoSharingSite.Pages.Statistic
{
    public class DeleteModel : PageModel
    {
        private readonly VideoSharingConsole.VideoSharingContext _context;

        public DeleteModel(VideoSharingConsole.VideoSharingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Statistics Statistics { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statistics = await _context.Statistics.FirstOrDefaultAsync(m => m.ID == id);

            if (statistics == null)
            {
                return NotFound();
            }
            else
            {
                Statistics = statistics;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statistics = await _context.Statistics.FindAsync(id);
            if (statistics != null)
            {
                Statistics = statistics;
                _context.Statistics.Remove(Statistics);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

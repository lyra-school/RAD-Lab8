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

namespace VideoSharingSite.Pages.Statistic
{
    public class EditModel : PageModel
    {
        private readonly VideoSharingConsole.VideoSharingContext _context;

        public EditModel(VideoSharingConsole.VideoSharingContext context)
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

            var statistics =  await _context.Statistics.FirstOrDefaultAsync(m => m.ID == id);
            if (statistics == null)
            {
                return NotFound();
            }
            Statistics = statistics;
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

            _context.Attach(Statistics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatisticsExists(Statistics.ID))
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

        private bool StatisticsExists(int id)
        {
            return _context.Statistics.Any(e => e.ID == id);
        }
    }
}

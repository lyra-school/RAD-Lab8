using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VideoSharingConsole;
using VideoSharingPlatform;

namespace VideoSharingSite.Pages.Videos
{
    public class CreateModel : PageModel
    {
        private readonly VideoSharingConsole.VideoSharingContext _context;

        public CreateModel(VideoSharingConsole.VideoSharingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["StatisticsID"] = new SelectList(_context.Statistics, "ID", "TargetAudience");
            return Page();
        }

        [BindProperty]
        public Video Video { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Video.Add(Video);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

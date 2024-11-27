using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VideoSharingConsole;
using VideoSharingPlatform;

namespace VideoSharingSite.Pages.Creators
{
    public class DetailsModel : PageModel
    {
        private readonly VideoSharingConsole.VideoSharingContext _context;

        public DetailsModel(VideoSharingConsole.VideoSharingContext context)
        {
            _context = context;
        }

        public Creator Creator { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creator = await _context.Creator.FirstOrDefaultAsync(m => m.ID == id);
            if (creator == null)
            {
                return NotFound();
            }
            else
            {
                Creator = creator;
            }
            return Page();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VideoSharingConsole;
using VideoSharingPlatform;

namespace VideoSharingSite.Pages.Videos
{
    public class DetailsModel : PageModel
    {
        private readonly VideoSharingConsole.VideoSharingContext _context;

        public DetailsModel(VideoSharingConsole.VideoSharingContext context)
        {
            _context = context;
        }

        public Video Video { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _context.Video.FirstOrDefaultAsync(m => m.ID == id);
            if (video == null)
            {
                return NotFound();
            }
            else
            {
                Video = video;
            }
            return Page();
        }
    }
}
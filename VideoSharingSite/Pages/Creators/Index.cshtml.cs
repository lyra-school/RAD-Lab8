using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VideoSharingConsole;
using VideoSharingPlatform;

namespace VideoSharingSite.Pages.Creators
{
    public class IndexModel : DI_BasePageModel
    {
        public IndexModel(VideoSharingConsole.VideoSharingContext context, IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public IList<Creator> Creator { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Creator = await Context.Creator.ToListAsync();
        }
    }
}

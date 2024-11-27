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
using VideoSharingSite.Authorization;

namespace VideoSharingSite.Pages.Creators
{
    public class DeleteModel : DI_BasePageModel
    {
        public DeleteModel(VideoSharingConsole.VideoSharingContext context, IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public Creator Creator { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creator = await Context.Creator.FirstOrDefaultAsync(m => m.ID == id);

            if (creator == null)
            {
                return NotFound();
            }
            else
            {
                Creator = creator;
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                         User, Creator,
                                         PlatformOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creator = await Context.Creator.FindAsync(id);
            if(creator == null)
            {
                return NotFound();
            }
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                         User, Creator,
                                         PlatformOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Context.Creator.Remove(creator);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

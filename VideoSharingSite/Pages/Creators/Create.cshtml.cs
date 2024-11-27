using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VideoSharingConsole;
using VideoSharingPlatform;
using VideoSharingSite.Authorization;

namespace VideoSharingSite.Pages.Creators
{
    public class CreateModel : DI_BasePageModel
    {

        public CreateModel(VideoSharingConsole.VideoSharingContext context, IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager) : base(context, authorizationService, userManager)
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Creator Creator { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Creator.OwnerID = UserManager.GetUserId(User);

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                        User, Creator,
                                                        PlatformOperations.Create);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Context.Creator.Add(Creator);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

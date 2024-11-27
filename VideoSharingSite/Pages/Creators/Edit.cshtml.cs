using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VideoSharingConsole;
using VideoSharingPlatform;
using VideoSharingSite.Authorization;

namespace VideoSharingSite.Pages.Creators
{
    public class EditModel : DI_BasePageModel
    {

        public EditModel(VideoSharingConsole.VideoSharingContext context, IAuthorizationService authorizationService,
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

            var creator =  await Context.Creator.FirstOrDefaultAsync(m => m.ID == id);
            if (creator == null)
            {
                return NotFound();
            }
            Creator = creator;

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                          User, Creator,
                                          PlatformOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Fetch Contact from DB to get OwnerID.
            var creator = await Context
                .Creator.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (creator == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, creator,
                                                     PlatformOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Creator.OwnerID = creator.OwnerID;

            Context.Attach(Creator).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreatorExists(Creator.ID))
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

        private bool CreatorExists(int id)
        {
            return Context.Creator.Any(e => e.ID == id);
        }
    }
}

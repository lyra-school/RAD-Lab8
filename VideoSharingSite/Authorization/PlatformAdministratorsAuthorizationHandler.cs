using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.VisualBasic;

namespace VideoSharingSite.Authorization
{
    public class PlatformAdministratorsAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, VideoSharingPlatform.Creator>
    {
        protected override Task HandleRequirementAsync(
                                              AuthorizationHandlerContext context,
                                    OperationAuthorizationRequirement requirement,
                                     VideoSharingPlatform.Creator resource)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            // Administrators can do anything.
            if (context.User.IsInRole(Constants.PlatformAdministratorsRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

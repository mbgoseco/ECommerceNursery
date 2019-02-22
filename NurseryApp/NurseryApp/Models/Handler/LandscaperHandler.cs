using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models.Handler
{
    public class LandscaperHandler : AuthorizationHandler<LandscaperRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, LandscaperRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "Landscaper"))
            {
                return Task.CompletedTask;
            }

            string Landscape = context.User.FindFirst(u => u.Type == "Landscaper").Value;

            if (Landscape == "true")
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

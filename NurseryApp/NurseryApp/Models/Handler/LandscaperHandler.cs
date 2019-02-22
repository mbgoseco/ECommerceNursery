using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
            if (!context.User.HasClaim(c => c.Type == "Landscape"))
            {
                return Task.CompletedTask;
            }

            string Landscape = context.User.FindFirst(u => u.Type == "Landscape").Value;

            if (Landscape == "True")
            {
                context.Succeed(requirement);
            }
            if (Landscape == "False")
            {
                var authFilterContext = context.Resource as AuthorizationFilterContext;
                authFilterContext.Result = new RedirectToActionResult("Index", "Home", null);

                context.Succeed(requirement);

            }

            return Task.CompletedTask;
        }
    }
}

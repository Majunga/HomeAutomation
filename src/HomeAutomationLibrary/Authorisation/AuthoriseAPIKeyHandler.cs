using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomationLibrary.Authorisation
{
    public class AuthoriseAPIKeyHandler : AuthorizationHandler<AuthoriseAPIKeyRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                   AuthoriseAPIKeyRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Rsa && c.Subject.Name == "api_key"))
            {
                return Task.CompletedTask;
            }

            var apiKey = context.User.FindFirst(c => c.Type == ClaimTypes.Rsa && c.Subject.Name == "api_key");

            if (apiKey.Value == requirement.ApiKey)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

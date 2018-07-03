using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace HomeAutomationLibrary.Authorisation
{
    public class AuthoriseAPIKeyRequirement : IAuthorizationRequirement
    {
        public string ApiKey { get; set; }

        public AuthoriseAPIKeyRequirement(string apiKey)
        {
            this.ApiKey = apiKey;
        }
    }
}

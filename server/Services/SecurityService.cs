using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Components.Authorization;
using CoreRadzen.Models;

namespace CoreRadzen
{
    public partial class SecurityService
    {
        public event Action Authenticated;
        private ApplicationUser user;
        private readonly NavigationManager navigationManager;

        public SecurityService(NavigationManager navigationManager)
        {
            this.navigationManager = navigationManager;
        }

        public ApplicationUser User
        {
            get
            {
                if (Principal == null)
                {
                    return new ApplicationUser() { Name = "Anonymous" };
                }

                return user;
            }
        }

        public ClaimsPrincipal Principal { get; set; }

        public async Task<bool> InitializeAsync(AuthenticationStateProvider authenticationStateProvider)
        {
            var authenticationState = await authenticationStateProvider.GetAuthenticationStateAsync();

            Principal = authenticationState.User;

            var name = Principal?.FindFirstValue(ClaimTypes.Name) ?? Principal?.FindFirstValue("name");

            if (user == null && name != null)
            {
                user = new ApplicationUser { Name = name };
            }

            var result = IsAuthenticated();

            if (result)
            {
                Authenticated?.Invoke();
            }

            return result;
        }

        public bool IsInRole(params string[] roles)
        {
            if (roles.Contains("Everybody"))
            {
                return true;
            }

            if (!IsAuthenticated())
            {
                return false;
            }

            if (roles.Contains("Authenticated"))
            {
                return true;
            }

            return roles.Any(role => Principal.IsInRole(role));
        }

        public bool IsAuthenticated()
        {
            return Principal != null ? Principal.Identity.IsAuthenticated : false;
        }

        public async Task Logout()
        {
            navigationManager.NavigateTo("Account/Logout", true);
        }

        public async Task Login()
        {
            navigationManager.NavigateTo("Account/Login", true);
        }
    }
}

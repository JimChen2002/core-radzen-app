using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Mvc;

namespace CoreRadzen
{
    public partial class AccountController : Controller
    {
        public IActionResult Login()
        {
            var redirectUrl = Url.Content("~/");

            return Challenge(new AuthenticationProperties { RedirectUri = redirectUrl }, AzureADDefaults.AuthenticationScheme);
        }

        public IActionResult Logout()
        {
            var redirectUrl = Url.Content("~/");

            return SignOut(new AuthenticationProperties { RedirectUri = redirectUrl }, AzureADDefaults.CookieScheme, AzureADDefaults.OpenIdScheme);
        }
    }
}

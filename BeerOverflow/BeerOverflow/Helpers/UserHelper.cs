using System.Security.Claims;
using System.Security.Principal;

namespace BeerOverflow.Web
{
    public static class UserHelper
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            var claimsIdentity = (ClaimsIdentity)principal.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            return int.Parse(claim.Value);        }
    }
}
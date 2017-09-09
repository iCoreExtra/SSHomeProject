using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Web;

namespace SSHomeProject.Helpers
{
    public static class UserHelper
    {
        public static int GetUserId()
        {
            return HttpContext.Current.User.Identity.GetUserId<int>();
        }

        public static string GetUserName()
        {
            return HttpContext.Current.User.Identity.GetUserName();
        }

        public static string GetFirstName()
        {
            ClaimsPrincipal claims = HttpContext.Current.User as ClaimsPrincipal;
            Claim claim = claims.FindFirst(ClaimTypes.GivenName);
            return claim.Value;
        }
    }
}
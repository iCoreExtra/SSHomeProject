using Microsoft.AspNet.Identity;
using SSHomeProject.Models;
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

        public static ApplicationUser GetUserModel()
        {
            ClaimsPrincipal claims = HttpContext.Current.User as ClaimsPrincipal;
            ApplicationUser user = null;
            if (claims != null)
            {
                user.Id = GetUserId();
                user.UserName = GetUserName();
                user.FirstName = claims.FindFirst(ClaimTypes.GivenName).Value;
                user.LastName = claims.FindFirst(ClaimTypes.Surname).Value;
                user.Email = claims.FindFirst(ClaimTypes.Email).Value;
            }
            return user;
        }
    }
}
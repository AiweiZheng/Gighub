using System.Web;
using System.Web.Mvc;
using GigHub.Persistence;

namespace GigHub.Core.Filters
{
    public class AuthorizeSingleLogin : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);

            var user = httpContext.User.Identity.Name;
            var access = httpContext.Session.SessionID;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(access))
            {
                return isAuthorized;
            }

            var unitOfWork = new UnitOfWork(new ApplicationDbContext());
            return unitOfWork.Logins.IsLoggedIn(user, access);
        }
    }
}
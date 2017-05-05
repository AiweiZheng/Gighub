using System.Web;
using System.Web.Mvc;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;


namespace GigHub.Core.Filters
{
    public class AuthorizeActivatedAccount : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var unitOfWork = new UnitOfWork(new ApplicationDbContext());

            var userId = httpContext.User.Identity.GetUserId();
            var user = unitOfWork.Users.GetUser(userId);

            if (user == null || !user.Activated)
            {
                httpContext
                    .GetOwinContext()
                    .Authentication
                    .SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                return false;
            }

            return base.AuthorizeCore(httpContext);
        }
    }
}
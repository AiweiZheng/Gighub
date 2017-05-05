using System.Web;
using System.Web.Mvc;
using GigHub.Persistence;

namespace GigHub.Core.Filters
{
    public class AuthorizeSingleLogin : AuthorizeAttribute
    {
        private bool _isAuthorized;

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            _isAuthorized = base.AuthorizeCore(httpContext);

            var user = httpContext.User.Identity.Name;
            var access = httpContext.Session.SessionID;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(access))
            {
                return _isAuthorized;
            }

            var unitOfWork = new UnitOfWork(new ApplicationDbContext());
            _isAuthorized = unitOfWork.Logins.IsLoggedIn(user, access);

            return _isAuthorized;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (!_isAuthorized)
            {
                filterContext.Controller.TempData.Add("RedirectReason", "Account has logged in different hosts.");
            }
        }

    }
}
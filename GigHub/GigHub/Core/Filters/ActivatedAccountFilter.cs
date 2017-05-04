using System.Web.Mvc;
using System.Web.Routing;
using GigHub.Persistence;
using GigHub.Persistence.Repositories;
using Microsoft.AspNet.Identity;


namespace GigHub.Core.Filters
{
    public class ActivatedAccountFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userRepository = new UserRepository(new ApplicationDbContext());

            var userId = filterContext.HttpContext.User.Identity.GetUserId();
            var user = userRepository.GetUser(userId);

            if (user == null || !user.Activated)
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { action = "Login", controller = "Account" })
                    );
        }
    }
}
using System.Linq;
using System.Web.Mvc;
using GigHub.Core;
using GigHub.Core.Models;
using GigHub.Core.ViewModels;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index(string query = null)
        {
            var upcomingGigs = _unitOfWork.Gigs.GetUpcomingGigs(query);

            string userId = User.Identity.GetUserId();

            var attendances = _unitOfWork.Attendances.GetFutureAttendances(userId)
                .ToLookup(a => a.GigId);

            var viewModel = new GigsViewModel
            {
                UpcomingGigs = upcomingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Gigs",
                SearchTerm = query,
                Attendances = attendances
            };

            return View("Gigs", viewModel);
        }

        public ActionResult Artists()
        {
            var artistRoleId = _unitOfWork.Roles.GetRoleIdBy(RoleName.Artist);
            var artists = _unitOfWork.Users.GetUsersByRoleId(artistRoleId);

            var gigsPerFormByArtists = _unitOfWork.Gigs
                .GetUpcomingGigsPerformedBy(artists.Select(a => a.Id))
                .ToLookup(g => g.ArtistId);

            var userId = User.Identity.GetUserId();
            var attendances = _unitOfWork.Attendances.GetFutureAttendances(userId)
                .ToLookup(a => a.GigId);
            var followings = _unitOfWork.Followings.GetFolloweesFor(userId)
                .ToLookup(f => f.Followee.Id);

            var artistsViewModel = new ArtistsViewModel
            {
                Artists = artists,
                Gigs = gigsPerFormByArtists,
                Attendances = attendances,
                Followings = followings,
                ShowActions = User.Identity.IsAuthenticated,
            };

            return View(artistsViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
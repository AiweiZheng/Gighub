using System.Linq;
using System.Net;
using System.Web.Mvc;
using GigHub.Core;
using GigHub.Core.Models;
using GigHub.Core.ViewModels;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArtistsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Artists
        public ActionResult Index()
        {
            return View();
        }

        [Route("Artists/More/{startIndex}")]
        public ActionResult GetMoreArtists(int startIndex)
        {
            var artistRoleId = _unitOfWork.Roles.GetRoleIdBy(RoleName.Artist);
            var artists = _unitOfWork.Users.GetUsersByRoleId(artistRoleId, startIndex, AppConst.PageSizeXs);

            if (!artists.Any())
                return Content(HttpStatusCode.NoContent.ToString());

            var gigsPerFormByArtists = _unitOfWork.Gigs
                .GetCountOfUpcomingGigsPerformedBy(artists.Select(a => a.Id), AppConst.CountOfGigPerLoad);

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
                Followings = followings
            };

            return PartialView("_MoreArtists", artistsViewModel);
        }

    }
}
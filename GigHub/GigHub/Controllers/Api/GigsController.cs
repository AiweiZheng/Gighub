using System.Net;
using System.Web.Http;
using GigHub.Core;
using GigHub.Core.Filters;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
{
    [AuthorizeActivatedAccount]
    [AuthorizeSingleLogin]
    [Authorize]
    public class GigsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public GigsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _unitOfWork.Gigs.GetGigWithAttendees(id);

            if (gig == null || gig.IsCancelled)
                return Content(HttpStatusCode.NotFound, "The gig does not exist.");

            if (gig.ArtistId != userId)
                return Unauthorized();

            gig.Cancel();

            _unitOfWork.Complete();

            return Ok();
        }

    }
}

using System.Web.Http;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private readonly UnitOfWork _unitOfWork;

        public GigsController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _unitOfWork.Gigs.GetAttendancesInGig(id, userId);

            if (gig == null || gig.IsCancelled)
                return NotFound();

            gig.Cancel();

            _unitOfWork.Complete();

            return Ok();
        }

    }
}

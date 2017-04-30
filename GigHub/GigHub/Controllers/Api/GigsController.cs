using System.Web.Http;
using GigHub.Models;
using GigHub.Repositories;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly GigRepository _gigRepository;

        public GigsController()
        {
            _context = new ApplicationDbContext();
            _gigRepository = new GigRepository(_context);
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _gigRepository.GetAttendancesInGig(id, userId);

            if (gig == null || gig.IsCancelled)
                return NotFound();

            gig.Cancel();

            _context.SaveChanges();

            return Ok();
        }

    }
}

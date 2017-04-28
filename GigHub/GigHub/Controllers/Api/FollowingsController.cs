using System.Linq;
using System.Web.Http;
using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followerDto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Followings.Any(
                                 f => f.FolloweeId == followerDto.FolloweeId
                                 && f.FollowerId == userId))
                return BadRequest("Following already exists.");

            var follower = new Following
            {
                FolloweeId = followerDto.FolloweeId,
                FollowerId = userId
            };

            _context.Followings.Add(follower);
            _context.SaveChanges();

            return Ok();
        }
    }
}

using System.Web.Http;
using GigHub.Dtos;
using GigHub.Models;
using GigHub.Repositories;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly FollowingRepository _followingRepository;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
            _followingRepository = new FollowingRepository(_context);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followerDto)
        {
            var userId = User.Identity.GetUserId();

            if (_followingRepository.GetFollowing(followerDto.FolloweeId, userId) != null)
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

        [Authorize]
        [HttpDelete]
        public IHttpActionResult UnFollow(string id)
        {
            var userId = User.Identity.GetUserId();
            var following = _followingRepository.GetFollowing(id, userId);

            if (following == null)
                return NotFound();

            _context.Followings.Remove(following);
            _context.SaveChanges();

            return Ok(id);
        }
    }
}

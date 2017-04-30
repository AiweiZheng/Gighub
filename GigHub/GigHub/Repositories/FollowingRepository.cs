using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GigHub.Models;

namespace GigHub.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _context;
        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Following> GetUserFollowees(string userId)
        {
            return _context.Followings
                .Where(f => f.FollowerId == userId)
                .Include(f => f.Followee)
                .ToList();
        }

        public Following GetFollowing(string artistId, string userId)
        {
            return _context.Followings
                .SingleOrDefault(f => f.FolloweeId == artistId && f.FollowerId == userId);
        }

        public void Add(Following following)
        {
            _context.Followings.Add(following);
        }
        public void Remove(Following following)
        {
            _context.Followings.Remove(following);
        }
    }
}
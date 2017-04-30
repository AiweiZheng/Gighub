using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.Repositories
{
    public interface IFollowingRepository
    {
        IEnumerable<Following> GetUserFollowees(string userId);
        Following GetFollowing(string artistId, string userId);
        void Add(Following following);
        void Remove(Following following);
    }
}
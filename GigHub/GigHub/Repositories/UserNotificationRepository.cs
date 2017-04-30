using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GigHub.Models;

namespace GigHub.Repositories
{

    public class UserNotificationRepository
    {
        private readonly ApplicationDbContext _context;

        public UserNotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int GetNewNotificationNum(string userId)
        {
            return _context.UserNotifications
                .Count(un => un.UserId == userId && !un.IsRead);
        }

        public IEnumerable<Notification> GetNotifications(string userId)
        {
            return _context.UserNotifications
                .Where(un => un.UserId == userId).Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .OrderBy(n => n.Gig.ArtistId)
                .ToList();
        }

        public IEnumerable<UserNotification> GetUnreadNotifications(string userId)
        {
            return _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .ToList();
        }
    }
}
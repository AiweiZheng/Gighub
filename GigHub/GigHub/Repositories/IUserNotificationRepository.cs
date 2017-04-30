using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.Repositories
{
    public interface IUserNotificationRepository
    {
        int GetNewNotificationNum(string userId);
        IEnumerable<Notification> GetNotifications(string userId);
        IEnumerable<UserNotification> GetUnreadNotifications(string userId);
    }
}
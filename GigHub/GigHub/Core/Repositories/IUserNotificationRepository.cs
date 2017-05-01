using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IUserNotificationRepository
    {
        int GetNewNotificationNum(string userId);
        IEnumerable<Notification> GetNotifications(string userId);
        IEnumerable<UserNotification> GetUnreadNotifications(string userId);
    }
}
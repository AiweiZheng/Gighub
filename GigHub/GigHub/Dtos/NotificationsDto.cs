using System.Collections.Generic;

namespace GigHub.Dtos
{
    public class NotificationsDto
    {
        public int NewNotificationCount { get; set; }
        public IEnumerable<NotificationDto> Notifications { get; set; }
    }
}
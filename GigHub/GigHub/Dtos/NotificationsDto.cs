using System.Collections.Generic;

namespace GigHub.Dtos
{
    public class NotificationsDto
    {
        public int NewNotificationCount { get; private set; }
        public IEnumerable<NotificationDto> Notifications { get; private set; }

        public NotificationsDto(int newNotificationCount, IEnumerable<NotificationDto> notificationDtos)
        {
            NewNotificationCount = newNotificationCount;
            Notifications = notificationDtos;
        }
    }
}
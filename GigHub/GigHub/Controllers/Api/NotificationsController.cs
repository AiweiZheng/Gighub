using System.Linq;
using System.Web.Http;
using AutoMapper;
using GigHub.Dtos;
using GigHub.Models;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;
using WebGrease.Css.Extensions;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly UnitOfWork _unitOfWork;

        public NotificationsController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        [HttpGet]
        public NotificationsDto GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _unitOfWork.UserNotifications.GetNotifications(userId);

            return new NotificationsDto
            {
                NewNotificationCount = _unitOfWork.UserNotifications.GetNewNotificationNum(userId),
                Notifications = notifications.Select(Mapper.Map<Notification, NotificationDto>)
            };
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _unitOfWork.UserNotifications.GetUnreadNotifications(userId);

            notifications.ForEach(n => n.Read());

            _unitOfWork.Complete();

            return Ok();
        }
    }
}

using System.Linq;
using System.Web.Http;
using AutoMapper;
using GigHub.Dtos;
using GigHub.Models;
using GigHub.Repositories;
using Microsoft.AspNet.Identity;
using WebGrease.Css.Extensions;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly UserNotificationRepository _userNotificationRepository;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
            _userNotificationRepository = new UserNotificationRepository(_context);
        }

        [HttpGet]
        public NotificationsDto GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _userNotificationRepository.GetNotifications(userId);

            return new NotificationsDto
            {
                NewNotificationCount = _userNotificationRepository.GetNewNotificationNum(userId),
                Notifications = notifications.Select(Mapper.Map<Notification, NotificationDto>)
            };
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _userNotificationRepository.GetUnreadNotifications(userId);

            notifications.ForEach(n => n.Read());

            _context.SaveChanges();

            return Ok();
        }
    }
}

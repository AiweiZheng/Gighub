using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public NotificationsDto GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();

            var userNotifications = _context.UserNotifications
                .Where(un => un.UserId == userId);

            var notifications = userNotifications.Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .OrderBy(n => n.Gig.ArtistId)
                .ToList();

            var notificationsDto = notifications.Select(
                Mapper.Map<Notification, NotificationDto>
                );

            return new NotificationsDto(userNotifications.Count(un => !un.IsRead), notificationsDto);
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .ToList();

            notifications.ForEach(n => n.Read());

            _context.SaveChanges();

            return Ok();
        }
    }
}

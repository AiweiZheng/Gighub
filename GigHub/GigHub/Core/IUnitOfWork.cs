using System;
using GigHub.Core.Repositories;

namespace GigHub.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IGigRepository Gigs { get; }
        IAttendanceRepository Attendances { get; }
        IFollowingRepository Followings { get; }
        IGenreRepository Genres { get; }
        IVenueRepository Venues { get; }
        IUserNotificationRepository UserNotifications { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        ILoginRepository Logins { get; }
        //   IUserDescriptionRepository UserDescriptions { get; }
        void Complete();
    }
}
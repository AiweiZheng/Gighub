using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> GetUsers();
        ApplicationUser GetUser(string id);
        void Dispose();
    }
}